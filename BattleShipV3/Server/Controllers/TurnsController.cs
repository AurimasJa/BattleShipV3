using BattleShipV3.Data.Models;
using BattleShipV3.Server.Repositories;
using BattleShipV3.Shared.Data.Commands.Missile.Create;
using BattleShipV3.Shared.Data.Commands.Missile.Update;
using BattleShipV3.Shared.Data.Commands.Ship.Get;
using Microsoft.AspNetCore.Mvc;

namespace BattleShipV3.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class TurnsController : ControllerBase
{

    private readonly ITurnsRepository _turnsRepository;

    public TurnsController(ITurnsRepository turnsRepository)
    {
        _turnsRepository = turnsRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetTurnCommand>> GetShipAsync(int? id)
    {
        var turn = await _turnsRepository.GetTurnAsync(id);
        if (turn == null)
            return NotFound($"Turn does not exist");

        return new GetTurnCommand(turn.Id, turn.XCoordinate, turn.YCoordinate, turn.TurnType, turn.GameMatch);
    }
    [HttpGet]
    public async Task<IEnumerable<GetTurnCommand>> GetShipsAsync()
    {
        var turns = await _turnsRepository.GetTurnsAsync();
        return turns.Select(x => new GetTurnCommand(x.Id, x.XCoordinate, x.YCoordinate, x.TurnType, x.GameMatch));
    }
}
    //[HttpPost]
    
    //public async Task<ActionResult<GetShipCommand>> CreateShipAsync(CreateShipCommand createShipCommand)
    //{
    //    if (createShipCommand == null)
    //    {
    //        return BadRequest("Error");
    //    }
    //    if (createShipCommand.Name == null)
    //        return BadRequest("Name can not be empty");

    //    var missile = await _missilesRepository.GetMissileAsync(createShipCommand.Missile.Id);

    //    var ship = new Ship
    //    {
    //        Name = createShipCommand.Name,
    //        Length = createShipCommand.Length,
    //        Missile = missile
    //    };

    //    await _shipsRepository.CreateShipAsync(ship);
    //    return Created("", new GetShipCommand(ship.Id, ship.Name, ship.Length, ship.Missile));
    //}

    //[HttpPut]
    //[Route("{shipId}")]
    //public async Task<ActionResult<GetShipCommand>> UpdateShipAsync(int shipId, UpdateShipCommand updateShipCommand)
    //{
    //    var ship = await _shipsRepository.GetShipAsync(shipId);

    //    if (ship == null)
    //        return NotFound($"No ship with id of {shipId}");

    //    ship.Name = updateShipCommand.Name is null ? ship.Name : updateShipCommand.Name;
    //    ship.Length = (int)(updateShipCommand.Length is null ? ship.Length : updateShipCommand.Length);

    //    await _shipsRepository.UpdateShipAsync(ship);

    //    return Ok(new GetShipCommand(ship.Id, ship.Name, ship.Length, ship.Missile));
    //}

    //[HttpDelete("{shipId}")]
    //public async Task<ActionResult> Remove(int shipId)
    //{
    //    var ship = await _shipsRepository.GetShipAsync(shipId);

    //    // 404
    //    if (ship == null)
    //        return NotFound($"No ship with id of {shipId}"); ;

    //    await _shipsRepository.DeleteShipAsync(ship);


    //    // 204
    //    return NoContent();
    //}
