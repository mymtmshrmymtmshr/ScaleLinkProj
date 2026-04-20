using ScaleLink.Services;

namespace ScaleLink.Dialogs;

/// <summary>初期重量入力ダイアログ</summary>
public class InitialWeightDialog : Form
{
    private readonly Label lblCurrentWeight;
    private readonly Label lblWeightStatus;
    private readonly TextBox txtManualWeight;
    private bool _isManualMode;

    public decimal ConfirmedWeight { get; private set; }

    public InitialWeightDialog()
    {
        Text = "初期重量入力";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(400, 340);
        BackColor = Color.FromArgb(40, 40, 45);

        var lblTitle = new Label
        {
            Dock = DockStyle.Top,
            Height = 44,
            Text = "初期重量を確定してください",
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("メイリオ", 12F, FontStyle.Bold),
            ForeColor = Color.White,
        };

        var pnlWeight = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(8),
            BackColor = Color.FromArgb(40, 40, 45),
        };

        var btnConfirmWeight = new Button
        {
            Dock = DockStyle.Top,
            Height = 70,
            Text = "重量確定",
            Font = new Font("メイリオ", 18F, FontStyle.Bold),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(0, 122, 204),
            ForeColor = Color.White,
        };
        btnConfirmWeight.FlatAppearance.BorderSize = 0;
        btnConfirmWeight.Click += btnConfirmWeight_Click;

        var pnlManualInput = new Panel
        {
            Dock = DockStyle.Top,
            Height = 50,
            BackColor = Color.Transparent,
        };

        var lblManualTitle = new Label
        {
            Location = new Point(4, 5),
            Size = new Size(80, 40),
            Text = "重量手入力",
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("メイリオ", 9F),
            ForeColor = Color.LightGray,
        };

        txtManualWeight = new TextBox
        {
            Location = new Point(88, 7),
            Size = new Size(160, 39),
            Font = new Font("メイリオ", 16F),
            TextAlign = HorizontalAlignment.Right,
        };
        txtManualWeight.Click += txtManualWeight_Click;
        txtManualWeight.KeyPress += txtManualWeight_KeyPress;

        var btnNumPad = new Button
        {
            Location = new Point(254, 7),
            Size = new Size(44, 36),
            Text = "??",
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(60, 60, 70),
            ForeColor = Color.White,
        };
        btnNumPad.FlatAppearance.BorderSize = 0;
        btnNumPad.Click += btnNumPad_Click;

        pnlManualInput.Controls.Add(btnNumPad);
        pnlManualInput.Controls.Add(txtManualWeight);
        pnlManualInput.Controls.Add(lblManualTitle);

        lblWeightStatus = new Label
        {
            Dock = DockStyle.Top,
            Height = 24,
            Text = "─ 未接続",
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("メイリオ", 10F),
            ForeColor = Color.Gray,
        };

        var lblWeightUnit = new Label
        {
            Dock = DockStyle.Top,
            Height = 36,
            Text = "kg",
            TextAlign = ContentAlignment.MiddleRight,
            Font = new Font("メイリオ", 24F),
            ForeColor = Color.LightGray,
        };

        lblCurrentWeight = new Label
        {
            Dock = DockStyle.Top,
            Height = 90,
            Text = "---",
            TextAlign = ContentAlignment.MiddleRight,
            Font = new Font("メイリオ", 48F, FontStyle.Bold),
            ForeColor = Color.LimeGreen,
        };

        var lblWeightTitle = new Label
        {
            Dock = DockStyle.Top,
            Height = 30,
            Text = "受信重量",
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("メイリオ", 12F),
            ForeColor = Color.LightGray,
        };

        pnlWeight.Controls.Add(btnConfirmWeight);
        pnlWeight.Controls.Add(pnlManualInput);
        pnlWeight.Controls.Add(lblWeightStatus);
        pnlWeight.Controls.Add(lblWeightUnit);
        pnlWeight.Controls.Add(lblCurrentWeight);
        pnlWeight.Controls.Add(lblWeightTitle);

        Controls.Add(pnlWeight);
        Controls.Add(lblTitle);

        SubscribeWeightEvents();
    }

    private void btnConfirmWeight_Click(object? sender, EventArgs e)
    {
        decimal weight;
        if (_isManualMode)
        {
            if (!int.TryParse(txtManualWeight.Text, out var manualWeight) || manualWeight <= 0)
            {
                MessageBox.Show("初期計測重量は整数で入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            weight = manualWeight;
        }
        else
        {
            var status = SerialPortService.Instance.Status;
            if (status == WeightStatus.Error || status == WeightStatus.Disconnected)
            {
                MessageBox.Show("重量が正常に受信できていません。手入力してください。", "受信エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetManualMode(true);
                return;
            }

            weight = NormalizeInitialWeight(SerialPortService.Instance.LastWeight);
            if (weight <= 0)
            {
                MessageBox.Show("重量が0です。計量を確認してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        ConfirmedWeight = weight;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnNumPad_Click(object? sender, EventArgs e)
    {
        SetManualMode(true);
        using var numPad = new NumPadForm(txtManualWeight.Text);
        if (numPad.ShowDialog(this) == DialogResult.OK)
        {
            if (int.TryParse(numPad.InputValue, out var manualWeight))
                txtManualWeight.Text = manualWeight.ToString("#,##0");
            else
                MessageBox.Show("初期計測重量は整数で入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void txtManualWeight_Click(object? sender, EventArgs e) => SetManualMode(true);

    private void txtManualWeight_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            e.Handled = true;
    }

    private void SubscribeWeightEvents() =>
        SerialPortService.Instance.WeightReceived += OnWeightReceived;

    private void OnWeightReceived(object? sender, WeightReceivedEventArgs e)
    {
        if (InvokeRequired)
        {
            Invoke(() => OnWeightReceived(sender, e));
            return;
        }

        if (!_isManualMode)
            lblCurrentWeight.Text = NormalizeInitialWeight(e.Weight).ToString("#,##0");

        (lblWeightStatus.Text, lblWeightStatus.ForeColor) = e.Status switch
        {
            WeightStatus.Stable => ("● 安定", Color.LimeGreen),
            WeightStatus.Unstable => ("▲ 計量中", Color.Orange),
            WeightStatus.Error => ("? 受信エラー", Color.Red),
            WeightStatus.Disconnected => ("─ 未接続", Color.Gray),
            _ => ("─ 未接続", Color.Gray),
        };
    }

    private void SetManualMode(bool manual)
    {
        _isManualMode = manual;
        txtManualWeight.Enabled = manual;
        if (manual)
        {
            lblWeightStatus.Text = "● 手入力モード";
            lblWeightStatus.ForeColor = Color.Cyan;
        }
    }

    private static decimal NormalizeInitialWeight(decimal weight) =>
        Math.Round(weight, 0, MidpointRounding.AwayFromZero);

    protected override void OnClosed(EventArgs e)
    {
        SerialPortService.Instance.WeightReceived -= OnWeightReceived;
        base.OnClosed(e);
    }
}
