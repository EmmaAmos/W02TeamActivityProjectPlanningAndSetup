using Microsoft.EntityFrameworkCore;
using SchdeualMe.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // 2. CHANGED THE TYPE AND PROPERTY NAME TO MATCH YOUR SERVICE LOGIC
    public DbSet<SchdeualModel> Tasks { get; set; } 
}