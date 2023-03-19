namespace BoilerServicesSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using BoilerServicesSystem.Data.Models.Enums;

    public class ServiceRequest
    {
        [Key]
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string BoilerModel { get; set; } = null!;

        public string Address { get; set; } = null!;

        public byte[]? Image { get; set; }

        public ServiceStatuses Status { get; set; }

        public DateTime? VisitedDate { get; set; }

        public virtual User? TechResponsible { get; set; }
        
        public string CreatedById { get; set; } = null!;
    }
}
