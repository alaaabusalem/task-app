using TaskApp.Models.Dtos;

namespace TaskApp.Models.Interfaces
{
    public interface IMyTask
    {
        Task<MyTaskDto> create(CreateMyTask createMyTask, string userId);
        Task<MyTaskDto> Update(UpdateMyTask updateMyTask, string userId);
        Task<bool> delete(int id, string userId);
        Task<List<MyTaskDto>> GetToDoTask(string userId);
        Task<List<MyTaskDto>> GetDoneTask(string userId);
        Task<List<MyTaskDto>> GetOngoningTask(string userId);

        Task<UpdateMyTask> GetTask(string userId, int id);
        Task<List<MyTaskStatus>> TaskStatuses();



    }
}
