using BattleShipV3.Server.Repositories;
using BattleShipV3.Data.Models;
using BattleShipV3.Shared;
using BattleShipV3;
using BattleShipV3.Shared.Data.Commands.Ship.Get;
using BattleShipV3.Shared.Data.Commands.Ship.Create;
using Microsoft.AspNetCore.Mvc;
using BattleShipV3.Shared.Data.Commands.Ship.Update;
using static MudBlazor.CategoryTypes;
using BattleShipV3.Models;
using BattleShipV3.Shared.Data.Commands.UserShips.Create;
using System.Text.Json;

namespace BattleShipV3.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ShipsController : ControllerBase
{
    private readonly IShipsRepository _shipsRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly IMissilesRepository _missilesRepository;
    private readonly IUserShipsRepository _usersShipRepository;


    public ShipsController(IShipsRepository shipsRepository, IMissilesRepository missilesRepository, IUsersRepository userRepository)
    {
        _shipsRepository = shipsRepository;
        _missilesRepository = missilesRepository;
        _usersRepository = userRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Ship>> GetShipAsync(int? id)
    {
        var ship = await _shipsRepository.GetShipAsync(id);
        if (ship == null)
            return NotFound($"Ship does not exist");

        return new Ship { Id = ship.Id, Name = ship.Name, Length = ship.Length, Missile = ship.Missile }; // truksta user user2
    }
    [HttpGet]
    public async Task<IEnumerable<Ship>> GetShipsAsync()
    {
        return await _shipsRepository.GetAllShipsAsync();
    }
    [HttpGet("{userId}")]
    public async Task<string> GetAllUserShipsAsync(int? userId, bool? selected)
    {
        var ships = await _shipsRepository.GetAllOneUserShipsAsync(userId.Value, selected);
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(ships);
        return json;
    }

    [HttpPost]
    public async Task<ActionResult<Ship>> CreateShipAsync(CreateShipCommand createShipCommand)
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
        return Created("", new Ship { Id = ship.Id, Name = ship.Name, Length = ship.Length, Missile = ship.Missile });
    }

    [HttpPost]
    [Route("userselected")]
    public async Task<ActionResult<UserSelectedShip>> CreateUserShipsAsync(CreateUserSelectedShipCommand createUserSelectedShipCommand)
    {
        if (createUserSelectedShipCommand == null)
        {
            return BadRequest("Error");
        }

        var user = await _usersRepository.GetUserAsync(createUserSelectedShipCommand.userId);
        var ship = await _shipsRepository.GetShipAsync(createUserSelectedShipCommand.shipId);

        var userShips = new UserSelectedShip
        {
            User = user,
            Ship = ship
        };

        await _shipsRepository.CreateUserSelectedShipAsync(userShips);
        return Created("", new UserSelectedShip
        {
            Id = userShips.Id,
            Ship = userShips.Ship,
            User = userShips.User
        });
    }

    [HttpPut]
    [Route("{shipId}")]
    public async Task<ActionResult<Ship>> UpdateShipAsync(int shipId, UpdateShipCommand updateShipCommand)
    {
        var ship = await _shipsRepository.GetShipAsync(shipId);

        if (ship == null)
            return NotFound($"No ship with id of {shipId}");

        ship.Name = updateShipCommand.Name is null ? ship.Name : updateShipCommand.Name;
        ship.Length = (int)(updateShipCommand.Length is null ? ship.Length : updateShipCommand.Length);

        await _shipsRepository.UpdateShipAsync(ship);

        return Ok(new Ship { Id = ship.Id, Name = ship.Name, Length = ship.Length, Missile = ship.Missile });
    }

    [HttpDelete]
    public async Task<ActionResult> RemoveUserSelectedShip(int userId, int shipId)
    {
        await _shipsRepository.RemoveUserSelectedShipAsync(userId, shipId);
        return Ok();
    }
}
