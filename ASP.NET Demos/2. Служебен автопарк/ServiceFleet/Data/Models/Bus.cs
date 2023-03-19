namespace ServiceFleet.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using ServiceFleet.Data.Models.Enums;

    public class Bus
    {
        [Key]
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Route { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime ArriveDate { get; set; }

        public string BusDriverId { get; set; } = null!;

        public BusStatus Status { get; set; }
    }
}
