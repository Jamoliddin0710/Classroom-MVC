namespace Classroom_Task_11._11._22.Entity
{
    public class UserRoom
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public Guid? RoomId { get; set; }
        public ClassRoom? Room { get; set; }
    }
}
