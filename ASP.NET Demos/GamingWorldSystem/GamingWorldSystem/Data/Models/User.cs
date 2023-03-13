using Microsoft.AspNetCore.Identity;

namespace GamingWorldSystem.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Catalogs = new HashSet<Catalog>();
        }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public virtual ICollection<Catalog> Catalogs { get; set; }
    }
}
