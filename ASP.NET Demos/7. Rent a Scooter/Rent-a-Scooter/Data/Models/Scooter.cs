using System.ComponentModel.DataAnnotations;

namespace Rent_a_Scooter.Data.Models
{
    public class Scooter
	{
		[Key]
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public decimal RentalPricePerDay { get; set; }
    }
}
