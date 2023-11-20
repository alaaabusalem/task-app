using System.ComponentModel.DataAnnotations;

namespace TaskApp.Models.Dtos
{
    public class MyTaskDto
    {
        public int MyTaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime Date { get; set; }
        // FK 
        public int MyTaskStatusId { get; set; }
        public string UserId { get; set; }

        // navegation prop
        public MyTaskStatus Status { get; set; }

        public static explicit operator MyTaskDto(MyTask task)
        {
            return new MyTaskDto
            {
                MyTaskId=task.MyTaskId,
                TaskName = task.TaskName,
                TaskDescription = task.TaskDescription,
                Date = task.Date,
                MyTaskStatusId = task.MyTaskStatusId,
                UserId=task.UserId
            };
        }

    }

    public class CreateMyTask
    {

        [Required]
        public string TaskName { get; set; }
        [Required]

        public string TaskDescription { get; set; }
       
        [Required]


        public int MyTaskStatusId { get; set; }

        [Required]

        public List<MyTaskStatus> Tasks { get; set; }
       

    }

    public class UpdateMyTask
    {
        [Required]
        public int MyTaskId { get; set; }

        [Required]
        public string TaskName { get; set; }

        [Required]
        public string TaskDescription { get; set; }

        [Required]
        public int MyTaskStatusId { get; set; }

        [Required]
        public List<MyTaskStatus> Tasks { get; set; }

        public static explicit operator UpdateMyTask(MyTask task)
        {
            return new UpdateMyTask
            {
                MyTaskId = task.MyTaskId,
                TaskName = task.TaskName,
                TaskDescription = task.TaskDescription,
                MyTaskStatusId = task.MyTaskStatusId,
            };
        }


    }
}
