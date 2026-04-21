using ScaleLink.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace ScaleLink.Forms;

/// <summary>仕入業者選択パネル</summary>
public partial class SupplierSelectorForm : UserControl
{
    private readonly MainWindow _mainForm;
    private readonly Dictionary<string, WorkspaceForm> _workspaces = [];
    private readonly Dictionary<string, Button> _buttons = [];
    private string _selectedSupplierCode = string.Empty;

    public SupplierSelectorForm(MainWindow mainForm)
    {
        _mainForm = mainForm;
        InitializeComponent();
    }

    private void BtnAdd_Click(object sender, RoutedEventArgs e)
    {
        var dlg = new Dialogs.SupplierSelectDialog();
        if (dlg.ShowDialog() != true || dlg.SelectedSupplier is null)
            return;

        var supplier = dlg.SelectedSupplier;
        var supplierKey = MakeSupplierKey(supplier.Code, supplier.CarNo);
        if (_workspaces.ContainsKey(supplierKey))
        {
            SwitchTo(supplierKey);
            return;
        }

        var weightDialog = new Dialogs.InitialWeightDialog();
        if (weightDialog.ShowDialog() != true)
            return;

        AddSupplier(supplier, weightDialog.ConfirmedWeight);
    }

    private void BtnTempRecall_Click(object sender, RoutedEventArgs e)
    {
        var dlg = new Dialogs.TempRegistrationSearchDialog();
        if (dlg.ShowDialog() != true || dlg.SelectedRegistration is null)
            return;

        var result = dlg.SelectedRegistration;

        var supplier = Services.MasterDataService.Instance.Suppliers
            .FirstOrDefault(s => s.Code == result.SupplierCode);

        if (supplier is null)
        {
            MessageBox.Show(
                $"取引先コード '{result.SupplierCode}' が見つかりません。\nマスタデータを確認してください。",
                "エラー",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            return;
        }

        supplier = new SupplierModel
        {
            Code = supplier.Code,
            Name = supplier.Name,
            CarNo = result.CarNo
        };

        var supplierKey = MakeSupplierKey(supplier.Code, supplier.CarNo);
        if (_workspaces.ContainsKey(supplierKey))
        {
            SwitchTo(supplierKey);
            MessageBox.Show("選択された仮登録データは既に開いています。", "情報", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        AddSupplier(supplier, 2000);
    }

    private void BtnExit_Click(object sender, RoutedEventArgs e)
    {
        _mainForm.RequestClose();
    }

    public void AddSupplier(SupplierModel supplier, decimal initialMeasuredWeight)
    {
        var supplierKey = MakeSupplierKey(supplier.Code, supplier.CarNo);

        var ws = _mainForm.AddWorkspace(supplier, initialMeasuredWeight);
        _workspaces[supplierKey] = ws;

        var btn = CreateSupplierButton(supplier, supplierKey);
        _buttons[supplierKey] = btn;
        pnlList.Children.Add(btn);

        lblEmpty.Visibility = Visibility.Collapsed;
        SwitchTo(supplierKey);
    }

    public void RemoveSupplier(string supplierCode)
    {
        var supplierKey = ResolveSupplierKey(supplierCode);
        if (supplierKey is null)
            return;

        if (_buttons.Remove(supplierKey, out var btn))
            pnlList.Children.Remove(btn);

        _workspaces.Remove(supplierKey);
        _mainForm.RemoveWorkspace(supplierKey);

        if (_selectedSupplierCode == supplierKey)
            _selectedSupplierCode = string.Empty;

        if (_workspaces.Count > 0)
            SwitchTo(_workspaces.Keys.First());
        else
            lblEmpty.Visibility = Visibility.Visible;
    }

    public void SwitchTo(string supplierCode)
    {
        var supplierKey = ResolveSupplierKey(supplierCode);
        if (supplierKey is null || _selectedSupplierCode == supplierKey)
            return;

        if (_buttons.TryGetValue(_selectedSupplierCode, out var prev))
            UpdateButtonState(prev, SupplierButtonState.Waiting);

        _selectedSupplierCode = supplierKey;

        if (_buttons.TryGetValue(supplierKey, out var cur))
            UpdateButtonState(cur, SupplierButtonState.Selected);

        _mainForm.ActivateWorkspace(supplierKey);
    }

    public void UpdateSupplierState(string supplierCode, SupplierButtonState state)
    {
        var supplierKey = ResolveSupplierKey(supplierCode);
        if (supplierKey is null || supplierKey == _selectedSupplierCode)
            return;

        if (_buttons.TryGetValue(supplierKey, out var btn))
            UpdateButtonState(btn, state);
    }

    private Button CreateSupplierButton(SupplierModel supplier, string supplierKey)
    {
        var carNo = (supplier.CarNo ?? string.Empty).Trim();
        var btn = new Button
        {
            Content = string.IsNullOrWhiteSpace(carNo) ? supplier.Name : carNo,
            Height = 80,
            Width = 125,
            Margin = new Thickness(0, 0, 0, 3),
            FontWeight = FontWeights.Bold,
            FontSize = 14,
            FontFamily = new FontFamily("Meiryo UI"),
            Background = Brushes.Gray,
            Foreground = Brushes.White,
            BorderThickness = new Thickness(0),
            HorizontalContentAlignment = HorizontalAlignment.Center,
            VerticalContentAlignment = VerticalAlignment.Center,
            Tag = supplierKey
        };

        btn.Click += (_, _) => SwitchTo(supplierKey);
        AttachLongPress(btn, supplierKey);
        return btn;
    }

    private void AttachLongPress(Button btn, string supplierCode)
    {
        DispatcherTimer? pressTimer = null;

        btn.PreviewMouseLeftButtonDown += (_, _) =>
        {
            pressTimer?.Stop();
            pressTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1500) };
            pressTimer.Tick += (_, _) =>
            {
                pressTimer?.Stop();
                pressTimer = null;
                ConfirmAndRemove(supplierCode);
            };
            pressTimer.Start();
        };

        btn.PreviewMouseLeftButtonUp += (_, _) =>
        {
            pressTimer?.Stop();
            pressTimer = null;
        };
    }

    private void ConfirmAndRemove(string supplierCode)
    {
        if (!_workspaces.TryGetValue(supplierCode, out var ws))
            return;

        var message = ws.HasUnsavedData
            ? "入力中のデータが失われます。削除しますか？"
            : "この業者を削除しますか？";

        if (MessageBox.Show(message, "確認", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            RemoveSupplier(supplierCode);
    }

    private static void UpdateButtonState(Button btn, SupplierButtonState state)
    {
        btn.Background = state switch
        {
            SupplierButtonState.Weighing => Brushes.SteelBlue,
            SupplierButtonState.Inputting => Brushes.RoyalBlue,
            SupplierButtonState.Selected => Brushes.DodgerBlue,
            _ => Brushes.Gray,
        };
    }

    private static string MakeSupplierKey(string code, string? carNo) =>
        $"{(code ?? string.Empty).Trim()}|{(carNo ?? string.Empty).Trim()}";

    private string? ResolveSupplierKey(string supplierCodeOrKey)
    {
        if (string.IsNullOrWhiteSpace(supplierCodeOrKey))
            return null;

        if (_workspaces.ContainsKey(supplierCodeOrKey))
            return supplierCodeOrKey;

        if (supplierCodeOrKey.Contains('|'))
            return null;

        var code = supplierCodeOrKey.Trim();
        var candidates = _workspaces.Keys
            .Where(k => k.StartsWith(code + "|", StringComparison.Ordinal))
            .ToList();

        if (candidates.Count == 1)
            return candidates[0];

        if (candidates.Count > 1)
            return !string.IsNullOrWhiteSpace(_selectedSupplierCode) && candidates.Contains(_selectedSupplierCode)
                ? _selectedSupplierCode
                : candidates[0];

        return null;
    }
}

/// <summary>業者ボタンの状態</summary>
public enum SupplierButtonState
{
    Waiting,
    Weighing,
    Inputting,
    Selected,
}
