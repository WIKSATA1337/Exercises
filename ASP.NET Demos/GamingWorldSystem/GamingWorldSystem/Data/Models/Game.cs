using System.ComponentModel.DataAnnotations;

namespace GamingWorldSystem.Data.Models
{
    public class Game
    {
        public Game()
        {
            this.Catalogs = new HashSet<Catalog>();
        }

        [Key]
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public byte[] Image { get; set; } = null!;

        public DateTime PremierDate { get; set; }

        public virtual ICollection<Catalog> Catalogs { get; set; }
    }
}
