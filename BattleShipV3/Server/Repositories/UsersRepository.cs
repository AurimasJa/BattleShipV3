using BattleShipV3.Models;
using BattleShipV3.Server.Mediator;
using Microsoft.EntityFrameworkCore;


namespace BattleShipV3.Server.Repositories
{
    public interface IUsersRepository
    {
        Task<User> CreateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<IReadOnlyList<User>> GetAllUsersAsync();
        Task<User?> GetUserAsync(int? userId, string? email = null);
        Task UpdateUserAsync(User user);
    }

    public class UsersRepository : BaseComponent, IUsersRepository
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

        public async Task<User?> GetUserAsync(int? userId, string? email = null)
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

        public async Task<User> CreateUserAsync(User user)
        {
            _battleshipDbContext.Users.Add(user);
            await _battleshipDbContext.SaveChangesAsync();
            return user;
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
