using BattleShipV3.Data.Models;
using BattleShipV3.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleShipV3.Server.Repositories
{
    public interface ILeaderboardHistoriesRepository
    {
        Task CreateLeaderboardHistoryAsync(LeaderboardHistory leaderboardHistory);
        Task DeleteLeaderboardHistoryAsync(LeaderboardHistory leaderboardHistory);
        Task<IReadOnlyList<LeaderboardHistory>> GetLeaderboardHistoriesAsync();
        Task<LeaderboardHistory> GetLeaderboardHistoryAsync(int? leaderboardHistoryId);
        Task UpdateLeaderboardHistoryAsync(LeaderboardHistory leaderboardHistory);
    }

    public class LeaderboardHistoriesRepository : ILeaderboardHistoriesRepository
    {
        private readonly BattleshipDbContext _battleshipDbContext;

        public LeaderboardHistoriesRepository(BattleshipDbContext battleshipDbContext)
        {
            _battleshipDbContext = battleshipDbContext;
        }


        public async Task<LeaderboardHistory> GetLeaderboardHistoryAsync(int? leaderboardHistoryId)
        {
            return await _battleshipDbContext
                .LeaderboardHistories
                .Include(e => e.User)
                .FirstOrDefaultAsync(x => x.Id == leaderboardHistoryId);

        }

        public async Task<IReadOnlyList<LeaderboardHistory>> GetLeaderboardHistoriesAsync()
        {
            return await _battleshipDbContext
                .LeaderboardHistories
                .Include(e => e.User)
                .ToListAsync();
        }

        public async Task CreateLeaderboardHistoryAsync(LeaderboardHistory leaderboardHistory)
        {
            _battleshipDbContext.LeaderboardHistories.Add(leaderboardHistory);
            await _battleshipDbContext.SaveChangesAsync();
        }

        public async Task UpdateLeaderboardHistoryAsync(LeaderboardHistory leaderboardHistory)
        {
            _battleshipDbContext.LeaderboardHistories.Update(leaderboardHistory);
            await _battleshipDbContext.SaveChangesAsync();
        }

        public async Task DeleteLeaderboardHistoryAsync(LeaderboardHistory leaderboardHistory)
        {
            _battleshipDbContext.LeaderboardHistories.Remove(leaderboardHistory);
            await _battleshipDbContext.SaveChangesAsync();
        }
    }
}
