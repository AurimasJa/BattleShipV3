using BattleShipV3.Client.Pages.GameMatches;
using BattleShipV3.Data;
using BattleShipV3.Models;
using BattleShipV3.Server.Repositories;
using BattleShipV3.Shared.Data.Commands.Listing.Create;
using BattleShipV3.Shared.Data.Commands.Listing.Get;
using BattleShipV3.Shared.Data.Commands.Listing.Update;
using Microsoft.AspNetCore.Mvc;

namespace BattleShipV3.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class GameMatchesController : ControllerBase
{

    private readonly IListingsRepository _listingsRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly IGameMatchesRepository _gameMatchesRepository;

    public GameMatchesController(IListingsRepository listingsRepository, IUsersRepository usersRepository, IGameMatchesRepository gameMatchesRepository)
    {
        _listingsRepository = listingsRepository;
        _usersRepository = usersRepository;
        _gameMatchesRepository = gameMatchesRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GameMatch>> GetGameMatchAsync(int? id)
    {
        var gameMatch = await _gameMatchesRepository.GetGameMatchAsync(id);
        if (gameMatch == null)
            return NotFound($"Game Match does not exist");

        return new GameMatch
        {
            Id = gameMatch.Id,
            CreationDate = gameMatch.CreationDate,
            GameState = gameMatch.GameState,
            Listing = gameMatch.Listing,
            User = gameMatch.User
        };
    }
    [HttpGet]
    public async Task<IEnumerable<GameMatch>> GetGameMatchesAsync()
    {
        var gameMatches = await _gameMatchesRepository.GetAllGameMatchesAsync();
        return gameMatches.Select(x => new GameMatch
        {
            Id = x.Id,
            CreationDate = x.CreationDate,
            GameState = x.GameState,
            Listing = x.Listing,
            User = x.User
        });
    }

    [HttpPost]
    public async Task<ActionResult<GameMatch>> CreateGameMatchAsync(CreateGameMatchCommand createGameMatchCommand)
    {
        //var listings = await _usersRepository.get();
        if (createGameMatchCommand == null)
        {
            return BadRequest("Error");
        }
        //gauti listing id is prasidejusio matcho
        var listing = await _listingsRepository.GetListingAsync(createGameMatchCommand.Listing.Id);

        var gameMatch = new GameMatch
        {
            GameState = Enums.GameState.ACTIVE,
            CreationDate = DateTime.UtcNow,
            Listing = listing,
            User = listing.PlayerOne
        };

        await _gameMatchesRepository.CreateGameMatchAsync(gameMatch);
        return Created("", new GameMatch
        {
            Id = gameMatch.Id,
            CreationDate = gameMatch.CreationDate,
            GameState = gameMatch.GameState,
            Listing = gameMatch.Listing,
            User = gameMatch.User
        });
    }

    [HttpPut]
    [Route("{gameMatchId}")]
    public async Task<ActionResult<GameMatch>> UpdateListingAsync(int gameMatchId, UpdateGameMatchCommand updateGameMatchCommand)
    {
        
        var gameMatch = await _gameMatchesRepository.GetGameMatchAsync(gameMatchId);
        var listing = await _listingsRepository.GetListingAsync(gameMatch.Listing.Id);

        // 404 UpdateListingCommand(string? Name, double? EloFrom, double? EloTo);
        if (gameMatch == null)
            return NotFound($"No game match with id of {gameMatchId}");

        //geras
        //var user = await _usersRepository.GetUserAsync(updateGameMatchCommand.UserWinner.Id);
        var user = await _usersRepository.GetUserAsync(listing.PlayerTwo.Id);


        gameMatch.GameState = updateGameMatchCommand.GameState is 0 ? gameMatch.GameState : updateGameMatchCommand.GameState; // jei 0 tai palikti 0
        gameMatch.User = updateGameMatchCommand.UserWinner is null ? gameMatch.User : user; // sutvarkyti kuris useris winneris irgi is frontend

        await _gameMatchesRepository.UpdateGameMatchAsync(gameMatch);

        return Ok(new GameMatch
        {
            Id = gameMatch.Id,
            CreationDate = gameMatch.CreationDate,
            GameState = gameMatch.GameState,
            Listing = gameMatch.Listing,
            User = gameMatch.User
        });
    }

    [HttpDelete("{gameMatchId}")]
    public async Task<ActionResult> Remove(int gameMatchId)
    {
        var gameMatch = await _gameMatchesRepository.GetGameMatchAsync(gameMatchId);

        // 404
        if (gameMatch == null)
            return NotFound($"No game match with id of {gameMatchId}"); ;

        await _gameMatchesRepository.DeleteGameMatchAsync(gameMatch);


        // 204
        return NoContent();
    }
}
