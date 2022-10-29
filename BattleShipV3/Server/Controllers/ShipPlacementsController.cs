using BattleShipV3.Server.Repositories;
using BattleShipV3.Models;
using BattleShipV3.Data.Models;
using BattleShipV3.Shared;
using BattleShipV3.Shared.Data.Commands.ShipPlacement.Get;
using BattleShipV3.Shared.Data.Commands.ShipPlacement.Create;
using Microsoft.AspNetCore.Mvc;
using BattleShipV3.Shared.Data.Commands.ShipPlacement.Update;

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
    public async Task<ActionResult<GetShipPlacementCommand>> GetShipPlacementAsync(int? id)
    {
        var shipPlacement = await _shipPlacementsRepository.GetShipPlacementsAsync(id);
        if (shipPlacement == null)
            return NotFound($"Ship placement does not exist");

        return new GetShipPlacementCommand(shipPlacement.Id, shipPlacement.XCoordinate, shipPlacement.YCoordinate, shipPlacement.IsVerticalRotation, shipPlacement.Ship, shipPlacement.User, shipPlacement.GameMatch); // truksta user user2
    }
    [HttpGet]
    public async Task<IEnumerable<GetShipPlacementCommand>> GetShipPlacementsAsync()
    {
        var shipPlacement = await _shipPlacementsRepository.GetAllShipPlacementsAsync();
        return shipPlacement.Select(x => new GetShipPlacementCommand(x.Id, x.XCoordinate, x.YCoordinate, x.IsVerticalRotation, x.Ship, x.User, x.GameMatch));
    }

    [HttpPost]
    public async Task<ActionResult<GetShipPlacementCommand>> CreateShipPlacementAsync(CreateShipPlacementCommand createShipPlacementCommand)
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
        return Created("", new GetShipPlacementCommand(shipPlacement.Id, shipPlacement.XCoordinate, shipPlacement.YCoordinate, shipPlacement.IsVerticalRotation, shipPlacement.Ship, shipPlacement.User, shipPlacement.GameMatch));
    }

    [HttpPut]
    [Route("{shipPlacementId}")]
    public async Task<ActionResult<GetShipPlacementCommand>> UpdateShipPlacementAsync(int shipPlacementId, UpdateShipPlacementCommand updateShipPlacementCommand)
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

        return Ok(new GetShipPlacementCommand(shipPlacement.Id, shipPlacement.XCoordinate, shipPlacement.YCoordinate, shipPlacement.IsVerticalRotation, shipPlacement.Ship, shipPlacement.User, shipPlacement.GameMatch));
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
