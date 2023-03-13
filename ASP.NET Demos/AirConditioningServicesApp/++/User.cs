namespace AirConditioningServices.Data.Models;

using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
}
