namespace ScaleLink.Models;

/// <summary>Œv—Ê•[–¾×ƒ‚ƒfƒ‹</summary>
public class MeasurementDetailModel
{
    public int No { get; set; }
    public string Code { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public int Count { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Amount { get; set; }
    public decimal Payment { get; set; }
}
