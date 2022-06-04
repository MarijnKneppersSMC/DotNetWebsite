using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DotNetWebsite.Pages.Home
{
	public class ContactUsModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        [Required, MinLength(1)]
        public string FirstName { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        [Required, MinLength(1)]
        public string LastName { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        [Required, Phone]
        public string Telephone { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        [Required]
        public string Address { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        [Required, MinLength(1)]
        public string Message { get; set; } = string.Empty;

        public void OnGet()
        {
        }

		public void OnPost(string firstName, string lastName, string email, string telephone, string address, string message)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Telephone = telephone;
            Address = address;
            Message = message;
        }

    }
}
