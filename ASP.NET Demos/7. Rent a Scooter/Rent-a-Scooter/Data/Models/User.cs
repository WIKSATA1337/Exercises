using Microsoft.AspNetCore.Identity;

namespace Rent_a_Scooter.Data.Models
{
	public class User : IdentityUser
	{
		public User()
		{
		}

		// Email and Phonenumber come from IdentityUser

		public string FirstName { get; set; } = null!;

		public string LastName { get; set; } = null!;
    }
}
