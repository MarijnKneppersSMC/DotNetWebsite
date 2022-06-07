using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using DotNetWebsite.Data;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

namespace DotNetWebsite.Pages.Account
{

    public class RegisterModel : PageModel
    {
		[BindProperty]
		[Required, StringLength(250, MinimumLength = 1)]
		public string Username {get;set;} = string.Empty;

		[BindProperty]
		[Required, StringLength(250, MinimumLength = 1)]
		public string Password {get;set;} = string.Empty;

		[BindProperty]
		[Required, Compare("Password", ErrorMessage ="Password and Confirmation Password must match.")]
    	public string ConfirmPassword {get;set; } = string.Empty;

		[BindProperty]
		public bool Taken {get;set;} = false;

		private DatabaseContext context;

		public RegisterModel(DatabaseContext _context)
		{
			context = _context;
		}

        public void OnGet()
        {
        }

		public void OnPost(string username, string password)
		{
			Username = username;
			Password = password;

			if(ModelState.IsValid)
			{
				if(context.Users.Where((user) => user.Username.ToLower() == username.ToLower()).ToArray().Length != 0)
				{
					Taken = true;
					return;
				}

				string hashedPassword = Utility.ComputeSha256Hash(password);

				context.Users.Add(new Models.UserData(){ Username = username, Password = hashedPassword});
				context.SaveChanges();
			}
		}
    }
}
