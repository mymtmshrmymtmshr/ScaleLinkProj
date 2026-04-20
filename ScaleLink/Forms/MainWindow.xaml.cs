using ScaleLink.Services;
using System.Windows;
using System.Windows.Controls;

namespace ScaleLink.Forms;

/// <summary>メインウィンドウ</summary>
public partial class MainWindow : Window
{
    private readonly Dictionary<string, (TabItem Tab, WorkspaceForm Workspace)> _workspaces = [];
    private SupplierSelectorForm _supplierSelector = null!;

    public MainWindow()
    {
        InitializeComponent();
        InitializeServices();
        InitializeChildForms();
    }

    private void InitializeServices()
    {
        try
        {
            DatabaseService.Instance.Initialize();
            MasterDataService.Instance.Load();
            // SerialPortService.Instance.Start("COM1");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"初期化エラー:\n{ex.Message}", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void InitializeChildForms()
    {
        _supplierSelector = new SupplierSelectorForm(this);
        supplierSelectorHost.Child = _supplierSelector;
    }

    public WorkspaceForm AddWorkspace(Models.SupplierModel supplier, decimal initialMeasuredWeight)
    {
        var supplierKey = MakeSupplierKey(supplier.Code, supplier.CarNo);
        if (_workspaces.TryGetValue(supplierKey, out var existing))
        {
            workspaceTabs.SelectedItem = existing.Tab;
            return existing.Workspace;
        }

        var workspace = new WorkspaceForm(supplier, _supplierSelector, initialMeasuredWeight);
        var tab = new TabItem
        {
            Header = string.IsNullOrWhiteSpace(supplier.CarNo)
                ? supplier.Name
                : $"{supplier.Name} ({supplier.CarNo})",
            Content = workspace
        };

        workspaceTabs.Items.Add(tab);
        _workspaces[supplierKey] = (tab, workspace);
        workspaceTabs.SelectedItem = tab;
        return workspace;
    }

    public void ActivateWorkspace(string supplierCode)
    {
        var supplierKey = ResolveSupplierKey(supplierCode);
        if (supplierKey is null)
            return;

        if (_workspaces.TryGetValue(supplierKey, out var ws))
            workspaceTabs.SelectedItem = ws.Tab;
    }

    public void RemoveWorkspace(string supplierCode)
    {
        var supplierKey = ResolveSupplierKey(supplierCode);
        if (supplierKey is null)
            return;

        if (!_workspaces.TryGetValue(supplierKey, out var ws))
            return;

        workspaceTabs.Items.Remove(ws.Tab);
        _workspaces.Remove(supplierKey);
    }

    public void RequestClose()
    {
        if (HasUnsavedData())
        {
            var result = MessageBox.Show(
                "入力中のデータがあります。終了しますか？",
                "確認",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;
        }

        Close();
    }

    private bool HasUnsavedData() =>
        _workspaces.Values.Any(x => x.Workspace.HasUnsavedData);

    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
        base.OnClosing(e);
        SerialPortService.Instance.Stop();
        DatabaseService.Instance.Dispose();
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

        return candidates.Count > 0 ? candidates[0] : null;
    }
}
