// Services/ITaskService.cs

using SchedualMe.Models;

public interface ITaskService
{
 // READ: Must filter by user ID
    Task<List<SchedualModel>> GetAllTasksAsync(string userId);

    // READ: Must verify ownership by user ID
    Task<SchedualModel?> GetTaskByIdAsync(string userId, int id);

    // CREATE: Must assign the user ID to the new task
    Task AddTaskAsync(string userId, SchedualModel task);

    // UPDATE: Must verify ownership by user ID before updating
    Task UpdateTaskAsync(string userId, SchedualModel updatedTask);

    // UPDATE (specific case): Must verify ownership by user ID before updating
    Task MarkAsCompleteAsync(string userId, int id, bool isComplete);

    // DELETE: Must verify ownership by user ID before deleting
    Task DeleteTaskAsync(string userId, int id);
}