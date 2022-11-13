using Classroom_Task_11._11._22.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = Classroom_Task_11._11._22.Entity.Task;

namespace Classroom_Task_11._11._22.Context
{
    public class UserDbContext : IdentityDbContext
    {

        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRoom> UserRooms { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
