using ScaleLink.Models;
using ScaleLink.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ScaleLink.Forms;

/// <summary>重量表示・商品選択フォーム</summary>
public partial class WeightInputForm : UserControl
{
    private readonly MeasurementTicketForm _ticketForm;
    private readonly SupplierSelectorForm _selector;
    private readonly string _supplierCode;
    private ProductModel? _selectedProduct;
    private bool _isManualMode;

    private sealed class ProductListItem(ProductModel product)
    {
        public ProductModel Product { get; } = product;
        public override string ToString() => Product.Name;
    }

    public WeightInputForm(MeasurementTicketForm ticketForm, SupplierSelectorForm selector, string supplierCode)
    {
        InitializeComponent();

        _ticketForm = ticketForm;
        _selector = selector;
        _supplierCode = supplierCode;

        LoadProductButtons();
        SubscribeWeightEvents();

        txtManualWeight.PreviewTextInput += (_, e) =>
        {
            if (!e.Text.All(c => char.IsDigit(c) || c == '.'))
                e.Handled = true;
        };
    }

    private void LoadProductButtons()
    {
        lstFrequentProducts.Items.Clear();
        lstOtherProducts.Items.Clear();

        foreach (var p in MasterDataService.Instance.FrequentProducts)
            lstFrequentProducts.Items.Add(new ProductListItem(p));

        foreach (var p in MasterDataService.Instance.OtherProducts)
            lstOtherProducts.Items.Add(new ProductListItem(p));
    }

    private void LstFrequentProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (lstFrequentProducts.SelectedItem is ProductListItem item)
        {
            lstOtherProducts.SelectedItem = null;
            SelectProduct(item.Product);
        }
    }

    private void LstOtherProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (lstOtherProducts.SelectedItem is ProductListItem item)
        {
            lstFrequentProducts.SelectedItem = null;
            SelectProduct(item.Product);
        }
    }

    private void SelectProduct(ProductModel product)
    {
        _selectedProduct = product;
        _selector.UpdateSupplierState(_supplierCode, SupplierButtonState.Weighing);
    }

    private void BtnConfirmWeight_Click(object sender, RoutedEventArgs e)
    {
        if (_selectedProduct is null)
        {
            MessageBox.Show("商品を選択してください。", "確認", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        decimal weight;
        if (_isManualMode)
        {
            if (!decimal.TryParse(txtManualWeight.Text, out weight) || weight <= 0)
            {
                MessageBox.Show("重量は数値で入力してください。", "入力エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
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

            weight = SerialPortService.Instance.LastWeight;
            if (weight <= 0)
            {
                MessageBox.Show("重量が0です。計量を確認してください。", "確認", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        if (!_ticketForm.SetDetail(_selectedProduct, weight))
        {
            MessageBox.Show("明細行が満杯です。登録してください。", "満杯", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        _ticketForm.MoveDetailFocusToNextRow();
        ClearProductSelection();
        txtManualWeight.Text = string.Empty;
        SetManualMode(false);
        _selector.UpdateSupplierState(_supplierCode, SupplierButtonState.Inputting);
    }

    private void BtnNumPad_Click(object sender, RoutedEventArgs e)
    {
        OpenNumPadForManualWeight(sender as Button);
    }

    private void OpenNumPadForManualWeight(Button? anchor = null, string? initialValue = null)
    {
        SetManualMode(true);
        var numPad = new Dialogs.NumPadForm(initialValue ?? txtManualWeight.Text);

        if (anchor != null)
        {
            numPad.WindowStartupLocation = WindowStartupLocation.Manual;

            // ボタン直下の画面座標（物理ピクセル → DIP変換）
            var source = PresentationSource.FromVisual(anchor);
            double dpiX = source?.CompositionTarget?.TransformToDevice.M11 ?? 1.0;
            double dpiY = source?.CompositionTarget?.TransformToDevice.M22 ?? 1.0;

            var ptBottom = anchor.PointToScreen(new Point(0, anchor.ActualHeight));
            var ptTop    = anchor.PointToScreen(new Point(0, 0));

            double left = ptBottom.X / dpiX;
            double top  = ptBottom.Y / dpiY;

            double w = numPad.Width;
            double h = numPad.Height;

            double screenRight  = SystemParameters.WorkArea.Right;
            double screenBottom = SystemParameters.WorkArea.Bottom;
            double screenTop    = SystemParameters.WorkArea.Top;

            // 右端補正
            if (left + w > screenRight)
                left = screenRight - w;

            // 下端補正：はみ出す場合はボタン上に表示
            if (top + h > screenBottom)
                top = ptTop.Y / dpiY - h;

            // 上端補正
            if (top < screenTop)
                top = screenTop;

            numPad.Left = left;
            numPad.Top  = top;
        }

        if (numPad.ShowDialog() == true)
            txtManualWeight.Text = numPad.InputValue;
    }

    private void ClearProductSelection()
    {
        _selectedProduct = null;
        lstFrequentProducts.SelectedItem = null;
        lstOtherProducts.SelectedItem = null;
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

        if (_isManualMode)
            return;

        lblCurrentWeight.Text = e.Weight.ToString("#,##0.0");
        (lblWeightStatus.Text, lblWeightStatus.Foreground) = e.Status switch
        {
            WeightStatus.Stable => ("● 安定", Brushes.LimeGreen),
            WeightStatus.Unstable => ("▲ 計量中", Brushes.Orange),
            WeightStatus.Error => ("? 受信エラー", Brushes.Red),
            WeightStatus.Disconnected => ("─ 未接続", Brushes.Gray),
            _ => ("─ 未接続", Brushes.Gray),
        };

        btnConfirmWeight.IsEnabled = e.Status == WeightStatus.Stable;
    }

    private void SetManualMode(bool manual)
    {
        _isManualMode = manual;
        txtManualWeight.IsEnabled = manual;
        btnConfirmWeight.IsEnabled = true;

        if (manual)
        {
            lblWeightStatus.Text = "● 手入力モード";
            lblWeightStatus.Foreground = Brushes.Cyan;
        }
    }
}
