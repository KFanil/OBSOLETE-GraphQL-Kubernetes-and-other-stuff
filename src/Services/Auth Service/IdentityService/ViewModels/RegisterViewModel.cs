using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Lastname { get; set; }

        private string username;

        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Username { get
            {
                return Firstname + " " + Lastname;
            }
        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Password { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Confirmpassword { get; set; }
    }
}