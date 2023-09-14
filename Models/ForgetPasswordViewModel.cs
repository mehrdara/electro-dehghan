using System.ComponentModel.DataAnnotations;

namespace identityMVC.Models
{
    public class ForgetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}