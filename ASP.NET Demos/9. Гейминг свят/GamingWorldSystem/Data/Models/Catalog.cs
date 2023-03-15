using System.ComponentModel.DataAnnotations;

namespace GamingWorldSystem.Data.Models
{
    public class Catalog
    {
        public Catalog()
        {
            this.Games = new HashSet<Game>();
        }

        [Key]
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public virtual ICollection<Game> Games { get; set; }

        public string CreatedBy { get; set; } = null!;
    }
}
