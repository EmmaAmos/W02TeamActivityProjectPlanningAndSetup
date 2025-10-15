// Services/TaskService.cs

using Microsoft.EntityFrameworkCore;
using SchedualMe.Models; // The 'using' directive for your model

// 1. File-Scoped Namespace (Note the semicolon; no curly braces needed for the namespace)
namespace SchedualMe.Services;

public class TaskService : ITaskService
{
    private readonly ApplicationDbContext _context;

    // Dependency Injection: gets the context from the DI container
    public TaskService(ApplicationDbContext context)
    {
        _context = context;
    }

    // --- READ ---
    public async Task<List<SchedualModel>> GetAllTasksAsync(string userId)
{
    // Only return tasks where the UserId column matches the logged-in user's ID
    return await _context.Tasks
        .Where(t => t.UserId == userId) 
        .ToListAsync();
}

public async Task<SchedualModel?> GetTaskByIdAsync(string userId, int id)
{
    // Only fetch the task if both the ID AND the UserID match
    return await _context.Tasks
        .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
}

    // --- CREATE ---
public async Task AddTaskAsync(string userId, SchedualModel task)
{
    // Assign the logged-in user's ID to the new task before saving
    task.UserId = userId; 
    _context.Tasks.Add(task);
    await _context.SaveChangesAsync();
}

// --- UPDATE: Verify ownership before saving changes ---
    public async Task UpdateTaskAsync(string userId, SchedualModel updatedTask)
    {
        // 1. Fetch the task using the secure GetTaskByIdAsync
        // This ensures only the owner can even attempt to update it.
        var existingTask = await GetTaskByIdAsync(userId, updatedTask.Id); 

        if (existingTask != null)
        {
            // 2. Update properties only on the securely fetched task
            existingTask.Title = updatedTask.Title;
            existingTask.Description = updatedTask.Description;
            existingTask.IsComplete = updatedTask.IsComplete;
            existingTask.Category = updatedTask.Category; // Add any other fields you want to update

            // The context tracks changes to existingTask, so we just save
            await _context.SaveChangesAsync();
        }
    // If existingTask is null, the user doesn't own it or it doesn't exist, and nothing happens.
    }

    public async Task MarkAsCompleteAsync(string userId, int id, bool isComplete)
    {
        // Use the secure GetTaskByIdAsync
        var task = await GetTaskByIdAsync(userId, id); 
        
        if (task != null)
        {
            task.IsComplete = isComplete;
            // Directly save changes, no need to call UpdateTaskAsync if just toggling one field
            await _context.SaveChangesAsync(); 
        }
    }

    // --- DELETE: Verify ownership before deleting ---
    public async Task DeleteTaskAsync(string userId, int id)
    {
        // Use the secure GetTaskByIdAsync to verify ownership
        var task = await GetTaskByIdAsync(userId, id); 

        if (task != null)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}
