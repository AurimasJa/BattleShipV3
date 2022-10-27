using BattleShipV3.Models;
using Microsoft.EntityFrameworkCore;


namespace BattleShipV3.Server.Repositories
{
    public interface IUsersRepository
    {
        Task CreateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<IReadOnlyList<User>> GetAllUsersAsync();
        Task<User?> GetUserAsync(int? userId, string? email);
        Task UpdateUserAsync(User user);
    }

    public class UsersRepository : IUsersRepository
    {
        private readonly BattleshipDbContext _battleshipDbContext;

        public UsersRepository(BattleshipDbContext battleshipDbContext)
        {
            _battleshipDbContext = battleshipDbContext;
        }

        public async Task<IReadOnlyList<User>> GetAllUsersAsync()
        {
            return await _battleshipDbContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserAsync(int? userId, string? email)
        {
            if(userId != null)
            {
                return await _battleshipDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            }
            else
            {
                return await _battleshipDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            }
        }

        public async Task CreateUserAsync(User user)
        {
            _battleshipDbContext.Users.Add(user);
            await _battleshipDbContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _battleshipDbContext.Users.Update(user);
            await _battleshipDbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _battleshipDbContext.Users.Remove(user);
            await _battleshipDbContext.SaveChangesAsync();
        }
    }
}
