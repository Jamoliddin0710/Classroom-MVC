namespace Classroom_Task_11._11._22.Entity
{
    public class ClassRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRoom> Users { get; set; }
    }
}
