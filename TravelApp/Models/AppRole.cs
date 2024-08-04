using Microsoft.AspNetCore.Identity;

namespace Travel.Models
{
    public class AppRole : IdentityRole<int>
    {
 
        public AppRole(string roleName) : base(roleName) { }
        public AppRole() { }
    }
}
