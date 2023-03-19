namespace BoilerServicesSystem.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using BoilerServicesSystem.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

        public override DbSet<User> Users { get; set; } = null!;

        public DbSet<ServiceRequest> ServiceRequests { get; set; } = null!;
    }
}