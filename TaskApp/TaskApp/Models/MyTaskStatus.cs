namespace TaskApp.Models
{
    public class MyTaskStatus
    {
        public int MyTaskStatusId { get; set; }
        public string Name { get; set; }

        // nav prop
        public List<MyTask>? Tasks { get; set; }
    }
}
