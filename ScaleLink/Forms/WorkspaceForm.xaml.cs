using ScaleLink.Models;
using System.Windows.Controls;

namespace ScaleLink.Forms;

/// <summary>業者ごとの作業エリアコンテナ</summary>
public partial class WorkspaceForm : UserControl
{
    private readonly SupplierSelectorForm _selector;
    private readonly decimal _initialMeasuredWeight;

    public SupplierModel Supplier { get; }

    private readonly WeightInputForm _weightInput;
    private readonly MeasurementTicketForm _ticketForm;

    public bool HasUnsavedData => _ticketForm.HasUnsavedData;

    public WorkspaceForm(SupplierModel supplier, SupplierSelectorForm selector, decimal initialMeasuredWeight)
    {
        InitializeComponent();

        Supplier = supplier;
        _selector = selector;
        _initialMeasuredWeight = initialMeasuredWeight;

        _ticketForm = new MeasurementTicketForm(Supplier, _selector, _initialMeasuredWeight);
        _ticketForm.RegistrationCompleted += OnRegistrationCompleted;

        var supplierKey = $"{(Supplier.Code ?? string.Empty).Trim()}|{(Supplier.CarNo ?? string.Empty).Trim()}";
        _weightInput = new WeightInputForm(_ticketForm, _selector, supplierKey);

        ticketFormHost.Child = _ticketForm;
        weightInputHost.Child = _weightInput;
    }

    private void OnRegistrationCompleted(object? sender, string supplierCode)
    {
        var supplierKey = $"{(Supplier.Code ?? string.Empty).Trim()}|{(Supplier.CarNo ?? string.Empty).Trim()}";
        _selector.RemoveSupplier(supplierKey);
    }
}
