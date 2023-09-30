using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
public class Item
{
    [Key]
    public int Id { get; set; }
    [MaxLength(20)]
    [DisplayName("نام محصول")]
    [Required(ErrorMessage = "لطفا نام محصول را وارد کنید")]
    public string Name { get; set; } = "نام محصول";
    [Required(ErrorMessage = "لطفا توضیحات محصول را وارد کنید")]
    [DisplayName("توضیحات")]

    public string Description { get; set; } = "توضیحات";
    [Required]
    [DisplayName("قیمت")]

    [Range(10000, 10000000, ErrorMessage = "قیمت باید بین ۱۰ هزار تا ۱۰ میلیون تومان باشد")]
    public int Price { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = " موجودی محصول نمیتواند کمتر از ۱ باشد")]
    [DisplayName("موجودی")]
    public int Quantity { get; set; }
    public string ImageName { get; set; } = "file";
    [NotMappedAttribute]
    [DisplayName("Upload file")]
    public IFormFile? ImageFile { get; set; }

}