using Rent_a_Scooter.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Rent_a_Scooter.Data.Models
{
	public class RentalRequest
	{
		[Key]
		public string Id { get; set; } = null!;

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public string ScooterId { get; set; } = null!;

		public User? RequestedBy { get; set; }

		public decimal FinalPrice { get; set; }

		public RentalStatusEnums Status { get; set; }
	}
}
