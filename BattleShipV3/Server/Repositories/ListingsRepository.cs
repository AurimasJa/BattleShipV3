using BattleShipV3.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleShipV3.Server.Repositories
{
    public interface IListingsRepository
    {
        Task CreateListingAsync(Listing listing);
        Task DeleteListingAsync(Listing listing);
        Task<IReadOnlyList<Listing>> GetAllListingsAsync();
        Task<Listing?> GetListingAsync(int? listingId);
        Task UpdateListingAsync(Listing listing);
    }

    public class ListingsRepository : IListingsRepository
    {
        private readonly BattleshipDbContext _battleshipDbContext;

        public ListingsRepository(BattleshipDbContext battleshipDbContext)
        {
            _battleshipDbContext = battleshipDbContext;
        }

        public async Task<IReadOnlyList<Listing>> GetAllListingsAsync()
        {

            return await _battleshipDbContext.Listings
                .Include(e => e.PlayerOne)
                .Include(e => e.PlayerTwo)
                .ToListAsync();
        }

        public async Task<Listing?> GetListingAsync(int? listingId)
        {
            return await _battleshipDbContext.Listings
                .Include(e => e.PlayerOne)
                .Include(e => e.PlayerTwo)
                .FirstOrDefaultAsync(x => x.Id == listingId);
        }

        public async Task CreateListingAsync(Listing listing)
        {
            _battleshipDbContext.Listings.Add(listing);
            await _battleshipDbContext.SaveChangesAsync();
        }

        public async Task UpdateListingAsync(Listing listing)
        {
            _battleshipDbContext.Listings.Update(listing);
            await _battleshipDbContext.SaveChangesAsync();
        }

        public async Task DeleteListingAsync(Listing listing)
        {
            _battleshipDbContext.Listings.Remove(listing);
            await _battleshipDbContext.SaveChangesAsync();
        }
    }
}
