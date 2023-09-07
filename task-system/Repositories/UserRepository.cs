using Microsoft.EntityFrameworkCore;
using task_system.Data;
using task_system.Models;
using task_system.Repositories.Interfaces;

namespace task_system.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TasksSystemDBContext _dbContext;
        public UserRepository(TasksSystemDBContext tasksSystemDBContext)
        {
            _dbContext = tasksSystemDBContext;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> Create(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> Update(User user, int id)
        {
            User userBeforeChanges = await GetUserById(id);

            if (userBeforeChanges == null)
            {
                throw new Exception($"User with ID {id} not founded!");
            }

            userBeforeChanges.Name = user.Name;
            userBeforeChanges.Email = user.Email;

            _dbContext.Users.Update(userBeforeChanges);
            await _dbContext.SaveChangesAsync();

            return userBeforeChanges;
        }

        public async Task<bool> Delete(int id)
        {
            User user = await GetUserById(id);

            if (user == null)
            {
                throw new Exception($"User with ID {id} not founded!");
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
