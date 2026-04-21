using Microsoft.Data.Sqlite;
using ScaleLink.Models;
using ScaleLink.Services;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ScaleLink.Forms;

/// <summary>計量票入力フォーム</summary>
public partial class MeasurementTicketForm : UserControl
{
    private readonly SupplierModel _supplier;
    private readonly SupplierSelectorForm _selector;
    private decimal _initialMeasuredWeight;

    public event EventHandler<string>? RegistrationCompleted;
    public bool HasUnsavedData => Rows.Any(r => !string.IsNullOrWhiteSpace(r.Code));

    private const int MaxRows = 12;

    public ObservableCollection<MeasurementRow> Rows { get; } = [];

    public MeasurementTicketForm(SupplierModel supplier, SupplierSelectorForm selector, decimal initialMeasuredWeight)
    {
        InitializeComponent();

        _supplier = supplier;
        _selector = selector;
        _initialMeasuredWeight = initialMeasuredWeight;

        InitializeGrid();
        SetSupplierDefaults();

        txtSupplierCode.LostFocus += (_, _) => SupplierCodeLeave();
        dgvDetails.CellEditEnding += (_, _) => Dispatcher.BeginInvoke(RecalcAllRows);
    }

    private void InitializeGrid()
    {
        dgvDetails.ItemsSource = Rows;

        for (int i = 0; i < MaxRows; i++)
            Rows.Add(new MeasurementRow { No = i + 1 });
    }

    private void SetSupplierDefaults()
    {
        dtpCollectDate.SelectedDate = DateTime.Today;
        dtpAccountDate.SelectedDate = DateTime.Today;
        txtSupplierCode.Text = _supplier.Code;
        lblSupplierName.Text = _supplier.Name;
        txtScaleNo.Text = "1";
        SetInitialMeasuredWeight(_initialMeasuredWeight);
        RecalcAllRows();
    }

    public bool SetDetail(ProductModel product, decimal measuredWeight)
    {
        var row = Rows.FirstOrDefault(r => string.IsNullOrWhiteSpace(r.Code));
        if (row is null)
            return false;

        row.MeasuredWeightText = measuredWeight.ToString("#,##0.0");
        row.Code = product.Code;
        row.ProductName = product.Name;
        row.UnitPriceText = product.UnitPrice.ToString("#,##0.00");
        row.PaymentUnitPrice = product.PaymentUnitPrice;

        RecalcAllRows();
        dgvDetails.Items.Refresh();
        return true;
    }

    private void TxtInitialMeasuredWeight_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (decimal.TryParse(txtInitialMeasuredWeight.Text, out var initialMeasuredWeight))
            _initialMeasuredWeight = Math.Round(initialMeasuredWeight, 0, MidpointRounding.AwayFromZero);

        RecalcAllRows();
    }

    private void SetInitialMeasuredWeight(decimal weight)
    {
        _initialMeasuredWeight = Math.Round(weight, 0, MidpointRounding.AwayFromZero);
        txtInitialMeasuredWeight.Text = _initialMeasuredWeight.ToString("#,##0");
    }

    private void RecalcAllRows()
    {
        if (!decimal.TryParse(txtInitialMeasuredWeight.Text, out var previousMeasuredWeight))
        {
            ClearCalculatedValues();
            RecalcTotals();
            dgvDetails.Items.Refresh();
            return;
        }

        foreach (var row in Rows)
        {
            if (string.IsNullOrWhiteSpace(row.Code) || !decimal.TryParse(row.MeasuredWeightText, out var measuredWeight))
            {
                row.QuantityText = string.Empty;
                row.AmountText = string.Empty;
                row.PaymentText = string.Empty;
                continue;
            }

            var quantity = previousMeasuredWeight - measuredWeight;
            row.QuantityText = quantity.ToString("#,##0.0");

            decimal.TryParse(row.UnitPriceText, out var unitPrice);
            var amount = Math.Floor(quantity * unitPrice);
            row.AmountText = amount.ToString("#,##0");

            var paymentUnitPrice = row.PaymentUnitPrice ?? unitPrice;
            var payment = Math.Floor(quantity * paymentUnitPrice);
            row.PaymentText = payment.ToString("#,##0");

            previousMeasuredWeight = measuredWeight;
        }

        RecalcTotals();
        dgvDetails.Items.Refresh();
    }

    private void ClearCalculatedValues()
    {
        foreach (var row in Rows)
        {
            row.QuantityText = string.Empty;
            row.AmountText = string.Empty;
            row.PaymentText = string.Empty;
        }
    }

    private void RecalcTotals()
    {
        decimal totalQty = 0, totalAmount = 0, totalPayment = 0;
        int totalCount = 0;

        foreach (var row in Rows)
        {
            decimal.TryParse(row.QuantityText, out var qty);
            int.TryParse(row.CountText, out var cnt);
            decimal.TryParse(row.AmountText, out var amt);
            decimal.TryParse(row.PaymentText, out var pay);
            totalQty += qty;
            totalCount += cnt;
            totalAmount += amt;
            totalPayment += pay;
        }

        lblTotalQuantity.Text = totalQty.ToString("#,##0.0");
        lblTotalCount.Text = totalCount.ToString("#,##0");
        lblTotalAmount.Text = totalAmount.ToString("#,##0");
        lblTotalPayment.Text = totalPayment.ToString("#,##0");
    }

    private void BtnRegister_Click(object sender, RoutedEventArgs e)
    {
        if (Rows.Count(r => !string.IsNullOrWhiteSpace(r.Code)) == 0)
        {
            RegistrationCompleted?.Invoke(this, _supplier.Code);
            return;
        }

        try
        {
            SaveToDatabase();
            MessageBox.Show("登録が完了しました。", "完了", MessageBoxButton.OK, MessageBoxImage.Information);
            RegistrationCompleted?.Invoke(this, _supplier.Code);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"登録エラー:\n{ex.Message}", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void SaveToDatabase()
    {
        var conn = DatabaseService.Instance.Connection;
        using var tx = conn.BeginTransaction();

        decimal.TryParse(lblTotalQuantity.Text, out var tq);
        int.TryParse(lblTotalCount.Text, out var tc);
        decimal.TryParse(lblTotalAmount.Text, out var ta);
        decimal.TryParse(lblTotalPayment.Text, out var tp);
        decimal.TryParse(txtInitialMeasuredWeight.Text, out var initialMeasuredWeight);

        using var cmdH = conn.CreateCommand();
        cmdH.Transaction = tx;
        cmdH.CommandText = """
            INSERT INTO t_measurement_ticket
              (collect_date,account_date,branch_code,transaction_type,scale_no,
               supplier_code,carrier_code,car_no,payment_type,staff_code,
               initial_measured_weight,total_quantity,total_count,total_amount,total_payment)
            VALUES($cd,$ad,$bc,$tt,$sn,$sc,$cc,$cn,$pt,$stf,$imw,$tq,$tc,$ta,$tp);
            """;

        cmdH.Parameters.AddWithValue("$cd", (dtpCollectDate.SelectedDate ?? DateTime.Today).ToString("yyyy-MM-dd"));
        cmdH.Parameters.AddWithValue("$ad", (dtpAccountDate.SelectedDate ?? DateTime.Today).ToString("yyyy-MM-dd"));
        cmdH.Parameters.AddWithValue("$bc", txtBranchCode.Text);
        cmdH.Parameters.AddWithValue("$tt", ((ComboBoxItem)cmbTransType.SelectedItem)?.Content?.ToString() ?? "");
        cmdH.Parameters.AddWithValue("$sn", txtScaleNo.Text);
        cmdH.Parameters.AddWithValue("$sc", txtSupplierCode.Text);
        cmdH.Parameters.AddWithValue("$cc", "");
        cmdH.Parameters.AddWithValue("$cn", "");
        cmdH.Parameters.AddWithValue("$pt", "");
        cmdH.Parameters.AddWithValue("$stf", "");
        cmdH.Parameters.AddWithValue("$imw", initialMeasuredWeight);
        cmdH.Parameters.AddWithValue("$tq", tq);
        cmdH.Parameters.AddWithValue("$tc", tc);
        cmdH.Parameters.AddWithValue("$ta", ta);
        cmdH.Parameters.AddWithValue("$tp", tp);
        cmdH.ExecuteNonQuery();

        using var cmdId = conn.CreateCommand();
        cmdId.Transaction = tx;
        cmdId.CommandText = "SELECT last_insert_rowid()";
        long ticketId = (long)(cmdId.ExecuteScalar() ?? 0L);

        foreach (var row in Rows.Where(r => !string.IsNullOrWhiteSpace(r.Code)))
        {
            decimal.TryParse(row.MeasuredWeightText, out var measuredWeight);
            decimal.TryParse(row.QuantityText, out var qty);
            int.TryParse(row.CountText, out var cnt);
            decimal.TryParse(row.UnitPriceText, out var up);
            decimal.TryParse(row.AmountText, out var amt);
            decimal.TryParse(row.PaymentText, out var pay);

            using var cmdD = conn.CreateCommand();
            cmdD.Transaction = tx;
            cmdD.CommandText = """
                INSERT INTO t_measurement_detail
                  (ticket_id,no,measured_weight,code,product_name,quantity,count,unit_price,amount,payment)
                VALUES($tid,$no,$mw,$cd,$pn,$qty,$cnt,$up,$amt,$pay);
                """;

            cmdD.Parameters.AddWithValue("$tid", ticketId);
            cmdD.Parameters.AddWithValue("$no", row.No);
            cmdD.Parameters.AddWithValue("$mw", measuredWeight);
            cmdD.Parameters.AddWithValue("$cd", row.Code);
            cmdD.Parameters.AddWithValue("$pn", row.ProductName);
            cmdD.Parameters.AddWithValue("$qty", qty);
            cmdD.Parameters.AddWithValue("$cnt", cnt);
            cmdD.Parameters.AddWithValue("$up", up);
            cmdD.Parameters.AddWithValue("$amt", amt);
            cmdD.Parameters.AddWithValue("$pay", pay);
            cmdD.ExecuteNonQuery();
        }

        tx.Commit();
    }

    private void BtnClear_Click(object sender, RoutedEventArgs e)
    {
        if (HasUnsavedData)
        {
            if (MessageBox.Show("入力内容をクリアしますか？", "確認", MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
                return;
        }

        foreach (var row in Rows)
        {
            row.MeasuredWeightText = string.Empty;
            row.Code = string.Empty;
            row.ProductName = string.Empty;
            row.QuantityText = string.Empty;
            row.CountText = string.Empty;
            row.UnitPriceText = string.Empty;
            row.AmountText = string.Empty;
            row.PaymentText = string.Empty;
            row.PaymentUnitPrice = null;
        }

        RecalcTotals();
        dgvDetails.Items.Refresh();
    }

    private void BtnPrintShipping_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new ShippingDocumentPreviewDialog();
        dialog.ShowDialog();
    }

    private void BtnPrintReceipt_Click(object sender, RoutedEventArgs e)
    {
        var exePath = AppDomain.CurrentDomain.BaseDirectory;
        var imageFilePath = Path.Combine(exePath, "Resources", "receipt_template.png");

        if (!File.Exists(imageFilePath))
        {
            using var sampleImage = CreateSampleReceiptImage();
            var dialog = new ReceiptPreviewDialog(sampleImage);
            dialog.ShowDialog();
            return;
        }

        var fileDialog = new ReceiptPreviewDialog(imageFilePath);
        fileDialog.ShowDialog();
    }

    private void BtnSalesManagementLink_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("販売管理連携は未実装です。", "情報", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private System.Drawing.Image CreateSampleReceiptImage()
    {
        var bitmap = new System.Drawing.Bitmap(800, 1000);
        using var g = System.Drawing.Graphics.FromImage(bitmap);

        g.Clear(System.Drawing.Color.White);
        g.DrawRectangle(System.Drawing.Pens.Black, 10, 10, 780, 980);

        using var titleFont = new System.Drawing.Font("メイリオ", 24, System.Drawing.FontStyle.Bold);
        using var contentFont = new System.Drawing.Font("メイリオ", 12);

        g.DrawString("検 収 票", titleFont, System.Drawing.Brushes.Black, new System.Drawing.PointF(300, 30));
        g.DrawString("車番: " + (_supplier.CarNo ?? ""), contentFont, System.Drawing.Brushes.Black, new System.Drawing.PointF(30, 100));
        g.DrawString("取引先: " + _supplier.Name, contentFont, System.Drawing.Brushes.Black, new System.Drawing.PointF(30, 130));
        g.DrawString("集計日: " + (dtpCollectDate.SelectedDate ?? DateTime.Today).ToString("yyyy/MM/dd"), contentFont, System.Drawing.Brushes.Black, new System.Drawing.PointF(30, 160));

        return bitmap;
    }

    private void SupplierCodeLeave()
    {
        var found = MasterDataService.Instance.Suppliers.FirstOrDefault(s => s.Code == txtSupplierCode.Text);
        lblSupplierName.Text = found?.Name ?? string.Empty;
    }

    public void MoveDetailFocusToNextRow()
    {
        // WPF DataGrid では自動フォーカス遷移を簡略化
    }

    public class MeasurementRow
    {
        public int No { get; set; }
        public string MeasuredWeightText { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string QuantityText { get; set; } = string.Empty;
        public string CountText { get; set; } = string.Empty;
        public string UnitPriceText { get; set; } = string.Empty;
        public string AmountText { get; set; } = string.Empty;
        public string PaymentText { get; set; } = string.Empty;
        public decimal? PaymentUnitPrice { get; set; }
    }
}
