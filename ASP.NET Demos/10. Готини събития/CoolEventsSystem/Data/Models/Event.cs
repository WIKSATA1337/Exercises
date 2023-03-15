using System.ComponentModel.DataAnnotations;

namespace CoolEventsSystem.Data.Models
{
    public class Event
    {
        [Key]
        public string Id { get; set; } = null!;

        [MaxLength(64)]
        public string Name { get; set; } = null!;

        [MaxLength(255)]
        public string Description { get; set; } = null!;

        public byte[] Image { get; set; } = null!;

        public DateTime EventDate { get; set; }
    }
}
