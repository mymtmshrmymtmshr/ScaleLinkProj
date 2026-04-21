namespace ScaleLink.Forms;

partial class MeasurementTicketForm
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
        tlpHeader = new TableLayoutPanel();
        lblColDate = new Label();
        lblAccDate = new Label();
        lblBranch = new Label();
        lblTransType = new Label();
        lblScaleNo = new Label();
        dtpCollectDate = new DateTimePicker();
        dtpAccountDate = new DateTimePicker();
        pnlBranch = new Panel();
        lblBranchName = new Label();
        txtBranchCode = new TextBox();
        pnlTransType = new Panel();
        lblTransTypeName = new Label();
        cmbTransType = new ComboBox();
        txtScaleNo = new TextBox();
        tlpSupplier = new TableLayoutPanel();
        lblSupplierHd = new Label();
        lblSupplierNameHd = new Label();
        lblCarrierHd = new Label();
        lblCarNoHd = new Label();
        lblPayTypeHd = new Label();
        lblStaffHd = new Label();
        txtSupplierCode = new TextBox();
        lblSupplierName = new Label();
        pnlCarrier = new Panel();
        lblCarrierName = new Label();
        txtCarrierCode = new TextBox();
        txtCarNo = new TextBox();
        pnlPayType = new Panel();
        lblPaymentTypeName = new Label();
        cmbPaymentType = new ComboBox();
        txtStaffCode = new TextBox();
        pnlInitialMeasuredWeight = new Panel();
        txtInitialMeasuredWeight = new TextBox();
        lblInitialMeasuredWeight = new Label();
        dgvDetails = new DataGridView();
        pnlTotal = new Panel();
        lblTotalPayment = new Label();
        lblTotalAmount = new Label();
        lblTotalCount = new Label();
        lblTotalQuantity = new Label();
        lblTotalCaption = new Label();
        pnlButtons = new Panel();
        btnPrintReceipt = new Button();
        btnPrintShipping = new Button();
        btnClear = new Button();
        btnRegister = new Button();
        tlpHeader.SuspendLayout();
        pnlBranch.SuspendLayout();
        pnlTransType.SuspendLayout();
        tlpSupplier.SuspendLayout();
        pnlCarrier.SuspendLayout();
        pnlPayType.SuspendLayout();
        pnlInitialMeasuredWeight.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
        pnlTotal.SuspendLayout();
        pnlButtons.SuspendLayout();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.BackColor = Color.FromArgb(0, 122, 204);
        lblTitle.Dock = DockStyle.Top;
        lblTitle.Font = new Font("メイリオ", 14F, FontStyle.Bold);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(4, 4);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(792, 36);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "＊＊ 計量票入力 ＊＊";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // tlpHeader
        // 
        tlpHeader.BackColor = Color.FromArgb(245, 245, 250);
        tlpHeader.ColumnCount = 5;
        tlpHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        tlpHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        tlpHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
        tlpHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
        tlpHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpHeader.Controls.Add(lblColDate, 0, 0);
        tlpHeader.Controls.Add(lblAccDate, 1, 0);
        tlpHeader.Controls.Add(lblBranch, 2, 0);
        tlpHeader.Controls.Add(lblTransType, 3, 0);
        tlpHeader.Controls.Add(lblScaleNo, 4, 0);
        tlpHeader.Controls.Add(dtpCollectDate, 0, 1);
        tlpHeader.Controls.Add(dtpAccountDate, 1, 1);
        tlpHeader.Controls.Add(pnlBranch, 2, 1);
        tlpHeader.Controls.Add(pnlTransType, 3, 1);
        tlpHeader.Controls.Add(txtScaleNo, 4, 1);
        tlpHeader.Dock = DockStyle.Top;
        tlpHeader.Location = new Point(4, 40);
        tlpHeader.Name = "tlpHeader";
        tlpHeader.RowCount = 2;
        tlpHeader.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        tlpHeader.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        tlpHeader.Size = new Size(792, 60);
        tlpHeader.TabIndex = 1;
        // 
        // lblColDate
        // 
        lblColDate.Dock = DockStyle.Fill;
        lblColDate.Font = new Font("メイリオ", 9F, FontStyle.Bold);
        lblColDate.Location = new Point(3, 0);
        lblColDate.Name = "lblColDate";
        lblColDate.Size = new Size(114, 24);
        lblColDate.TabIndex = 0;
        lblColDate.Text = "集計日";
        lblColDate.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblAccDate
        // 
        lblAccDate.Dock = DockStyle.Fill;
        lblAccDate.Font = new Font("メイリオ", 9F, FontStyle.Bold);
        lblAccDate.Location = new Point(123, 0);
        lblAccDate.Name = "lblAccDate";
        lblAccDate.Size = new Size(114, 24);
        lblAccDate.TabIndex = 1;
        lblAccDate.Text = "計上日";
        lblAccDate.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblBranch
        // 
        lblBranch.Dock = DockStyle.Fill;
        lblBranch.Font = new Font("メイリオ", 9F, FontStyle.Bold);
        lblBranch.Location = new Point(243, 0);
        lblBranch.Name = "lblBranch";
        lblBranch.Size = new Size(174, 24);
        lblBranch.TabIndex = 2;
        lblBranch.Text = "営業所";
        lblBranch.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTransType
        // 
        lblTransType.Dock = DockStyle.Fill;
        lblTransType.Font = new Font("メイリオ", 9F, FontStyle.Bold);
        lblTransType.Location = new Point(423, 0);
        lblTransType.Name = "lblTransType";
        lblTransType.Size = new Size(174, 24);
        lblTransType.TabIndex = 3;
        lblTransType.Text = "取引区分";
        lblTransType.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblScaleNo
        // 
        lblScaleNo.Dock = DockStyle.Fill;
        lblScaleNo.Font = new Font("メイリオ", 9F, FontStyle.Bold);
        lblScaleNo.Location = new Point(603, 0);
        lblScaleNo.Name = "lblScaleNo";
        lblScaleNo.Size = new Size(186, 24);
        lblScaleNo.TabIndex = 4;
        lblScaleNo.Text = "スケールNo.";
        lblScaleNo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // dtpCollectDate
        // 
        dtpCollectDate.Dock = DockStyle.Fill;
        dtpCollectDate.Format = DateTimePickerFormat.Short;
        dtpCollectDate.Location = new Point(3, 27);
        dtpCollectDate.Name = "dtpCollectDate";
        dtpCollectDate.Size = new Size(114, 23);
        dtpCollectDate.TabIndex = 5;
        // 
        // dtpAccountDate
        // 
        dtpAccountDate.Dock = DockStyle.Fill;
        dtpAccountDate.Format = DateTimePickerFormat.Short;
        dtpAccountDate.Location = new Point(123, 27);
        dtpAccountDate.Name = "dtpAccountDate";
        dtpAccountDate.Size = new Size(114, 23);
        dtpAccountDate.TabIndex = 6;
        // 
        // pnlBranch
        // 
        pnlBranch.Controls.Add(lblBranchName);
        pnlBranch.Controls.Add(txtBranchCode);
        pnlBranch.Dock = DockStyle.Fill;
        pnlBranch.Location = new Point(243, 27);
        pnlBranch.Name = "pnlBranch";
        pnlBranch.Size = new Size(174, 30);
        pnlBranch.TabIndex = 7;
        // 
        // lblBranchName
        // 
        lblBranchName.BackColor = Color.FromArgb(240, 240, 240);
        lblBranchName.Dock = DockStyle.Fill;
        lblBranchName.Location = new Point(40, 0);
        lblBranchName.Name = "lblBranchName";
        lblBranchName.Size = new Size(134, 30);
        lblBranchName.TabIndex = 0;
        lblBranchName.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // txtBranchCode
        // 
        txtBranchCode.Dock = DockStyle.Left;
        txtBranchCode.Location = new Point(0, 0);
        txtBranchCode.Name = "txtBranchCode";
        txtBranchCode.Size = new Size(40, 23);
        txtBranchCode.TabIndex = 1;
        // 
        // pnlTransType
        // 
        pnlTransType.Controls.Add(lblTransTypeName);
        pnlTransType.Controls.Add(cmbTransType);
        pnlTransType.Dock = DockStyle.Fill;
        pnlTransType.Location = new Point(423, 27);
        pnlTransType.Name = "pnlTransType";
        pnlTransType.Size = new Size(174, 30);
        pnlTransType.TabIndex = 8;
        // 
        // lblTransTypeName
        // 
        lblTransTypeName.BackColor = Color.FromArgb(240, 240, 240);
        lblTransTypeName.Dock = DockStyle.Fill;
        lblTransTypeName.Location = new Point(40, 0);
        lblTransTypeName.Name = "lblTransTypeName";
        lblTransTypeName.Size = new Size(134, 30);
        lblTransTypeName.TabIndex = 0;
        lblTransTypeName.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // cmbTransType
        // 
        cmbTransType.Dock = DockStyle.Left;
        cmbTransType.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTransType.Location = new Point(0, 0);
        cmbTransType.Name = "cmbTransType";
        cmbTransType.Size = new Size(40, 23);
        cmbTransType.TabIndex = 1;
        // 
        // txtScaleNo
        // 
        txtScaleNo.BackColor = Color.FromArgb(240, 240, 240);
        txtScaleNo.Dock = DockStyle.Fill;
        txtScaleNo.Location = new Point(603, 27);
        txtScaleNo.Name = "txtScaleNo";
        txtScaleNo.ReadOnly = true;
        txtScaleNo.Size = new Size(186, 23);
        txtScaleNo.TabIndex = 9;
        // 
        // tlpSupplier
        // 
        tlpSupplier.BackColor = Color.FromArgb(250, 250, 255);
        tlpSupplier.ColumnCount = 6;
        tlpSupplier.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
        tlpSupplier.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
        tlpSupplier.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
        tlpSupplier.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        tlpSupplier.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        tlpSupplier.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpSupplier.Controls.Add(lblSupplierHd, 0, 0);
        tlpSupplier.Controls.Add(lblSupplierNameHd, 1, 0);
        tlpSupplier.Controls.Add(lblCarrierHd, 2, 0);
        tlpSupplier.Controls.Add(lblCarNoHd, 3, 0);
        tlpSupplier.Controls.Add(lblPayTypeHd, 4, 0);
        tlpSupplier.Controls.Add(lblStaffHd, 5, 0);
        tlpSupplier.Controls.Add(txtSupplierCode, 0, 1);
        tlpSupplier.Controls.Add(lblSupplierName, 1, 1);
        tlpSupplier.Controls.Add(pnlCarrier, 2, 1);
        tlpSupplier.Controls.Add(txtCarNo, 3, 1);
        tlpSupplier.Controls.Add(pnlPayType, 4, 1);
        tlpSupplier.Controls.Add(txtStaffCode, 5, 1);
        tlpSupplier.Dock = DockStyle.Top;
        tlpSupplier.Location = new Point(4, 100);
        tlpSupplier.Name = "tlpSupplier";
        tlpSupplier.RowCount = 2;
        tlpSupplier.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        tlpSupplier.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        tlpSupplier.Size = new Size(792, 60);
        tlpSupplier.TabIndex = 2;
        // 
        // lblSupplierHd
        // 
        lblSupplierHd.Dock = DockStyle.Fill;
        lblSupplierHd.Font = new Font("メイリオ", 9F, FontStyle.Bold);
        lblSupplierHd.Location = new Point(3, 0);
        lblSupplierHd.Name = "lblSupplierHd";
        lblSupplierHd.Size = new Size(74, 24);
        lblSupplierHd.TabIndex = 0;
        lblSupplierHd.Text = "取引先";
        lblSupplierHd.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSupplierNameHd
        // 
        lblSupplierNameHd.Dock = DockStyle.Fill;
        lblSupplierNameHd.Font = new Font("メイリオ", 9F, FontStyle.Bold);
        lblSupplierNameHd.Location = new Point(83, 0);
        lblSupplierNameHd.Name = "lblSupplierNameHd";
        lblSupplierNameHd.Size = new Size(194, 24);
        lblSupplierNameHd.TabIndex = 1;
        lblSupplierNameHd.Text = "取引先名";
        lblSupplierNameHd.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblCarrierHd
        // 
        lblCarrierHd.Dock = DockStyle.Fill;
        lblCarrierHd.Font = new Font("メイリオ", 9F, FontStyle.Bold);
        lblCarrierHd.Location = new Point(283, 0);
        lblCarrierHd.Name = "lblCarrierHd";
        lblCarrierHd.Size = new Size(154, 24);
        lblCarrierHd.TabIndex = 2;
        lblCarrierHd.Text = "運送";
        lblCarrierHd.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblCarNoHd
        // 
        lblCarNoHd.Dock = DockStyle.Fill;
        lblCarNoHd.Font = new Font("メイリオ", 9F, FontStyle.Bold);
        lblCarNoHd.Location = new Point(443, 0);
        lblCarNoHd.Name = "lblCarNoHd";
        lblCarNoHd.Size = new Size(114, 24);
        lblCarNoHd.TabIndex = 3;
        lblCarNoHd.Text = "車番";
        lblCarNoHd.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblPayTypeHd
        // 
        lblPayTypeHd.Dock = DockStyle.Fill;
        lblPayTypeHd.Font = new Font("メイリオ", 9F, FontStyle.Bold);
        lblPayTypeHd.Location = new Point(563, 0);
        lblPayTypeHd.Name = "lblPayTypeHd";
        lblPayTypeHd.Size = new Size(114, 24);
        lblPayTypeHd.TabIndex = 4;
        lblPayTypeHd.Text = "支払区分";
        lblPayTypeHd.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblStaffHd
        // 
        lblStaffHd.Dock = DockStyle.Fill;
        lblStaffHd.Font = new Font("メイリオ", 9F, FontStyle.Bold);
        lblStaffHd.Location = new Point(683, 0);
        lblStaffHd.Name = "lblStaffHd";
        lblStaffHd.Size = new Size(106, 24);
        lblStaffHd.TabIndex = 5;
        lblStaffHd.Text = "担当";
        lblStaffHd.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // txtSupplierCode
        // 
        txtSupplierCode.Dock = DockStyle.Fill;
        txtSupplierCode.Location = new Point(3, 27);
        txtSupplierCode.Name = "txtSupplierCode";
        txtSupplierCode.Size = new Size(74, 23);
        txtSupplierCode.TabIndex = 6;
        txtSupplierCode.Leave += txtSupplierCode_Leave;
        // 
        // lblSupplierName
        // 
        lblSupplierName.BackColor = Color.FromArgb(240, 240, 240);
        lblSupplierName.Dock = DockStyle.Fill;
        lblSupplierName.Location = new Point(83, 24);
        lblSupplierName.Name = "lblSupplierName";
        lblSupplierName.Size = new Size(194, 36);
        lblSupplierName.TabIndex = 7;
        lblSupplierName.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlCarrier
        // 
        pnlCarrier.Controls.Add(lblCarrierName);
        pnlCarrier.Controls.Add(txtCarrierCode);
        pnlCarrier.Dock = DockStyle.Fill;
        pnlCarrier.Location = new Point(283, 27);
        pnlCarrier.Name = "pnlCarrier";
        pnlCarrier.Size = new Size(154, 30);
        pnlCarrier.TabIndex = 8;
        // 
        // lblCarrierName
        // 
        lblCarrierName.BackColor = Color.FromArgb(240, 240, 240);
        lblCarrierName.Dock = DockStyle.Fill;
        lblCarrierName.Location = new Point(50, 0);
        lblCarrierName.Name = "lblCarrierName";
        lblCarrierName.Size = new Size(104, 30);
        lblCarrierName.TabIndex = 0;
        lblCarrierName.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // txtCarrierCode
        // 
        txtCarrierCode.Dock = DockStyle.Left;
        txtCarrierCode.Location = new Point(0, 0);
        txtCarrierCode.Name = "txtCarrierCode";
        txtCarrierCode.Size = new Size(50, 23);
        txtCarrierCode.TabIndex = 1;
        // 
        // txtCarNo
        // 
        txtCarNo.Dock = DockStyle.Fill;
        txtCarNo.Location = new Point(443, 27);
        txtCarNo.Name = "txtCarNo";
        txtCarNo.Size = new Size(114, 23);
        txtCarNo.TabIndex = 9;
        // 
        // pnlPayType
        // 
        pnlPayType.Controls.Add(lblPaymentTypeName);
        pnlPayType.Controls.Add(cmbPaymentType);
        pnlPayType.Dock = DockStyle.Fill;
        pnlPayType.Location = new Point(563, 27);
        pnlPayType.Name = "pnlPayType";
        pnlPayType.Size = new Size(114, 30);
        pnlPayType.TabIndex = 10;
        // 
        // lblPaymentTypeName
        // 
        lblPaymentTypeName.BackColor = Color.FromArgb(240, 240, 240);
        lblPaymentTypeName.Dock = DockStyle.Fill;
        lblPaymentTypeName.Location = new Point(30, 0);
        lblPaymentTypeName.Name = "lblPaymentTypeName";
        lblPaymentTypeName.Size = new Size(84, 30);
        lblPaymentTypeName.TabIndex = 0;
        lblPaymentTypeName.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // cmbPaymentType
        // 
        cmbPaymentType.Dock = DockStyle.Left;
        cmbPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbPaymentType.Location = new Point(0, 0);
        cmbPaymentType.Name = "cmbPaymentType";
        cmbPaymentType.Size = new Size(30, 23);
        cmbPaymentType.TabIndex = 1;
        // 
        // txtStaffCode
        // 
        txtStaffCode.Dock = DockStyle.Fill;
        txtStaffCode.Location = new Point(683, 27);
        txtStaffCode.Name = "txtStaffCode";
        txtStaffCode.Size = new Size(106, 23);
        txtStaffCode.TabIndex = 11;
        // 
        // pnlInitialMeasuredWeight
        // 
        pnlInitialMeasuredWeight.BackColor = Color.FromArgb(245, 245, 250);
        pnlInitialMeasuredWeight.Controls.Add(txtInitialMeasuredWeight);
        pnlInitialMeasuredWeight.Controls.Add(lblInitialMeasuredWeight);
        pnlInitialMeasuredWeight.Dock = DockStyle.Top;
        pnlInitialMeasuredWeight.Location = new Point(4, 160);
        pnlInitialMeasuredWeight.Name = "pnlInitialMeasuredWeight";
        pnlInitialMeasuredWeight.Padding = new Padding(8, 4, 8, 4);
        pnlInitialMeasuredWeight.Size = new Size(792, 56);
        pnlInitialMeasuredWeight.TabIndex = 3;
        // 
        // txtInitialMeasuredWeight
        // 
        txtInitialMeasuredWeight.Font = new Font("メイリオ", 11F);
        txtInitialMeasuredWeight.Location = new Point(29, 27);
        txtInitialMeasuredWeight.Name = "txtInitialMeasuredWeight";
        txtInitialMeasuredWeight.Size = new Size(96, 29);
        txtInitialMeasuredWeight.TabIndex = 1;
        txtInitialMeasuredWeight.TextAlign = HorizontalAlignment.Right;
        txtInitialMeasuredWeight.TextChanged += txtInitialMeasuredWeight_TextChanged;
        txtInitialMeasuredWeight.KeyPress += txtInitialMeasuredWeight_KeyPress;
        txtInitialMeasuredWeight.Leave += txtInitialMeasuredWeight_Leave;
        // 
        // lblInitialMeasuredWeight
        // 
        lblInitialMeasuredWeight.Location = new Point(29, 4);
        lblInitialMeasuredWeight.Name = "lblInitialMeasuredWeight";
        lblInitialMeasuredWeight.Size = new Size(96, 20);
        lblInitialMeasuredWeight.TabIndex = 0;
        lblInitialMeasuredWeight.Text = "初期計測重量";
        lblInitialMeasuredWeight.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // dgvDetails
        // 
        dgvDetails.AllowUserToAddRows = false;
        dgvDetails.AllowUserToDeleteRows = false;
        dgvDetails.BackgroundColor = Color.White;
        dgvDetails.BorderStyle = BorderStyle.None;
        dgvDetails.ColumnHeadersHeight = 36;
        dgvDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dgvDetails.Dock = DockStyle.Fill;
        dgvDetails.Location = new Point(4, 216);
        dgvDetails.MultiSelect = false;
        dgvDetails.Name = "dgvDetails";
        dgvDetails.RowHeadersVisible = false;
        dgvDetails.RowHeadersWidth = 82;
        dgvDetails.RowTemplate.Height = 36;
        dgvDetails.ScrollBars = ScrollBars.Vertical;
        dgvDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDetails.Size = new Size(792, 588);
        dgvDetails.TabIndex = 4;
        // 
        // pnlTotal
        // 
        pnlTotal.BackColor = Color.FromArgb(230, 240, 255);
        pnlTotal.Controls.Add(lblTotalPayment);
        pnlTotal.Controls.Add(lblTotalAmount);
        pnlTotal.Controls.Add(lblTotalCount);
        pnlTotal.Controls.Add(lblTotalQuantity);
        pnlTotal.Controls.Add(lblTotalCaption);
        pnlTotal.Dock = DockStyle.Bottom;
        pnlTotal.Location = new Point(4, 804);
        pnlTotal.Name = "pnlTotal";
        pnlTotal.Size = new Size(792, 36);
        pnlTotal.TabIndex = 5;
        // 
        // lblTotalPayment
        // 
        lblTotalPayment.Font = new Font("メイリオ", 10F, FontStyle.Bold);
        lblTotalPayment.Location = new Point(590, 0);
        lblTotalPayment.Name = "lblTotalPayment";
        lblTotalPayment.Size = new Size(90, 36);
        lblTotalPayment.TabIndex = 0;
        lblTotalPayment.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblTotalAmount
        // 
        lblTotalAmount.Font = new Font("メイリオ", 10F, FontStyle.Bold);
        lblTotalAmount.Location = new Point(495, 0);
        lblTotalAmount.Name = "lblTotalAmount";
        lblTotalAmount.Size = new Size(90, 36);
        lblTotalAmount.TabIndex = 1;
        lblTotalAmount.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblTotalCount
        // 
        lblTotalCount.Font = new Font("メイリオ", 10F, FontStyle.Bold);
        lblTotalCount.Location = new Point(360, 0);
        lblTotalCount.Name = "lblTotalCount";
        lblTotalCount.Size = new Size(60, 36);
        lblTotalCount.TabIndex = 2;
        lblTotalCount.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblTotalQuantity
        // 
        lblTotalQuantity.Font = new Font("メイリオ", 10F, FontStyle.Bold);
        lblTotalQuantity.Location = new Point(265, 0);
        lblTotalQuantity.Name = "lblTotalQuantity";
        lblTotalQuantity.Size = new Size(90, 36);
        lblTotalQuantity.TabIndex = 3;
        lblTotalQuantity.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblTotalCaption
        // 
        lblTotalCaption.Font = new Font("メイリオ", 10F, FontStyle.Bold);
        lblTotalCaption.Location = new Point(0, 0);
        lblTotalCaption.Name = "lblTotalCaption";
        lblTotalCaption.Size = new Size(260, 36);
        lblTotalCaption.TabIndex = 4;
        lblTotalCaption.Text = "【合　計】";
        lblTotalCaption.TextAlign = ContentAlignment.MiddleRight;
        // 
        // pnlButtons
        // 
        pnlButtons.BackColor = Color.FromArgb(245, 245, 245);
        pnlButtons.Controls.Add(btnPrintReceipt);
        pnlButtons.Controls.Add(btnPrintShipping);
        pnlButtons.Controls.Add(btnClear);
        pnlButtons.Controls.Add(btnRegister);
        pnlButtons.Dock = DockStyle.Bottom;
        pnlButtons.Location = new Point(4, 840);
        pnlButtons.Name = "pnlButtons";
        pnlButtons.Size = new Size(792, 70);
        pnlButtons.TabIndex = 6;
        // 
        // btnPrintReceipt
        // 
        btnPrintReceipt.BackColor = Color.FromArgb(150, 80, 0);
        btnPrintReceipt.FlatAppearance.BorderSize = 0;
        btnPrintReceipt.FlatStyle = FlatStyle.Flat;
        btnPrintReceipt.Font = new Font("メイリオ", 14F, FontStyle.Bold);
        btnPrintReceipt.ForeColor = Color.White;
        btnPrintReceipt.Location = new Point(330, 5);
        btnPrintReceipt.Name = "btnPrintReceipt";
        btnPrintReceipt.Size = new Size(180, 60);
        btnPrintReceipt.TabIndex = 0;
        btnPrintReceipt.Text = "検収票印刷";
        btnPrintReceipt.UseVisualStyleBackColor = false;
        btnPrintReceipt.Click += btnPrintReceipt_Click;
        // 
        // btnPrintShipping
        // 
        btnPrintShipping.BackColor = Color.FromArgb(0, 150, 80);
        btnPrintShipping.FlatAppearance.BorderSize = 0;
        btnPrintShipping.FlatStyle = FlatStyle.Flat;
        btnPrintShipping.Font = new Font("メイリオ", 14F, FontStyle.Bold);
        btnPrintShipping.ForeColor = Color.White;
        btnPrintShipping.Location = new Point(520, 5);
        btnPrintShipping.Name = "btnPrintShipping";
        btnPrintShipping.Size = new Size(180, 60);
        btnPrintShipping.TabIndex = 1;
        btnPrintShipping.Text = "仕切書印刷";
        btnPrintShipping.UseVisualStyleBackColor = false;
        btnPrintShipping.Click += btnPrintShipping_Click;
        // 
        // btnClear
        // 
        btnClear.BackColor = Color.FromArgb(100, 100, 100);
        btnClear.FlatAppearance.BorderSize = 0;
        btnClear.FlatStyle = FlatStyle.Flat;
        btnClear.Font = new Font("メイリオ", 14F, FontStyle.Bold);
        btnClear.ForeColor = Color.White;
        btnClear.Location = new Point(200, 5);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(120, 60);
        btnClear.TabIndex = 2;
        btnClear.Text = "クリア";
        btnClear.UseVisualStyleBackColor = false;
        btnClear.Click += btnClear_Click;
        // 
        // btnRegister
        // 
        btnRegister.BackColor = Color.FromArgb(0, 122, 204);
        btnRegister.FlatAppearance.BorderSize = 0;
        btnRegister.FlatStyle = FlatStyle.Flat;
        btnRegister.Font = new Font("メイリオ", 14F, FontStyle.Bold);
        btnRegister.ForeColor = Color.White;
        btnRegister.Location = new Point(10, 5);
        btnRegister.Name = "btnRegister";
        btnRegister.Size = new Size(180, 60);
        btnRegister.TabIndex = 3;
        btnRegister.Text = "仮登録";
        btnRegister.UseVisualStyleBackColor = false;
        btnRegister.Click += btnRegister_Click;
        // 
        // MeasurementTicketForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(800, 914);
        Controls.Add(dgvDetails);
        Controls.Add(pnlInitialMeasuredWeight);
        Controls.Add(tlpSupplier);
        Controls.Add(tlpHeader);
        Controls.Add(lblTitle);
        Controls.Add(pnlTotal);
        Controls.Add(pnlButtons);
        FormBorderStyle = FormBorderStyle.None;
        Name = "MeasurementTicketForm";
        Padding = new Padding(4);
        Text = "ｗお";
        tlpHeader.ResumeLayout(false);
        tlpHeader.PerformLayout();
        pnlBranch.ResumeLayout(false);
        pnlBranch.PerformLayout();
        pnlTransType.ResumeLayout(false);
        tlpSupplier.ResumeLayout(false);
        tlpSupplier.PerformLayout();
        pnlCarrier.ResumeLayout(false);
        pnlCarrier.PerformLayout();
        pnlPayType.ResumeLayout(false);
        pnlInitialMeasuredWeight.ResumeLayout(false);
        pnlInitialMeasuredWeight.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
        pnlTotal.ResumeLayout(false);
        pnlButtons.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.TableLayoutPanel tlpHeader;
    private System.Windows.Forms.Label lblColDate;
    private System.Windows.Forms.Label lblAccDate;
    private System.Windows.Forms.Label lblBranch;
    private System.Windows.Forms.Label lblTransType;
    private System.Windows.Forms.Label lblScaleNo;
    private System.Windows.Forms.DateTimePicker dtpCollectDate;
    private System.Windows.Forms.DateTimePicker dtpAccountDate;
    private System.Windows.Forms.Panel pnlBranch;
    private System.Windows.Forms.TextBox txtBranchCode;
    private System.Windows.Forms.Label lblBranchName;
    private System.Windows.Forms.Panel pnlTransType;
    private System.Windows.Forms.ComboBox cmbTransType;
    private System.Windows.Forms.Label lblTransTypeName;
    private System.Windows.Forms.TextBox txtScaleNo;
    private System.Windows.Forms.TableLayoutPanel tlpSupplier;
    private System.Windows.Forms.Label lblSupplierHd;
    private System.Windows.Forms.Label lblSupplierNameHd;
    private System.Windows.Forms.Label lblCarrierHd;
    private System.Windows.Forms.Label lblCarNoHd;
    private System.Windows.Forms.Label lblPayTypeHd;
    private System.Windows.Forms.Label lblStaffHd;
    private System.Windows.Forms.TextBox txtSupplierCode;
    private System.Windows.Forms.Label lblSupplierName;
    private System.Windows.Forms.Panel pnlCarrier;
    private System.Windows.Forms.TextBox txtCarrierCode;
    private System.Windows.Forms.Label lblCarrierName;
    private System.Windows.Forms.TextBox txtCarNo;
    private System.Windows.Forms.Panel pnlPayType;
    private System.Windows.Forms.ComboBox cmbPaymentType;
    private System.Windows.Forms.Label lblPaymentTypeName;
    private System.Windows.Forms.TextBox txtStaffCode;
    private System.Windows.Forms.Panel pnlInitialMeasuredWeight;
    private System.Windows.Forms.TextBox txtInitialMeasuredWeight;
    private System.Windows.Forms.Label lblInitialMeasuredWeight;
    private System.Windows.Forms.DataGridView dgvDetails;
    private System.Windows.Forms.Panel pnlTotal;
    private System.Windows.Forms.Label lblTotalCaption;
    private System.Windows.Forms.Label lblTotalQuantity;
    private System.Windows.Forms.Label lblTotalCount;
    private System.Windows.Forms.Label lblTotalAmount;
    private System.Windows.Forms.Label lblTotalPayment;
    private System.Windows.Forms.Panel pnlButtons;
    private System.Windows.Forms.Button btnRegister;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button btnPrintShipping;
    private System.Windows.Forms.Button btnPrintReceipt;
}
