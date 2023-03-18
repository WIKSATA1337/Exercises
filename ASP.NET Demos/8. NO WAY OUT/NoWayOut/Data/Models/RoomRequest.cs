namespace NoWayOut.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using NoWayOut.Data.Models.Enums;

    public class RoomRequest
    {
        [Key]
        public string Id { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public User? RequestedBy { get; set; }

        public decimal FinalPrice { get; set; }

        public RoomStatus Status { get; set; }
    }
}