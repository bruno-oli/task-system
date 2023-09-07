using Microsoft.EntityFrameworkCore;
using task_system.Data.Map;
using task_system.Models;
using Task = task_system.Models.Task;

namespace task_system.Data
{
    public class TasksSystemDBContext : DbContext
    {
        public TasksSystemDBContext(DbContextOptions<TasksSystemDBContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
