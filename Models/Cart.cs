using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
public class Cart
{
    [Key]
    public int Id { get; set; }
    public ICollection<Item> Item { get; }
}