using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using identityMVC.Models;

public class ProductItem
{
    [Key]
    public int Id { get; set; }


    public int Quantity { get; set; }
    [Display(Name = "Order")]
    public int OrderId { get; set; }
    [Display(Name = "Product")]
    public int PorductId { get; set; }

    [ForeignKey("OrderId")]
    public virtual Order Order { get; set; }
    [ForeignKey("PorductId")]
    public virtual Item Product { get; set; }

    [NotMappedAttribute]

    private decimal _SubTotal;
    [NotMappedAttribute]
    public decimal SubTotal
    {
        get { return _SubTotal; }
        set { _SubTotal = Product.Price * Quantity; }
    }
}