using System.ComponentModel.DataAnnotations;

public class ProductItem
{
    [Key]
    public int Id { get; set; }
    public Item Product { get; set; }
    public int Quantity { get; set; }
    private decimal _SubTotal;

    public decimal SubTotal
    {
        get { return _SubTotal; }
        set { _SubTotal = Product.Price * Quantity; }
    }
}