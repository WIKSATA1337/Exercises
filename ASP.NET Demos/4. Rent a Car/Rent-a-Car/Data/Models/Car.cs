using System.ComponentModel.DataAnnotations;

namespace Rent_a_Car.Data.Models
{
    public class Car
    {

        [Key]
        public string Id { get; set; } = null!;

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public DateTime YearManufactured { get; set; }

        public int PassengerSeats { get; set; }

        public string Description { get; set; } = null!;

        public decimal RentalPricePerDay { get; set; }

        public byte[]? Image { get; set; }
    }
}
