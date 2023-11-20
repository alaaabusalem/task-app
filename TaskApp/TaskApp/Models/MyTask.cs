namespace TaskApp.Models
{
    public class MyTask
    {

        public int MyTaskId { get; set; }
        public string TaskName { get; set; }
        public int TaskDescription { get; set; }
        public DateTime Date{ get; set; }
        // FK 
        public int MyTaskStatusId { get; set; }
        public string UserId { get; set; }

        // navegation prop
        public MyTaskStatus Status { get; set; }
        public ApplicationUser? User { get; set; }

    }
}
