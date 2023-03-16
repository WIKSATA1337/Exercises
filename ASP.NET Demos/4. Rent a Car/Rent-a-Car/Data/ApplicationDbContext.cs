using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rent_a_Car.Data.Models;

namespace Rent_a_Car.Data
{
	public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

        public override DbSet<User> Users { get; set; } = null!;
        public DbSet<RentalData> RentalData { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
    }
}