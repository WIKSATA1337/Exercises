namespace MovieWorld.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	public class Catalog
	{
		public Catalog()
		{
			this.Movies = new HashSet<Movie>();
		}

        [Key]
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

		public string Description { get; set; } = null!;

        public string CreatedBy { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
