using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = task_system.Models.Task;

namespace task_system.Data.Map
{
    public class TaskMap : IEntityTypeConfiguration<Task>
    {
        void IEntityTypeConfiguration<Task>.Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
