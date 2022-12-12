using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Telephones.Models
{
    public class Information
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Number Field is required")]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The Name Field is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Email Field is required")]
        [EmailAddress]

        
        public string Email { get; set; }

        private string DataType(DataType emailAddress)
        {
            throw new NotImplementedException();
        }

        public Information()
        {

        }
    }
}
