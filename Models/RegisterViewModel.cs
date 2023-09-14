using System.ComponentModel.DataAnnotations;
namespace identityMVC.Models

{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "the{0}should be at least{2} characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation don't match")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Name { get; set; }
    }
}