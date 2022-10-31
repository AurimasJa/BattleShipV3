using BattleShipV3.Server.Repositories;
using BattleShipV3.Data.Models;
using BattleShipV3.Shared;
using BattleShipV3.Shared.Data.Commands.Ship.Get;
using BattleShipV3.Shared.Data.Commands.Ship.Create;
using Microsoft.AspNetCore.Mvc;
using BattleShipV3.Shared.Data.Commands.Ship.Update;

namespace BattleShipV3.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ShipsController : ControllerBase
{
    private readonly IShipsRepository _shipsRepository;
    private readonly IMissilesRepository _missilesRepository;


    public ShipsController(IShipsRepository shipsRepository, IMissilesRepository missilesRepository)
    {
        _shipsRepository = shipsRepository;
        _missilesRepository = missilesRepository;

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetShipCommand>> GetShipAsync(int? id)
    {
        var ship = await _shipsRepository.GetShipAsync(id);
        if (ship == null)
            return NotFound($"Ship does not exist");

        return new GetShipCommand(ship.Id, ship.Name, ship.Length, ship.Missile); // truksta user user2
    }
    [HttpGet]
    public async Task<IEnumerable<GetShipCommand>> GetShipsAsync()
    {
        var ships = await _shipsRepository.GetAllShipsAsync();
        return ships.Select(x => new GetShipCommand(x.Id, x.Name, x.Length, x.Missile));
    }

    //[HttpGet("{userId}")]
    //public async Task<IEnumerable<Ship>> GetShipsByUserAsync(int? userId)
    //{

    //}

    [HttpPost]
    public async Task<ActionResult<GetShipCommand>> CreateShipAsync(CreateShipCommand createShipCommand)
    {
        if (createShipCommand == null)
        {
            return BadRequest("Error");
        }
        if (createShipCommand.Name == null)
            return BadRequest("Name can not be empty");

        var missile = await _missilesRepository.GetMissileAsync(createShipCommand.Missile.Id);

        var ship = new Ship
        {
            Name = createShipCommand.Name,
            Length = createShipCommand.Length,
            Missile = missile
        };

        await _shipsRepository.CreateShipAsync(ship);
        return Created("", new GetShipCommand(ship.Id, ship.Name, ship.Length, ship.Missile));
    }

    [HttpPut]
    [Route("{shipId}")]
    public async Task<ActionResult<GetShipCommand>> UpdateShipAsync(int shipId, UpdateShipCommand updateShipCommand)
    {
        var ship = await _shipsRepository.GetShipAsync(shipId);

        if (ship == null)
            return NotFound($"No ship with id of {shipId}");

        ship.Name = updateShipCommand.Name is null ? ship.Name : updateShipCommand.Name;
        ship.Length = (int)(updateShipCommand.Length is null ? ship.Length : updateShipCommand.Length);

        await _shipsRepository.UpdateShipAsync(ship);

        return Ok(new GetShipCommand(ship.Id, ship.Name, ship.Length, ship.Missile));
    }

    [HttpDelete("{shipId}")]
    public async Task<ActionResult> Remove(int shipId)
    {
        var ship = await _shipsRepository.GetShipAsync(shipId);

        // 404
        if (ship == null)
            return NotFound($"No ship with id of {shipId}"); ;

        await _shipsRepository.DeleteShipAsync(ship);


        // 204
        return NoContent();
    }
}
