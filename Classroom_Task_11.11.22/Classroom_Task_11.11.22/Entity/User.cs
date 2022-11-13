using Microsoft.AspNetCore.Identity;

namespace Classroom_Task_11._11._22.Entity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long chatId { get; set; }
        public ushort Step { get; set; }
        public string PhotoUrl { get; set; }

    }
}
