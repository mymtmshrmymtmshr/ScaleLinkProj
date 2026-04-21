using ScaleLink.Services;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace ScaleLink.Dialogs;

public partial class InitialWeightDialog : Window
{
    private bool _isManualMode;
    public decimal ConfirmedWeight { get; private set; }

    public InitialWeightDialog()
    {
        InitializeComponent();
        SubscribeWeightEvents();
    }

    private void BtnConfirm_Click(object sender, RoutedEventArgs e)
    {
        decimal weight;
        if (_isManualMode)
        {
            if (!TryParseManualWeight(txtManualWeight.Text, out var manualWeight) || manualWeight <= 0)
            {
                MessageBox.Show("初期計測重量は整数で入力してください。", "入力エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            weight = manualWeight;
        }
        else
        {
            var status = SerialPortService.Instance.Status;
            if (status == WeightStatus.Error || status == WeightStatus.Disconnected)
            {
                MessageBox.Show("重量が正常に受信できていません。手入力してください。", "受信エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
                SetManualMode(true);
                return;
            }
            weight = NormalizeInitialWeight(SerialPortService.Instance.LastWeight);
            if (weight <= 0)
            {
                MessageBox.Show("重量が0です。計量を確認してください。", "確認", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        ConfirmedWeight = weight;
        DialogResult = true;
        Close();
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    private void BtnNumPad_Click(object sender, RoutedEventArgs e)
    {
        SetManualMode(true);
        var numPad = new NumPadForm(txtManualWeight.Text);
        if (numPad.ShowDialog() != true)
            return;

        if (TryParseManualWeight(numPad.InputValue, out var manualWeight))
            txtManualWeight.Text = manualWeight.ToString("#,##0");
        else
            MessageBox.Show("初期計測重量は整数で入力してください。", "入力エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
    }

    private static bool TryParseManualWeight(string text, out int value)
    {
        return int.TryParse(text, NumberStyles.Integer | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out value);
    }

    private void SubscribeWeightEvents() =>
        SerialPortService.Instance.WeightReceived += OnWeightReceived;

    private void OnWeightReceived(object? sender, WeightReceivedEventArgs e)
    {
        if (!Dispatcher.CheckAccess())
        {
            Dispatcher.Invoke(() => OnWeightReceived(sender, e));
            return;
        }

        if (!_isManualMode)
            lblCurrentWeight.Text = NormalizeInitialWeight(e.Weight).ToString("#,##0");

        (lblWeightStatus.Text, lblWeightStatus.Foreground) = e.Status switch
        {
            WeightStatus.Stable => ("● 安定", Brushes.LimeGreen),
            WeightStatus.Unstable => ("▲ 計量中", Brushes.Orange),
            WeightStatus.Error => ("? 受信エラー", Brushes.Red),
            WeightStatus.Disconnected => ("─ 未接続", Brushes.Gray),
            _ => ("─ 未接続", Brushes.Gray),
        };
    }

    private void SetManualMode(bool manual)
    {
        _isManualMode = manual;
        txtManualWeight.IsEnabled = manual;
        if (manual)
        {
            lblWeightStatus.Text = "● 手入力モード";
            lblWeightStatus.Foreground = Brushes.Cyan;
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
