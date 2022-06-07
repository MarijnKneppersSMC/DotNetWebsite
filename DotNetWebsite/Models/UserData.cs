using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetWebsite.Models
{
	public class UserData
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Username { get; set; } = "Username not found";
		public string Password { get; set; } = "Password not found";
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime CreationDate { get; set; }

	}
}
