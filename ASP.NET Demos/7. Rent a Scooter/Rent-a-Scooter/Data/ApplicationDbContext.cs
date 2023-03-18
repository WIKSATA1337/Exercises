using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rent_a_Scooter.Data.Models;

namespace Rent_a_Scooter.Data
{
	public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public override DbSet<User> Users { get; set; } = null!;
		public DbSet<RentalRequest> RentalRequests { get; set; } = null!;
		public DbSet<Scooter> Scooters { get; set; } = null!;
	}
}