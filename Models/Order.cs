using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace identityMVC.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "لطفا نام و نام خانوادگی خود را وارد کنید")]
        [DisplayName("نام و نام خانوادگی")]
        public string Name { get; set; }
        [DisplayName("شماره تلفن ")]
        [Phone]
        [Required(ErrorMessage = "لطفا شماره تلفن خود را وارد کنید")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "لطفا ایمیل  خود را وارد کنید")]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;


    }
}