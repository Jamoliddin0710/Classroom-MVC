namespace Classroom_Task_11._11._22.Entity
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime CreatData { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime StartData { get; set; }
        public DateTime EndData { get; set; }
    }
}
