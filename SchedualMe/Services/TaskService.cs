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
    public async Task<List<SchedualModel>> GetAllTasksAsync()
    {
        return await _context.Tasks.ToListAsync();
    }
    public async Task<SchedualModel?> GetTaskByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    // --- CREATE ---
    public async Task AddTaskAsync(SchedualModel task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
    }

    // --- UPDATE ---
    public async Task UpdateTaskAsync(SchedualModel updatedTask)
    {
        _context.Tasks.Update(updatedTask);
        await _context.SaveChangesAsync();
    }

    public async Task MarkAsCompleteAsync(int id, bool isComplete)
    {
        var task = await GetTaskByIdAsync(id);
        if (task != null)
        {
            task.IsComplete = isComplete;
            await UpdateTaskAsync(task);
        }
    }

    // --- DELETE ---
    public async Task DeleteTaskAsync(int id)
    {
        var task = await GetTaskByIdAsync(id);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}
