using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class TaskEntryContext : DbContext
    {
        public TaskEntryContext(DbContextOptions<TaskEntryContext> options)
            : base(options)
        {
        }

        public DbSet<TaskEntry> TaskEntry { get; set; }

    }
}
