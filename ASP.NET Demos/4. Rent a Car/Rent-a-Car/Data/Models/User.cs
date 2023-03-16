using Microsoft.AspNetCore.Identity;

namespace Rent_a_Car.Data.Models
{
	public class User : IdentityUser
	{
		public User()
		{
			this.RentalRequests = new HashSet<RentalData>();
		}

		// Email and Phonenumber come from IdentityUser

		public string FirstName { get; set; } = null!;

		public string MiddleName { get; set; } = null!;

		public string LastName { get; set; } = null!;

        public string EGN { get; set; } = null!;

        public virtual ICollection<RentalData> RentalRequests { get; set; } = null!;
    }
}
