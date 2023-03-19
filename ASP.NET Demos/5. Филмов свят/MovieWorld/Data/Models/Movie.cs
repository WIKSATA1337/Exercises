namespace MovieWorld.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	public class Movie
	{
		[Key]
		public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

		public string Description { get; set; } = null!;

		public DateTime PremiereDate { get; set; }

        public byte[]? Image { get; set; }
    }
}
