using task_system.Models;

namespace task_system.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> Create(User user);
        Task<User> Update(User user, int id);
        Task<bool> Delete(int id);
    }
}
