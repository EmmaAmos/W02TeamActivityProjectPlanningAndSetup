// Services/ITaskService.cs

using SchedualMe.Models;

public interface ITaskService
{
    // READ
    Task<List<SchedualModel>> GetAllTasksAsync();
    Task<SchedualModel?> GetTaskByIdAsync(int id);

    // CREATE
    Task AddTaskAsync(SchedualModel task);

    // UPDATE
    Task UpdateTaskAsync(SchedualModel task);

    // UPDATE (specific case)
    Task MarkAsCompleteAsync(int id, bool isComplete);

    // DELETE
    Task DeleteTaskAsync(int id);
}