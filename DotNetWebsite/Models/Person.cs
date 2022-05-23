using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotNetWebsite.Models
{
	#pragma warning disable CS8618
    public class Person
    {
        [BindProperty]
        [Required]
        public string FirstName { get; set; }

        [BindProperty]
        [Required]
        public string LastName { get; set; }

        [BindProperty]
        [Required, EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [Required, Phone]
        public string Telephone { get; set; }

        [BindProperty]
		[Required]
        public string Address { get; set; }

        [BindProperty]
		[Required]
        public string Message { get; set; }
    }
}
#pragma warning restore
