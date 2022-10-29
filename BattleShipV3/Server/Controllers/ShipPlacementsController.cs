//using BattleShipV3.Server.Repositories;
//using BattleShipV3.Models;
//using BattleShipV3.Data.Models;
//using BattleShipV3.Shared;
//using BattleShipV3.Shared.Data.Commands.ShipPlacement.Get;
//using BattleShipV3.Shared.Data.Commands.ShipPlacement.Create;
//using Microsoft.AspNetCore.Mvc;
//using BattleShipV3.Shared.Data.Commands.ShipPlacement.Update;

//namespace BattleShipV3.Server.Controllers;

//[ApiController]
//[Route("[controller]")]
//public class ShipPlacementsController : ControllerBase
//{
//    private readonly IShipPlacementsRepository _shipPlacementsRepository;

//    public ShipPlacementsController(IShipPlacementsRepository shipPlacementsRepository)
//    {
//        _shipPlacementsRepository = shipPlacementsRepository;
//    }

//    [HttpGet("{id}")]
//    public async Task<ActionResult<GetShipPlacementCommand>> GetListingAsync(int? id)
//    {
//        var shipPlacement = await _shipPlacementsRepository.GetShipPlacementsAsync(id);
//        if (shipPlacement == null)
//            return NotFound($"Listing does not exist");

//        return new GetShipPlacementCommand(shipPlacement.Id, shipPlacement.Name, shipPlacement.EloFrom, shipPlacement.EloTo, shipPlacement.CreationDate, shipPlacement.PlayerOne, shipPlacement.PlayerTwo); // truksta user user2
//    }
//    [HttpGet]
//    public async Task<IEnumerable<GetShipPlacementCommand>> GetListingsAsync()
//    {
//        var listings = await _shipPlacementsRepository.GetAllShipPlacementsAsync();
//        return listings.Select(x => new GetShipPlacementCommand(x.Id, x.Name, x.EloFrom, x.EloTo, x.CreationDate, x.PlayerOne, x.PlayerTwo));
//    }

//    [HttpPost]
//    public async Task<ActionResult<GetShipPlacementCommand>> CreateListingAsync(CreateShipPlacementCommand createShipPlacementCommand)
//    {
//        //var listings = await _usersRepository.get();
//        if (createShipPlacementCommand == null)
//        {
//            return BadRequest("Error");
//        }
//        // CreateListingCommand(string Name, double EloFrom, double EloTo);
//        if (createShipPlacementCommand.Name == null)
//            return BadRequest("Name can not be empty");

//        //var user = await _usersRepository.GetUserAsync(createShipPlacementCommand.User.Id);

//        var shipPlacement = new ShipPlacement
//        {
//            //Name = createListingCommand.Name,
//            //EloFrom = createListingCommand.EloFrom,
//            //EloTo = createListingCommand.EloTo,
//            //CreationDate = DateTime.UtcNow,
//            //PlayerOne = user
//        };

//        await _shipPlacementsRepository.CreateShipPlacementAsync(shipPlacement);
//        return Created("", new GetShipPlacementCommand(shipPlacement.Id, shipPlacement.Name, shipPlacement.EloFrom, shipPlacement.EloTo, shipPlacement.CreationDate, shipPlacement.PlayerOne, shipPlacement.PlayerTwo));
//    }

//    [HttpPut]
//    [Route("{shipPlacementId}")]
//    public async Task<ActionResult<GetShipPlacementCommand>> UpdateListingAsync(int shipPlacementId, UpdateShipPlacementCommand updateShipPlacementCommand)
//    {
//        var shipPlacement = await _shipPlacementsRepository.GetShipPlacementsAsync(shipPlacementId);

//        // 404 UpdateListingCommand(string? Name, double? EloFrom, double? EloTo);
//        if (shipPlacement == null)
//            return NotFound($"No shipPlacement with id of {shipPlacementId}");

//        //var user = await _usersRepository.GetUserAsync(updateListingCommand.playerTwo.Id);

//        //shipPlacement.Name = updateListingCommand.Name is null ? shipPlacement.Name : updateListingCommand.Name;
//        //shipPlacement.EloFrom = updateListingCommand.EloFrom is null ? shipPlacement.EloFrom : updateListingCommand.EloFrom;
//        //shipPlacement.EloTo = updateListingCommand.EloTo is null ? shipPlacement.EloTo : updateListingCommand.EloTo;
//        //shipPlacement.PlayerTwo = updateListingCommand.playerTwo is null ? shipPlacement.PlayerTwo : user;

//        await _shipPlacementsRepository.UpdateShipPlacementAsync(shipPlacement);

//        return Ok(new GetShipPlacementCommand(shipPlacement.Id, shipPlacement.Name, shipPlacement.EloFrom, shipPlacement.EloTo, shipPlacement.CreationDate, shipPlacement.PlayerOne, shipPlacement.PlayerTwo));
//    }

//    [HttpDelete("{shipPlacementId}")]
//    public async Task<ActionResult> Remove(int shipPlacementId)
//    {
//        var shipPlacement = await _shipPlacementsRepository.GetShipPlacementsAsync(shipPlacementId);

//        // 404
//        if (shipPlacement == null)
//            return NotFound($"No shipPlacement with id of {shipPlacementId}"); ;

//        await _shipPlacementsRepository.DeleteShipPlacementAsync(shipPlacement);


//        // 204
//        return NoContent();
//    }
//}
