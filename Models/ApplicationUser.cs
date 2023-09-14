using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace identityMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

    }
}