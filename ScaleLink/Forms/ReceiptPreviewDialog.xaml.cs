using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using DrawingImage = System.Drawing.Image;

namespace ScaleLink.Forms;

public partial class ReceiptPreviewDialog : Window
{
    public ReceiptPreviewDialog(DrawingImage receiptImage)
    {
        InitializeComponent();
        imgPreview.Source = ToBitmapSource(receiptImage);
    }

    public ReceiptPreviewDialog(string imageFilePath)
    {
        InitializeComponent();

        if (!File.Exists(imageFilePath))
            throw new FileNotFoundException("Image file not found.", imageFilePath);

        using var img = DrawingImage.FromFile(imageFilePath);
        imgPreview.Source = ToBitmapSource((DrawingImage)img.Clone());
    }

    private void BtnPrint_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new PrintDialog();
        if (dialog.ShowDialog() != true)
            return;

        dialog.PrintVisual(imgPreview, "Receipt");
    }

    private static BitmapSource ToBitmapSource(DrawingImage image)
    {
        using var memory = new MemoryStream();
        image.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
        memory.Position = 0;

        var bitmap = new BitmapImage();
        bitmap.BeginInit();
        bitmap.CacheOption = BitmapCacheOption.OnLoad;
        bitmap.StreamSource = memory;
        bitmap.EndInit();
        bitmap.Freeze();

        return bitmap;
    }
}
