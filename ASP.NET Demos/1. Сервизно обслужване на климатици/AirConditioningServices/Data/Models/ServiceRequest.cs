using System.ComponentModel.DataAnnotations;
using AirConditioningServices.Data.Models.Enums;

namespace AirConditioningServices.Data.Models
{
    public class ServiceRequest
    {
        [Key]
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Address { get; set; } = null!;

        public byte[]? Image { get; set; }

        public ServiceStatuses Status { get; set; }

        public DateTime? VisitedDate { get; set; }

        public string CreatedById { get; set; } = null!;

        public virtual User? TechResponsible { get; set; }
    }
}
