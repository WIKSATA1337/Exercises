namespace AirConditioningServices.Data.Models;

using System.ComponentModel.DataAnnotations;
using AirConditioningServices.Data.Models.Enums;

public class ServiceRequest
{
    [Key]
    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [MaxLength(150)]
    public string Description { get; set; } = null!;

    [MaxLength(50)]
    public string Address { get; set; } = null!;

    public byte[]? ImageData { get; set; }

    public RequestStatusEnum Status { get; set; }

    public DateTime? TechVisitedDate { get; set; }

    public virtual User? TechResponsible { get; set; }
}
