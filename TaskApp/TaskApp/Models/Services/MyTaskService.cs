using Microsoft.EntityFrameworkCore;
using TaskApp.Data;
using TaskApp.Models.Dtos;
using TaskApp.Models.Interfaces;

namespace TaskApp.Models.Services
{
    public class MyTaskService : IMyTask
    {
        private readonly TaskDbContext _Db;
        public MyTaskService(TaskDbContext Db)
        {
            _Db = Db; 
        }
        public async Task<MyTaskDto> create(CreateMyTask createMyTask,string userId)
        {
            if (createMyTask == null) return null;
            var myTask = (MyTask)createMyTask;
            myTask.UserId = userId;
            myTask.Date= DateTime.Now;  
            await _Db.MyTasks.AddAsync(myTask);
             await _Db.SaveChangesAsync(); 
            
            return (MyTaskDto)myTask;
         }

        public async Task<bool> delete(int id, string userId)
        {
            var mytask = await _Db.MyTasks.FirstOrDefaultAsync(task=> task.MyTaskId==id && task.UserId==userId);
            if (mytask != null)
            {
                _Db.MyTasks.Remove(mytask);
                await _Db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<MyTaskDto>> GetDoneTask(string userId)
        {
            var taskList = await _Db.MyTasks.Select(task=> new MyTaskDto
            {
                MyTaskId = task.MyTaskId,
                TaskName = task.TaskName,
                TaskDescription = task.TaskDescription,
                Date = task.Date,
                MyTaskStatusId = task.MyTaskStatusId,
                UserId = task.UserId,
                 Status = task.Status,  
            })
                .Where(task => task.UserId == userId && task.Status.Name == "Done")
                .OrderBy(task=>task.Date).ToListAsync();

            return taskList;
        }

        public async Task<List<MyTaskDto>> GetOngoningTask(string userId)
        {
            var taskList = await _Db.MyTasks.Select(task => new MyTaskDto
            {
                MyTaskId = task.MyTaskId,
                TaskName = task.TaskName,
                TaskDescription = task.TaskDescription,
                Date = task.Date,
                MyTaskStatusId = task.MyTaskStatusId,
                UserId = task.UserId,
                Status = task.Status,
            })
                            .Where(task => task.UserId == userId && task.Status.Name == "Ongoning")
                            .OrderBy(task => task.Date).ToListAsync();

            return taskList;
        }

        public async Task<UpdateMyTask> GetTask(string userId, int id)
        {
            var task = await _Db.MyTasks.FirstOrDefaultAsync(task => task.MyTaskId == id && task.UserId == userId);
            return (UpdateMyTask)task;
        }

        public async Task<List<MyTaskDto>> GetToDoTask(string userId)
        {
            var taskList = await _Db.MyTasks.Select(task => new MyTaskDto
            {
                MyTaskId = task.MyTaskId,
                TaskName = task.TaskName,
                TaskDescription = task.TaskDescription,
                Date = task.Date,
                MyTaskStatusId = task.MyTaskStatusId,
                UserId = task.UserId,
                Status = task.Status,
            })
                 .Where(task => task.UserId == userId && task.Status.Name == "ToDo")
                 .OrderBy(task => task.Date).ToListAsync();

            return taskList;
        }

        public async Task<List<MyTaskStatus>> TaskStatuses()
        {
            return  await _Db.myTaskStatuses.ToListAsync();
                }

        public async Task<MyTaskDto> Update(UpdateMyTask updateMyTask,string userId)
        {
            if (updateMyTask == null || userId == null) return null;
           
            var task = await _Db.MyTasks.FirstOrDefaultAsync(task=> task.MyTaskId==updateMyTask.MyTaskId && task.UserId==userId);

            


            if (task != null)
            {
                task.TaskName = updateMyTask.TaskName;
                task.TaskDescription = updateMyTask.TaskDescription;
                task.MyTaskStatusId = updateMyTask.MyTaskStatusId;
                _Db.Entry(task).State = EntityState.Modified;
                await _Db.SaveChangesAsync();
                return (MyTaskDto)task;
            }
            return null;
        }
    }
}
