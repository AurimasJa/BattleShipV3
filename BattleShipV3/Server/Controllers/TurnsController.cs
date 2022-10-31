using BattleShipV3.Data.Models;
using BattleShipV3.Server.Repositories;
using BattleShipV3.Shared.Data.Commands.Missile.Create;
using BattleShipV3.Shared.Data.Commands.Missile.Update;
using Microsoft.AspNetCore.Mvc;

namespace BattleShipV3.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class TurnsController : ControllerBase
{

    private readonly ITurnsRepository _turnsRepository;
    private readonly IGameMatchesRepository _gameMatchesRepository;

    public TurnsController(ITurnsRepository turnsRepository, IGameMatchesRepository gameMatchesRepository)
    {
        _turnsRepository = turnsRepository;
        _gameMatchesRepository = gameMatchesRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Turn>> GetTurnAsync(int? id)
    {
        var turn = await _turnsRepository.GetTurnAsync(id);
        if (turn == null)
            return NotFound($"Turn does not exist");

        return new Turn
        {
            Id = turn.Id,
            XCoordinate = turn.XCoordinate,
            YCoordinate = turn.YCoordinate,
            TurnType = turn.TurnType,
            GameMatch = turn.GameMatch
        };
    }
    [HttpGet]
    public async Task<IEnumerable<Turn>> GetTurnsAsync()
    {
        var turns = await _turnsRepository.GetTurnsAsync();
        return turns.Select(x => new Turn
        {
            Id = x.Id,
            XCoordinate = x.XCoordinate,
            YCoordinate = x.YCoordinate,
            TurnType = x.TurnType,
            GameMatch = x.GameMatch
        });
    }

    [HttpPost]

    public async Task<ActionResult<Turn>> CreateTurnAsync(CreateTurnCommand createTurnCommand)
    {
        if (createTurnCommand == null)
        {
            return BadRequest("Error");
        }

        var gameMatch = await _gameMatchesRepository.GetGameMatchAsync(createTurnCommand.GameMatch.Id);

        var turn = new Turn
        {
            XCoordinate = createTurnCommand.XCoordinate,
            YCoordinate = createTurnCommand.YCoordinate,
            TurnType = createTurnCommand.TurnType,
            GameMatch = createTurnCommand.GameMatch
        };

        await _turnsRepository.CreateTurnAsync(turn);
        return Created("", new Turn
        {
            Id = turn.Id,
            XCoordinate = turn.XCoordinate,
            YCoordinate = turn.YCoordinate,
            TurnType = turn.TurnType,
            GameMatch = turn.GameMatch
        });
    }

    [HttpDelete("{turnId}")]
    public async Task<ActionResult> Remove(int turnId)
    {
        var turn = await _turnsRepository.GetTurnAsync(turnId);

        // 404
        if (turn == null)
            return NotFound($"No ship with id of {turnId}"); ;

        await _turnsRepository.DeleteTurnAsync(turn);


        // 204
        return NoContent();
    }
}
