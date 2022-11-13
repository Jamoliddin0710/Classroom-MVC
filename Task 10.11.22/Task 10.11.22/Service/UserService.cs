using Microsoft.AspNetCore.Identity;

namespace Task_10._11._22.Service
{
    public class UserService
    {
        public List<IdentityUser> Users { get; set; }
        
        public UserService()
        {
            Users = new List<IdentityUser>();
        }
    }
}
