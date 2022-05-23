using DotNetWebsite.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetWebsite.Pages.Home
{
    public class ContactUsModel : PageModel
    {

        public Person Person = new Person();

        public void OnGet()
        {
        }

		public void OnPost(Person? person)
        {
        }

    }
}
