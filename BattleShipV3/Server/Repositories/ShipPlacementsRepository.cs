//using BattleShipV3.Shared.Data;
//using BattleShipV3.Models;
//using BattleShipV3.Data.Models;
//using Microsoft.EntityFrameworkCore;

//namespace BattleShipV3.Server.Repositories
//{
//    public interface IShipPlacementsRepository
//    {
//        Task CreateShipPlacementAsync(ShipPlacement shipPlacement);
//        Task DeleteShipPlacementAsync(ShipPlacement shipPlacement);
//        Task<IReadOnlyList<ShipPlacement>> GetAllShipPlacementsAsync();
//        Task<ShipPlacement?> GetShipPlacementsAsync(int? shipPlacementId);
//        Task UpdateShipPlacementAsync(ShipPlacement shipPlacement);
//    }

//    public class ShipPlacementsRepository : IShipPlacementsRepository
//    {
//        private readonly BattleshipDbContext _battleshipDbContext;

//        public ShipPlacementsRepository(BattleshipDbContext battleshipDbContext)
//        {
//            _battleshipDbContext = battleshipDbContext;
//        }

//        public async Task<IReadOnlyList<ShipPlacement>> GetAllShipPlacementsAsync()
//        {

//            return await _battleshipDbContext.ShipPlacements.ToListAsync();
//        }

//        public async Task<ShipPlacement?> GetShipPlacementsAsync(int? shipPlacementId)
//        {
//            return await _battleshipDbContext.ShipPlacements
//                .FirstOrDefaultAsync(x => x.Id == shipPlacementId);
//        }

//        public async Task CreateShipPlacementAsync(ShipPlacement shipPlacement)
//        {
//            _battleshipDbContext.ShipPlacements.Add(shipPlacement);
//            await _battleshipDbContext.SaveChangesAsync();
//        }

//        public async Task UpdateShipPlacementAsync(ShipPlacement shipPlacement)
//        {
//            _battleshipDbContext.ShipPlacements.Update(shipPlacement);
//            await _battleshipDbContext.SaveChangesAsync();
//        }

//        public async Task DeleteShipPlacementAsync(ShipPlacement shipPlacement)
//        {
//            _battleshipDbContext.ShipPlacements.Remove(shipPlacement);
//            await _battleshipDbContext.SaveChangesAsync();
//        }
//    }
//}
