using System.Drawing.Printing;

namespace ScaleLink.Forms;

/// <summary>検収票プレビューダイアログ</summary>
public partial class ReceiptPreviewDialog : Form
{
    public ReceiptPreviewDialog(Image receiptImage)
    {
        InitializeComponent();
    }

    public ReceiptPreviewDialog(string imageFilePath)
    {
        InitializeComponent();
    }
}
