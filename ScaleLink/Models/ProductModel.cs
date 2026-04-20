namespace ScaleLink.Models;

/// <summary>商品モデル</summary>
public class ProductModel
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public decimal PaymentUnitPrice { get; set; }
    public bool IsFrequent { get; set; }
}
