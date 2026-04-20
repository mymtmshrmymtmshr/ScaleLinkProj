namespace ScaleLink.Dialogs;

partial class InitialWeightDialog
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitle = new Label();
        pnlWeight = new Panel();
        btnConfirmWeight = new Button();
        pnlManualInput = new Panel();
        btnNumPad = new Button();
        txtManualWeight = new TextBox();
        lblManualTitle = new Label();
        lblWeightStatus = new Label();
        lblWeightUnit = new Label();
        lblCurrentWeight = new Label();
        lblWeightTitle = new Label();
        pnlWeight.SuspendLayout();
        pnlManualInput.SuspendLayout();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Top;
        lblTitle.Font = new Font("メイリオ", 12F, FontStyle.Bold);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(0, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(400, 44);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "初期重量を確定してください";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlWeight
        // 
        pnlWeight.BackColor = Color.FromArgb(40, 40, 45);
        pnlWeight.Controls.Add(btnConfirmWeight);
        pnlWeight.Controls.Add(pnlManualInput);
        pnlWeight.Controls.Add(lblWeightStatus);
        pnlWeight.Controls.Add(lblWeightUnit);
        pnlWeight.Controls.Add(lblCurrentWeight);
        pnlWeight.Controls.Add(lblWeightTitle);
        pnlWeight.Dock = DockStyle.Fill;
        pnlWeight.Location = new Point(0, 44);
        pnlWeight.Name = "pnlWeight";
        pnlWeight.Padding = new Padding(8);
        pnlWeight.Size = new Size(400, 296);
        pnlWeight.TabIndex = 1;
        // 
        // btnConfirmWeight
        // 
        btnConfirmWeight.BackColor = Color.FromArgb(0, 122, 204);
        btnConfirmWeight.Dock = DockStyle.Top;
        btnConfirmWeight.FlatAppearance.BorderSize = 0;
        btnConfirmWeight.FlatStyle = FlatStyle.Flat;
        btnConfirmWeight.Font = new Font("メイリオ", 18F, FontStyle.Bold);
        btnConfirmWeight.ForeColor = Color.White;
        btnConfirmWeight.Location = new Point(8, 246);
        btnConfirmWeight.Name = "btnConfirmWeight";
        btnConfirmWeight.Size = new Size(384, 70);
        btnConfirmWeight.TabIndex = 5;
        btnConfirmWeight.Text = "重量確定";
        btnConfirmWeight.UseVisualStyleBackColor = false;
        btnConfirmWeight.Click += btnConfirmWeight_Click;
        // 
        // pnlManualInput
        // 
        pnlManualInput.BackColor = Color.Transparent;
        pnlManualInput.Controls.Add(btnNumPad);
        pnlManualInput.Controls.Add(txtManualWeight);
        pnlManualInput.Controls.Add(lblManualTitle);
        pnlManualInput.Dock = DockStyle.Top;
        pnlManualInput.Location = new Point(8, 196);
        pnlManualInput.Name = "pnlManualInput";
        pnlManualInput.Size = new Size(384, 50);
        pnlManualInput.TabIndex = 4;
        // 
        // btnNumPad
        // 
        btnNumPad.BackColor = Color.FromArgb(60, 60, 70);
        btnNumPad.FlatAppearance.BorderSize = 0;
        btnNumPad.FlatStyle = FlatStyle.Flat;
        btnNumPad.Font = new Font("Yu Gothic UI", 12F);
        btnNumPad.ForeColor = Color.White;
        btnNumPad.Location = new Point(254, 7);
        btnNumPad.Name = "btnNumPad";
        btnNumPad.Size = new Size(60, 36);
        btnNumPad.TabIndex = 2;
        btnNumPad.Text = "電卓";
        btnNumPad.UseVisualStyleBackColor = false;
        btnNumPad.Click += btnNumPad_Click;
        // 
        // txtManualWeight
        // 
        txtManualWeight.Font = new Font("メイリオ", 16F);
        txtManualWeight.Location = new Point(88, 7);
        txtManualWeight.Name = "txtManualWeight";
        txtManualWeight.Size = new Size(160, 39);
        txtManualWeight.TabIndex = 1;
        txtManualWeight.TextAlign = HorizontalAlignment.Right;
        txtManualWeight.Click += txtManualWeight_Click;
        txtManualWeight.KeyPress += txtManualWeight_KeyPress;
        // 
        // lblManualTitle
        // 
        lblManualTitle.Font = new Font("メイリオ", 9F);
        lblManualTitle.ForeColor = Color.LightGray;
        lblManualTitle.Location = new Point(4, 5);
        lblManualTitle.Name = "lblManualTitle";
        lblManualTitle.Size = new Size(80, 40);
        lblManualTitle.TabIndex = 0;
        lblManualTitle.Text = "重量手入力";
        lblManualTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblWeightStatus
        // 
        lblWeightStatus.Dock = DockStyle.Top;
        lblWeightStatus.Font = new Font("メイリオ", 10F);
        lblWeightStatus.ForeColor = Color.Gray;
        lblWeightStatus.Location = new Point(8, 172);
        lblWeightStatus.Name = "lblWeightStatus";
        lblWeightStatus.Size = new Size(384, 24);
        lblWeightStatus.TabIndex = 3;
        lblWeightStatus.Text = "─ 未接続";
        lblWeightStatus.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblWeightUnit
        // 
        lblWeightUnit.Dock = DockStyle.Top;
        lblWeightUnit.Font = new Font("メイリオ", 24F);
        lblWeightUnit.ForeColor = Color.LightGray;
        lblWeightUnit.Location = new Point(8, 128);
        lblWeightUnit.Name = "lblWeightUnit";
        lblWeightUnit.Size = new Size(384, 44);
        lblWeightUnit.TabIndex = 2;
        lblWeightUnit.Text = "kg";
        lblWeightUnit.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblCurrentWeight
        // 
        lblCurrentWeight.Dock = DockStyle.Top;
        lblCurrentWeight.Font = new Font("メイリオ", 48F, FontStyle.Bold);
        lblCurrentWeight.ForeColor = Color.LimeGreen;
        lblCurrentWeight.Location = new Point(8, 38);
        lblCurrentWeight.Name = "lblCurrentWeight";
        lblCurrentWeight.Size = new Size(384, 90);
        lblCurrentWeight.TabIndex = 1;
        lblCurrentWeight.Text = "---";
        lblCurrentWeight.TextAlign = ContentAlignment.MiddleRight;
        lblCurrentWeight.Click += lblCurrentWeight_Click;
        // 
        // lblWeightTitle
        // 
        lblWeightTitle.Dock = DockStyle.Top;
        lblWeightTitle.Font = new Font("メイリオ", 12F);
        lblWeightTitle.ForeColor = Color.LightGray;
        lblWeightTitle.Location = new Point(8, 8);
        lblWeightTitle.Name = "lblWeightTitle";
        lblWeightTitle.Size = new Size(384, 30);
        lblWeightTitle.TabIndex = 0;
        lblWeightTitle.Text = "受信重量";
        lblWeightTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // InitialWeightDialog
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(40, 40, 45);
        ClientSize = new Size(400, 340);
        Controls.Add(pnlWeight);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "InitialWeightDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "初期重量入力";
        pnlWeight.ResumeLayout(false);
        pnlManualInput.ResumeLayout(false);
        pnlManualInput.PerformLayout();
        ResumeLayout(false);
    }

    private Label lblTitle;
    private Panel pnlWeight;
    private Button btnConfirmWeight;
    private Panel pnlManualInput;
    private Button btnNumPad;
    private TextBox txtManualWeight;
    private Label lblManualTitle;
    private Label lblWeightStatus;
    private Label lblWeightUnit;
    private Label lblCurrentWeight;
    private Label lblWeightTitle;
}
