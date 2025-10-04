// Services/ITaskService.cs

public interface ITaskService
{
    // READ
    Task<List<SchdeualModel>> GetAllTasksAsync();
    Task<SchdeualModel?> GetTaskByIdAsync(int id);

    // CREATE
    Task AddTaskAsync(SchdeualModel task);

    // UPDATE
    Task UpdateTaskAsync(SchdeualModel task);
    
    // UPDATE (specific case)
    Task MarkAsCompleteAsync(int id, bool isComplete);

    // DELETE
    Task DeleteTaskAsync(int id);
}