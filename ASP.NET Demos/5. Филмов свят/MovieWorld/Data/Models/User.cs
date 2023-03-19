namespace MovieWorld.Data.Models
{
	using Microsoft.AspNetCore.Identity;

	public class User : IdentityUser
	{
		public User()
		{
		}

		public string FirstName { get; set; } = null!;

		public string LastName { get; set; } = null!;
    }
}
