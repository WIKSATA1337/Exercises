using Microsoft.AspNetCore.Identity;

namespace AirConditioningServices.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.ServiceRequests = new HashSet<ServiceRequest>();
        }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}
