using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Order

    {
        public Order()
        {
            Products = new List<Item>();
        }
        [Key]
        public int Id { get; set; }
        [Display(Name = "لیست محصولات")]
        [Required(ErrorMessage = "لیست محصولات نمیتواند خالی باشد ")]
        public ProductItem PorductItem { get; set; }
        [Required(ErrorMessage = "لطفا نام و نام خانوادگی خود را وارد کنید")]
        public string Name { get; set; }
        public virtual List<Item> Products { get; set; }


    }
}