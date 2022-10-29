using BattleShipV3.Data;
using BattleShipV3.Data.Models;
using BattleShipV3.Models;
using BattleShipV3.Server.Repositories;
using BattleShipV3.Shared.Data.Commands.Listing.Get;
using Microsoft.AspNetCore.Mvc;

namespace BattleShipV3.Server.Controllers;
[ApiController]
[Route("[controller]")]
public class LeaderboardHistoriesController : ControllerBase
{
    private readonly ILeaderboardHistoriesRepository _leaderboardHistoriesRepository;
    private readonly IUsersRepository _usersRepository;

    public LeaderboardHistoriesController(ILeaderboardHistoriesRepository leaderboardHistoriesRepository, IUsersRepository usersRepository)
    {
        _leaderboardHistoriesRepository = leaderboardHistoriesRepository;
        _usersRepository = usersRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetLeaderboardHistoryCommand>> GetLeaderboardHistoryAsync(int? id)
    {
        var leaderboardHistory = await _leaderboardHistoriesRepository.GetLeaderboardHistoryAsync(id);
        if (leaderboardHistory == null)
            return NotFound($"Game Match does not exist"); //????? ?

        return new GetLeaderboardHistoryCommand(leaderboardHistory.Id, leaderboardHistory.DateFrom, leaderboardHistory.DateTo, leaderboardHistory.User);
    }
    [HttpGet]
    public async Task<IEnumerable<GetLeaderboardHistoryCommand>> GetLeaderboardHistoriesAsync()
    {
        var leaderboardHistories = await _leaderboardHistoriesRepository.GetLeaderboardHistoriesAsync();
        return leaderboardHistories.Select(x => new GetLeaderboardHistoryCommand(x.Id, x.DateFrom, x.DateTo, x.User));
    }

    [HttpPost]
    public async Task<ActionResult<GetLeaderboardHistoryCommand>> CreateLeaderboardHistoryAsync(CreateLeaderboardHistoryCommand createLeaderboardHistoryCommand)
    {
        if (createLeaderboardHistoryCommand == null)
        {
            return BadRequest("Error");
        }
        var user = await _usersRepository.GetUserAsync(createLeaderboardHistoryCommand.User.Id);

        var leaderboard = new LeaderboardHistory
        {
            DateFrom = createLeaderboardHistoryCommand.DateFrom,
            DateTo = createLeaderboardHistoryCommand.DateTo,
            User = user
        };

        await _leaderboardHistoriesRepository.CreateLeaderboardHistoryAsync(leaderboard);
        return Created("", new GetLeaderboardHistoryCommand(leaderboard.Id, leaderboard.DateFrom, leaderboard.DateTo, leaderboard.User));
    }

    [HttpPut]
    [Route("{leaderboardHistoryId}")]
    public async Task<ActionResult<GetLeaderboardHistoryCommand>> UpdateLeaderboardHistoryAsync(int leaderboardHistoryId, UpdateLeaderboardHistoryCommand updateLeaderboardHistoryCommand)
    {

        var leaderboardHistory = await _leaderboardHistoriesRepository.GetLeaderboardHistoryAsync(leaderboardHistoryId);
        var user = await _usersRepository.GetUserAsync(updateLeaderboardHistoryCommand.User.Id);

        if (leaderboardHistory == null)
            return NotFound($"No game match with id of {leaderboardHistoryId}");

        //neveikia keistas error
       // updateLeaderboardHistoryCommand.DateFrom = updateLeaderboardHistoryCommand.DateFrom > updateLeaderboardHistoryCommand.DateFrom ? leaderboardHistory.DateFrom : updateLeaderboardHistoryCommand.DateFrom;
       // updateLeaderboardHistoryCommand.DateTo = updateLeaderboardHistoryCommand.DateTo < updateLeaderboardHistoryCommand.DateFrom ? leaderboardHistory.User : updateLeaderboardHistoryCommand.DateTo;
      //  updateLeaderboardHistoryCommand.User = updateLeaderboardHistoryCommand.User is null ? user : user; //useri updeitinti!@!@!@!@!@!@

        await _leaderboardHistoriesRepository.UpdateLeaderboardHistoryAsync(leaderboardHistory);

        return Ok(new GetLeaderboardHistoryCommand(leaderboardHistory.Id, leaderboardHistory.DateFrom, leaderboardHistory.DateTo, leaderboardHistory.User));
    }

    [HttpDelete("{leaderboardHistoryId}")]
    public async Task<ActionResult> RemoveLeaderboardHistoryAsync(int leaderboardHistoryId)
    {
        var leaderboardHistory = await _leaderboardHistoriesRepository.GetLeaderboardHistoryAsync(leaderboardHistoryId);

        // 404
        if (leaderboardHistory == null)
            return NotFound($"No game match with id of {leaderboardHistoryId}"); ;

        await _leaderboardHistoriesRepository.DeleteLeaderboardHistoryAsync(leaderboardHistory);


        // 204
        return NoContent();
    }
}
