namespace DotNetWebsite.Models
{
	public class UserData
	{

		public int Id { get; set; } = -1;
		public string Username { get; set; } = "Username not found";
		public string Password { get; set; } = "Password not found";
		public DateTime CreationDate { get; set; } = DateTime.Now;

	}
}
