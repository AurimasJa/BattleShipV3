using BattleShipV3.Server.Repositories;
using BattleShipV3.Models;
using BattleShipV3.Shared;
using BattleShipV3.Shared.Data.Commands.Listing.Create;
using Microsoft.AspNetCore.Mvc;
using BattleShipV3.Shared.Data.Commands.Listing.Update;
using System.Reflection;

namespace BattleShipV3.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ListingsController : ControllerBase
{
    private readonly IListingsRepository _listingsRepository;
    private readonly IUsersRepository _usersRepository;

    public ListingsController(IListingsRepository listingsRepository, IUsersRepository usersRepository)
    {
        _listingsRepository = listingsRepository;
        _usersRepository = usersRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Listing>> GetListingAsync(int? id)
    {
        var listing = await _listingsRepository.GetListingAsync(id);
        if (listing == null)
            return NotFound($"Listing does not exist");

        return new Listing
        {
            Id = listing.Id,
            Name = listing.Name,
            EloFrom = listing.EloFrom,
            EloTo = listing.EloTo,
            CreationDate = listing.CreationDate,
            PlayerOne = listing.PlayerOne,
            PlayerTwo = listing.PlayerTwo
        }; // truksta user user2
    }
    [HttpGet]
    public async Task<IEnumerable<Listing>> GetListingsAsync()
    {
        var listings = await _listingsRepository.GetAllListingsAsync();
        return listings.Select(x => new Listing
        {
            Id = x.Id,
            Name = x.Name,
            EloFrom = x.EloFrom,
            EloTo = x.EloTo,
            CreationDate = x.CreationDate,
            PlayerOne = x.PlayerOne,
            PlayerTwo = x.PlayerTwo
        });
    }

    [HttpPost]
    public async Task<ActionResult<Listing>> CreateListingAsync(CreateListingCommand createListingCommand)
    {
        //var listings = await _usersRepository.get();
        if (createListingCommand == null)
        {
            return BadRequest("Error");
        }
        // CreateListingCommand(string Name, double EloFrom, double EloTo);
        if (createListingCommand.Name == null)
            return BadRequest("Name can not be empty");

        var user = await _usersRepository.GetUserAsync(createListingCommand.User.Id);

        var listing = new Listing
        {
            Name = createListingCommand.Name,
            EloFrom = createListingCommand.EloFrom,
            EloTo = createListingCommand.EloTo,
            CreationDate = DateTime.UtcNow,
            PlayerOne = user
        };

        await _listingsRepository.CreateListingAsync(listing);
        return Created("", new Listing
        {
            Id = listing.Id,
            Name = listing.Name,
            EloFrom = listing.EloFrom,
            EloTo = listing.EloTo,
            CreationDate = listing.CreationDate,
            PlayerOne = listing.PlayerOne,
            PlayerTwo = listing.PlayerTwo
        });
    }

    [HttpPut]
    [Route("{listingId}")]
    public async Task<ActionResult<Listing>> UpdateListingAsync(int listingId, UpdateListingCommand updateListingCommand)
    {
        var listing = await _listingsRepository.GetListingAsync(listingId);

        // 404 UpdateListingCommand(string? Name, double? EloFrom, double? EloTo);
        if (listing == null)
            return NotFound($"No listing with id of {listingId}");

        var user = updateListingCommand.removePlayerTwo ? null : await _usersRepository.GetUserAsync(updateListingCommand.playerTwo.Id);

        listing.Name = updateListingCommand.Name is null ? listing.Name : updateListingCommand.Name;
        listing.EloFrom = updateListingCommand.EloFrom is null ? listing.EloFrom : updateListingCommand.EloFrom;
        listing.EloTo = updateListingCommand.EloTo is null ? listing.EloTo : updateListingCommand.EloTo;
        listing.PlayerTwo = user;

        await _listingsRepository.UpdateListingAsync(listing);

        return Ok(new Listing
        {
            Id = listing.Id,
            Name = listing.Name,
            EloFrom = listing.EloFrom,
            EloTo = listing.EloTo,
            CreationDate = listing.CreationDate,
            PlayerOne = listing.PlayerOne,
            PlayerTwo = listing.PlayerTwo
        });
    }

    [HttpDelete("{listingId}")]
    public async Task<ActionResult> Remove(int listingId)
    {
        var listing = await _listingsRepository.GetListingAsync(listingId);

        // 404
        if (listing == null)
            return NotFound($"No listing with id of {listingId}"); ;

        await _listingsRepository.DeleteListingAsync(listing);


        // 204
        return NoContent();
    }
}
