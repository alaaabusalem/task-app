using Microsoft.CodeAnalysis.CSharp.Syntax;
using TaskApp.Models.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TaskApp.Models
{
    public class MyTask
    {

        public int MyTaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime Date{ get; set; }
        // FK 
        public int MyTaskStatusId { get; set; }
        public string UserId { get; set; }

        // navegation prop
        public MyTaskStatus Status { get; set; }
        public ApplicationUser? User { get; set; }


        public static explicit operator MyTask(CreateMyTask task)
        {
            return new MyTask
            {
                TaskName = task.TaskName,
                TaskDescription = task.TaskDescription,
                MyTaskStatusId = task.MyTaskStatusId,

            };
        }

        public static explicit operator MyTask(UpdateMyTask task)
        {
            return new MyTask
            {
                TaskName = task.TaskName,
                TaskDescription = task.TaskDescription,
                MyTaskStatusId = task.MyTaskStatusId,

            };
        }

    }

   
}
