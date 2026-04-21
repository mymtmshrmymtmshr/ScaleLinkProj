using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ScaleLink.Forms;

public partial class ShippingDocumentPreviewDialog : Window
{
    public ShippingDocumentPreviewDialog()
    {
        InitializeComponent();
    }

    private void BtnPrint_Click(object sender, RoutedEventArgs e)
    {
        if (picPreview.Source is null)
        {
            MessageBox.Show("印刷対象の画像がありません。", "エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        try
        {
            var printDialog = new PrintDialog();
            if (printDialog.ShowDialog() != true)
                return;

            printDialog.PrintVisual(picPreview, "Shipping document");
            MessageBox.Show("印刷を開始しました。", "完了", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"印刷エラー:\n{ex.Message}", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}
