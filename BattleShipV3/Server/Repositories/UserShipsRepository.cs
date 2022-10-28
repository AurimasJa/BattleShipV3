using BattleShipV3.Data.Models;
using BattleShipV3.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleShipV3.Server.Repositories
{
    public interface IUserShipsRepository
    {
        Task CreateUserShipsAsync(UserShip userShip);
        Task<IReadOnlyList<UserShip>> GetAllUserShipsAsync();
    }
    public class UserShipsRepository : IUserShipsRepository
    {
        private readonly BattleshipDbContext _battleshipDbContext;

        public UserShipsRepository(BattleshipDbContext battleshipDbContext)
        {
            _battleshipDbContext = battleshipDbContext;
        }

        public async Task<IReadOnlyList<UserShip>> GetAllUserShipsAsync()
        {
            return await _battleshipDbContext.UserShips.ToListAsync();
        }

        //public async Task<User?> GetUserAsync(int? userId, string? email)
        //{
        //    if (userId != null)
        //    {
        //        return await _battleshipDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        //    }
        //    else
        //    {
        //        return await _battleshipDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        //    }
        //}

        public async Task CreateUserShipsAsync(UserShip userShip)
        {
            _battleshipDbContext.UserShips.Add(userShip);
            await _battleshipDbContext.SaveChangesAsync();
        }

        //public async Task UpdateUserAsync(User user)
        //{
        //    _battleshipDbContext.Users.Update(user);
        //    await _battleshipDbContext.SaveChangesAsync();
        //}

        //public async Task DeleteUserAsync(User user)
        //{
        //    _battleshipDbContext.Users.Remove(user);
        //    await _battleshipDbContext.SaveChangesAsync();
        //}
    }
}
