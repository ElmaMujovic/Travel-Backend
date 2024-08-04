using Microsoft.AspNetCore.Identity;

namespace TravelApp.Models
{
    public class AppRole : IdentityRole<int>
    {
 
        public AppRole(string roleName) : base(roleName) { }
        public AppRole() { }
    }
}
