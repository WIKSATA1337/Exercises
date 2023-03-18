namespace NoWayOut.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Room
    {
        [Key]
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Location { get; set; } = null!;

        public decimal Price { get; set; }

        public byte[]? Image { get; set; }
    }
}
