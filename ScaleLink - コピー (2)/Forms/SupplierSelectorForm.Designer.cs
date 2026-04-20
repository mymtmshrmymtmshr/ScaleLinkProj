namespace ScaleLink.Forms;

partial class SupplierSelectorForm
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
        pnlAdd = new Panel();
        btnAdd = new Button();
        pnlList = new Panel();
        lblEmpty = new Label();
        pnlTempRecall = new Panel();
        btnTempRecall = new Button();
        pnlExit = new Panel();
        btnExit = new Button();
        pnlAdd.SuspendLayout();
        pnlList.SuspendLayout();
        pnlTempRecall.SuspendLayout();
        pnlExit.SuspendLayout();
        SuspendLayout();
        // 
        // pnlAdd
        // 
        pnlAdd.BackColor = Color.Transparent;
        pnlAdd.Controls.Add(btnAdd);
        pnlAdd.Dock = DockStyle.Top;
        pnlAdd.Location = new Point(0, 0);
        pnlAdd.Name = "pnlAdd";
        pnlAdd.Size = new Size(135, 80);
        pnlAdd.TabIndex = 0;
        // 
        // btnAdd
        // 
        btnAdd.BackColor = Color.FromArgb(0, 122, 204);
        btnAdd.FlatAppearance.BorderSize = 0;
        btnAdd.FlatStyle = FlatStyle.Flat;
        btnAdd.Font = new Font("メイリオ", 10F, FontStyle.Bold);
        btnAdd.ForeColor = Color.White;
        btnAdd.Location = new Point(5, 5);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(125, 70);
        btnAdd.TabIndex = 0;
        btnAdd.Text = "＋\n追加";
        btnAdd.UseVisualStyleBackColor = false;
        btnAdd.Click += btnAdd_Click;
        // 
        // pnlList
        // 
        pnlList.AutoScroll = true;
        pnlList.BackColor = Color.Transparent;
        pnlList.Controls.Add(lblEmpty);
        pnlList.Dock = DockStyle.Fill;
        pnlList.Location = new Point(0, 80);
        pnlList.Name = "pnlList";
        pnlList.Size = new Size(135, 784);
        pnlList.TabIndex = 1;
        // 
        // lblEmpty
        // 
        lblEmpty.Dock = DockStyle.Fill;
        lblEmpty.Font = new Font("メイリオ", 9F);
        lblEmpty.ForeColor = Color.Gray;
        lblEmpty.Location = new Point(0, 0);
        lblEmpty.Name = "lblEmpty";
        lblEmpty.Size = new Size(135, 864);
        lblEmpty.TabIndex = 0;
        lblEmpty.Text = "業者\nなし";
        lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlTempRecall
        // 
        pnlTempRecall.BackColor = Color.Transparent;
        pnlTempRecall.Controls.Add(btnTempRecall);
        pnlTempRecall.Dock = DockStyle.Bottom;
        pnlTempRecall.Location = new Point(0, 864);
        pnlTempRecall.Name = "pnlTempRecall";
        pnlTempRecall.Size = new Size(135, 80);
        pnlTempRecall.TabIndex = 2;
        // 
        // btnTempRecall
        // 
        btnTempRecall.BackColor = Color.FromArgb(100, 100, 150);
        btnTempRecall.FlatAppearance.BorderSize = 0;
        btnTempRecall.FlatStyle = FlatStyle.Flat;
        btnTempRecall.Font = new Font("メイリオ", 9F, FontStyle.Bold);
        btnTempRecall.ForeColor = Color.White;
        btnTempRecall.Location = new Point(5, 5);
        btnTempRecall.Name = "btnTempRecall";
        btnTempRecall.Size = new Size(125, 70);
        btnTempRecall.TabIndex = 0;
        btnTempRecall.Text = "仮登録\n呼出し";
        btnTempRecall.UseVisualStyleBackColor = false;
        btnTempRecall.Click += btnTempRecall_Click;
        // 
        // pnlExit
        // 
        pnlExit.BackColor = Color.Transparent;
        pnlExit.Controls.Add(btnExit);
        pnlExit.Dock = DockStyle.Bottom;
        pnlExit.Location = new Point(0, 944);
        pnlExit.Name = "pnlExit";
        pnlExit.Size = new Size(135, 80);
        pnlExit.TabIndex = 3;
        // 
        // btnExit
        // 
        btnExit.BackColor = Color.FromArgb(160, 30, 30);
        btnExit.FlatAppearance.BorderSize = 0;
        btnExit.FlatStyle = FlatStyle.Flat;
        btnExit.Font = new Font("メイリオ", 10F, FontStyle.Bold);
        btnExit.ForeColor = Color.White;
        btnExit.Location = new Point(5, 5);
        btnExit.Name = "btnExit";
        btnExit.Size = new Size(125, 70);
        btnExit.TabIndex = 0;
        btnExit.Text = "終了";
        btnExit.UseVisualStyleBackColor = false;
        btnExit.Click += btnExit_Click;
        // 
        // SupplierSelectorForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(45, 45, 48);
        ClientSize = new Size(135, 1024);
        Controls.Add(pnlList);
        Controls.Add(pnlAdd);
        Controls.Add(pnlTempRecall);
        Controls.Add(pnlExit);
        FormBorderStyle = FormBorderStyle.None;
        Name = "SupplierSelectorForm";
        Text = "業者選択";
        pnlAdd.ResumeLayout(false);
        pnlList.ResumeLayout(false);
        pnlTempRecall.ResumeLayout(false);
        pnlExit.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel pnlAdd;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Panel pnlList;
    private System.Windows.Forms.Label lblEmpty;
    private System.Windows.Forms.Panel pnlTempRecall;
    private System.Windows.Forms.Button btnTempRecall;
    private System.Windows.Forms.Panel pnlExit;
    private System.Windows.Forms.Button btnExit;
}
