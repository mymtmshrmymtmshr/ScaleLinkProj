using ScaleLink.Models;
using ScaleLink.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ScaleLink.Dialogs;

/// <summary>取引先選択ダイアログ</summary>
public partial class SupplierSelectDialog : Window
{
    public SupplierModel? SelectedSupplier { get; private set; }

    public SupplierSelectDialog()
    {
        InitializeComponent();

        // デバッグ: データ件数確認
        var count = MasterDataService.Instance.Suppliers.Count;
        if (count == 0)
        {
            MessageBox.Show(
                "取引先データがロードされていません。\nSuppliers.csvファイルを確認してください。",
                "警告",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }

        BindSuppliers();
    }

    private void TxtNameFilter_TextChanged(object sender, TextChangedEventArgs e)
    {
        BindSuppliers();
    }

    private void TxtCarNoFilter_TextChanged(object sender, TextChangedEventArgs e)
    {
        BindSuppliers();
    }

    private void BindSuppliers()
    {
        var suppliers = MasterDataService.Instance.Suppliers.AsEnumerable();

        var nameFilter = txtNameFilter.Text.Trim();
        var carNoFilter = txtCarNoFilter.Text.Trim();

        // 取引先名またはコードでフィルタ
        if (!string.IsNullOrEmpty(nameFilter))
        {
            suppliers = suppliers.Where(x => 
                (!string.IsNullOrEmpty(x.Name) && x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase)) ||
                (!string.IsNullOrEmpty(x.Code) && x.Code.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase))
            );
        }

        // 車番でフィルタ
        if (!string.IsNullOrEmpty(carNoFilter))
        {
            suppliers = suppliers.Where(x => 
                !string.IsNullOrEmpty(x.CarNo) && x.CarNo.Contains(carNoFilter, StringComparison.CurrentCultureIgnoreCase)
            );
        }

        suppliers = suppliers.OrderBy(x => x.Code);

        dgvSuppliers.ItemsSource = suppliers.ToList();
    }

    private void DgvSuppliers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
        if (dgvSuppliers.SelectedItem is SupplierModel supplier)
        {
            SelectedSupplier = supplier;
            DialogResult = true;
            Close();
            return;
        }

        MessageBox.Show("取引先を選択してください。", "確認", MessageBoxButton.OK, MessageBoxImage.Warning);
    }
}
