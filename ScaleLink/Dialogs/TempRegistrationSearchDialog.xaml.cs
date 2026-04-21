using System.Windows;
using System.Windows.Input;

namespace ScaleLink.Dialogs;

public partial class TempRegistrationSearchDialog : Window
{
    public TempRegistrationSearchResult? SelectedRegistration { get; private set; }

    public TempRegistrationSearchDialog()
    {
        InitializeComponent();
        InitializeSearchConditions();
    }

    private void InitializeSearchConditions()
    {
        dtpCollectDateFrom.SelectedDate = DateTime.Today.AddDays(-7);
        dtpCollectDateTo.SelectedDate = DateTime.Today;
        dtpAccountDateFrom.SelectedDate = DateTime.Today.AddDays(-7);
        dtpAccountDateTo.SelectedDate = DateTime.Today;
    }

    private void BtnSearch_Click(object sender, RoutedEventArgs e)
    {
        SearchTempRegistrations();
    }

    private void BtnClear_Click(object sender, RoutedEventArgs e)
    {
        txtCarNo.Clear();
        txtSupplierCode.Clear();
        InitializeSearchConditions();
        dgvResults.ItemsSource = Array.Empty<TempRegistrationSearchResult>();
    }

    private void SearchTempRegistrations()
    {
        try
        {
            var suppliers = Services.MasterDataService.Instance.Suppliers;
            if (suppliers.Count == 0)
            {
                MessageBox.Show("取引先マスタが登録されていません。", "エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var random = new Random();
            var baseDate = DateTime.Today;
            var results = new List<TempRegistrationSearchResult>();

            for (int i = 0; i < 10; i++)
            {
                var supplier = suppliers[random.Next(suppliers.Count)];
                var collectDate = baseDate.AddDays(-random.Next(0, 30));
                var accountDate = collectDate.AddDays(random.Next(0, 3));
                var scaleNo = random.Next(100000, 999999).ToString();
                var carNo = string.IsNullOrWhiteSpace(supplier.CarNo) ? $"{random.Next(1000, 9999)}" : supplier.CarNo;

                results.Add(new TempRegistrationSearchResult
                {
                    TicketId = 1000 + i,
                    CollectDate = collectDate,
                    AccountDate = accountDate,
                    SupplierCode = supplier.Code,
                    SupplierName = supplier.Name,
                    CarNo = carNo,
                    ScaleNo = scaleNo
                });
            }

            dgvResults.ItemsSource = results;

            if (results.Count == 0)
                MessageBox.Show("検索条件に該当するデータがありません。", "検索結果", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"検索エラー:\n{ex.Message}", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void DgvResults_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        AcceptSelection();
    }

    private void BtnOk_Click(object sender, RoutedEventArgs e)
    {
        AcceptSelection();
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    private void AcceptSelection()
    {
        if (dgvResults.SelectedItem is TempRegistrationSearchResult result)
        {
            SelectedRegistration = result;
            DialogResult = true;
            Close();
            return;
        }

        MessageBox.Show("検索結果を選択してください。", "確認", MessageBoxButton.OK, MessageBoxImage.Warning);
    }
}

public class TempRegistrationSearchResult
{
    public long TicketId { get; set; }
    public DateTime CollectDate { get; set; }
    public DateTime AccountDate { get; set; }
    public string SupplierCode { get; set; } = string.Empty;
    public string SupplierName { get; set; } = string.Empty;
    public string CarNo { get; set; } = string.Empty;
    public string ScaleNo { get; set; } = string.Empty;
}
