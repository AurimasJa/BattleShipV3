using BattleShipV3.Data.Models;
using BattleShipV3.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleShipV3.Server.Repositories
{
    public interface IUserShipsRepository
    {
        Task CreateUserShipsAsync(UserShip userShip);
        //Task DeleteUserShipsAsync(UserShip userShip);
        Task<IReadOnlyList<UserShip>> GetAllUserShipsAsync();
        //Task UpdateUserShipsAsync(UserShip userShip);
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

        public async Task CreateUserShipsAsync(UserShip userShip)
        {
            _battleshipDbContext.UserShips.Add(userShip);
            await _battleshipDbContext.SaveChangesAsync();
        }

        //Reikia?
        //public async Task UpdateUserShipsAsync(UserShip userShip)
        //{
        //    _battleshipDbContext.UserShips.Update(userShip);
        //    await _battleshipDbContext.SaveChangesAsync();
        //}

        //Reikia?
        //public async Task DeleteUserShipsAsync(UserShip userShip)
        //{
        //    _battleshipDbContext.UserShips.Remove(userShip);
        //    await _battleshipDbContext.SaveChangesAsync();
        //}
    }
}
