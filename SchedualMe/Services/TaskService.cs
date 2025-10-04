// Services/TaskService.cs

using Microsoft.EntityFrameworkCore;

public class TaskService : ITaskService
{
    private readonly ApplicationDbContext _context;

    // Dependency Injection: gets the context from the DI container
    public TaskService(ApplicationDbContext context)
    {
        _context = context;
    }

    // --- READ ---
    public async Task<List<SchdeualModel>> GetAllTasksAsync()
    {
        return await _context.Tasks.ToListAsync(); // Corrected to ToListAsync()
    }
    public async Task<SchdeualModel?> GetTaskByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    // --- CREATE ---
    public async Task AddTaskAsync(SchdeualModel task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
    }

    // --- UPDATE ---
    public async Task UpdateTaskAsync(SchdeualModel updatedTask)
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