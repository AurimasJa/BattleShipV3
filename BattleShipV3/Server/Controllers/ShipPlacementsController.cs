using BattleShipV3.Server.Repositories;
using BattleShipV3.Models;
using BattleShipV3.Data.Models;
using BattleShipV3.Shared;
using BattleShipV3.Shared.Data.Commands.ShipPlacement.Create;
using Microsoft.AspNetCore.Mvc;
using BattleShipV3.Shared.Data.Commands.ShipPlacement.Update;
using System.Linq;

namespace BattleShipV3.Server.Controllers;

// GALIMAI NEVEIKIA - NETIKRINTA

[ApiController]
[Route("[controller]")]
public class ShipPlacementsController : ControllerBase
{
    private readonly IShipPlacementsRepository _shipPlacementsRepository;
    private readonly IGameMatchesRepository _gameMatchesRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly IShipsRepository _shipsRepository;

    public ShipPlacementsController(IShipPlacementsRepository shipPlacementsRepository, IGameMatchesRepository gameMatchesRepository, IUsersRepository usersRepository, IShipsRepository shipsRepository)
    {
        _shipPlacementsRepository = shipPlacementsRepository;
        _gameMatchesRepository = gameMatchesRepository;
        _usersRepository = usersRepository;
        _shipsRepository = shipsRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ShipPlacement>> GetShipPlacementAsync(int? id)
    {
        var shipPlacement = await _shipPlacementsRepository.GetShipPlacementsAsync(id);
        if (shipPlacement == null)
            return NotFound($"Ship placement does not exist");

        return new ShipPlacement
        {
            Id = shipPlacement.Id,
            XCoordinate = shipPlacement.XCoordinate,
            YCoordinate = shipPlacement.YCoordinate,
            IsVerticalRotation = shipPlacement.IsVerticalRotation,
            Ship = shipPlacement.Ship,
            User = shipPlacement.User,
            GameMatch = shipPlacement.GameMatch
        }; // truksta user user2
    }
    [HttpGet]
    public async Task<IEnumerable<ShipPlacement>> GetShipPlacementsAsync()
    {
        var shipPlacement = await _shipPlacementsRepository.GetAllShipPlacementsAsync();
        return shipPlacement.Select(x => new ShipPlacement
        {
            Id = x.Id,
            XCoordinate = x.XCoordinate,
            YCoordinate = x.YCoordinate,
            IsVerticalRotation = x.IsVerticalRotation,
            Ship = x.Ship,
            User = x.User,
            GameMatch = x.GameMatch
        });
    }

    [HttpPost]
    public async Task<ActionResult<ShipPlacement>> CreateShipPlacementAsync(CreateShipPlacementCommand createShipPlacementCommand)
    {
        if (createShipPlacementCommand == null)
        {
            return BadRequest("Error");
        }
        if (createShipPlacementCommand.XCoordinate == null || createShipPlacementCommand.YCoordinate == null)
            return BadRequest("Coordinates can not be empty");

        var ship = await _shipsRepository.GetShipAsync(createShipPlacementCommand.Ship.Id);
        var user = await _usersRepository.GetUserAsync(createShipPlacementCommand.User.Id);
        var gameMatch = await _gameMatchesRepository.GetGameMatchAsync(createShipPlacementCommand.gameMatch.Id);

        var shipPlacement = new ShipPlacement
        {
            XCoordinate = createShipPlacementCommand.XCoordinate,
            YCoordinate = createShipPlacementCommand.YCoordinate,
            IsVerticalRotation = createShipPlacementCommand.IsVerticalRotation,
            Ship = ship,
            User = user,
            GameMatch = gameMatch
        };

        await _shipPlacementsRepository.CreateShipPlacementAsync(shipPlacement);
        return Created("", new ShipPlacement
        {
            Id = shipPlacement.Id,
            XCoordinate = shipPlacement.XCoordinate,
            YCoordinate = shipPlacement.YCoordinate,
            IsVerticalRotation = shipPlacement.IsVerticalRotation,
            Ship = shipPlacement.Ship,
            User = shipPlacement.User,
            GameMatch = shipPlacement.GameMatch
        });
    }

    [HttpPut]
    [Route("{shipPlacementId}")]
    public async Task<ActionResult<ShipPlacement>> UpdateShipPlacementAsync(int shipPlacementId, UpdateShipPlacementCommand updateShipPlacementCommand)
    {
        var shipPlacement = await _shipPlacementsRepository.GetShipPlacementsAsync(shipPlacementId);

        if (shipPlacement == null)
            return NotFound($"No shipPlacement with id of {shipPlacementId}");

        //var ship = await _shipsRepository.GetShipAsync(updateShipPlacementCommand.ship.Id);
        //var user = await _usersRepository.GetUserAsync(updateShipPlacementCommand.playerTwo.Id);
        //var gameMatch = await _gameMatchesRepository.GetGameMatchAsync(updateShipPlacementCommand.playerTwo.Id);

        shipPlacement.XCoordinate = updateShipPlacementCommand.XCoordinate is 0 ? shipPlacement.XCoordinate : updateShipPlacementCommand.XCoordinate;
        shipPlacement.YCoordinate = updateShipPlacementCommand.YCoordinate is 0 ? shipPlacement.YCoordinate : updateShipPlacementCommand.YCoordinate;
        shipPlacement.IsVerticalRotation = updateShipPlacementCommand.IsVerticalRotation is false ? shipPlacement.IsVerticalRotation : updateShipPlacementCommand.IsVerticalRotation;
        //shipPlacement.Ship = updateShipPlacementCommand.Ship is null ? shipPlacement.Ship : ship;
        //shipPlacement.User = updateShipPlacementCommand.User is null ? shipPlacement.User : user;
        //shipPlacement.GameMatch = updateShipPlacementCommand.GameMatch is null ? shipPlacement.GameMatch : gameMatch;

        await _shipPlacementsRepository.UpdateShipPlacementAsync(shipPlacement);

        return Ok(new ShipPlacement
        {
            Id = shipPlacement.Id,
            XCoordinate = shipPlacement.XCoordinate,
            YCoordinate = shipPlacement.YCoordinate,
            IsVerticalRotation = shipPlacement.IsVerticalRotation,
            Ship = shipPlacement.Ship,
            User = shipPlacement.User,
            GameMatch = shipPlacement.GameMatch
        });
    }

    [HttpDelete("{shipPlacementId}")]
    public async Task<ActionResult> Remove(int shipPlacementId)
    {
        var shipPlacement = await _shipPlacementsRepository.GetShipPlacementsAsync(shipPlacementId);

        // 404
        if (shipPlacement == null)
            return NotFound($"No shipPlacement with id of {shipPlacementId}"); ;

        await _shipPlacementsRepository.DeleteShipPlacementAsync(shipPlacement);


        // 204
        return NoContent();
    }
}
