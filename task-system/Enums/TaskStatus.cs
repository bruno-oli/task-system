using System.ComponentModel;

namespace task_system.Enums
{
    public enum TaskStatus
    {
        [Description("To Do")]
        ToDo = 1,
        [Description("In Progress")]
        InProgress = 2,
        [Description("Completeed")]
        Completed = 3,
    }
}
