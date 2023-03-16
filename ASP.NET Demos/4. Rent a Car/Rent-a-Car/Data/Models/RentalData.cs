using System.ComponentModel.DataAnnotations;
using Rent_a_Car.Data.Models.Enums;

namespace Rent_a_Car.Data.Models
{
    public class RentalData
    {
        [Key]
        public string Id { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string CarId { get; set; } = null!;

        public User? RequestedBy { get; set; }

        public decimal FinalPrice { get; set; }

        public RentalStatusEnums Status { get; set; }
    }
}
