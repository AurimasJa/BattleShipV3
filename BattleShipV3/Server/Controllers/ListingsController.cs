﻿using BattleShipV3.Server.Repositories;
using BattleShipV3.Models;
using BattleShipV3.Shared;
using BattleShipV3.Shared.Data.Commands.Listing.Get;
using BattleShipV3.Shared.Data.Commands.Listing.Create;
using Microsoft.AspNetCore.Mvc;
using BattleShipV3.Shared.Data.Commands.Listing.Update;

namespace BattleShipV3.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ListingsController : ControllerBase
{
    private readonly IListingsRepository _listingsRepository;
    //private readonly IUsersRepository _usersRepository;

    public ListingsController(IListingsRepository listingsRepository)
    {
        _listingsRepository = listingsRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetListingCommand>> GetListingAsync(int? id)
    {
        var listing = await _listingsRepository.GetListingAsync(id);
        if (listing == null)
            return NotFound($"Listing does not exist");

        return new GetListingCommand(listing.Id, listing.Name, listing.EloFrom, listing.EloTo, listing.CreationDate, listing.PlayerOne, listing.PlayerTwo); // truksta user user2
    }
    [HttpGet]
    public async Task<IEnumerable<GetListingCommand>> GetListingsAsync()
    {
        var listings = await _listingsRepository.GetAllListingsAsync();
        return listings.Select(x => new GetListingCommand(x.Id, x.Name, x.EloFrom, x.EloTo, x.CreationDate, x.PlayerOne, x.PlayerTwo));
    }

    [HttpPost]
    public async Task<ActionResult<GetListingCommand>> CreateListingAsync(CreateListingCommand createListingCommand)
    {

        if (Global.CurrentUser == null)
        {
            BadRequest("Current user not logged in.");    
        }
        //var listings = await _usersRepository.get();
        if (createListingCommand == null)
        {
            return BadRequest("Error");
        }
        // CreateListingCommand(string Name, double EloFrom, double EloTo);
        if (createListingCommand.Name == null)
            return BadRequest("Name can not be empty");

        var listing = new Listing
        {
            Name = createListingCommand.Name,
            EloFrom = createListingCommand.EloFrom,
            EloTo = createListingCommand.EloTo,
            CreationDate = DateTime.UtcNow,
            PlayerOne = Global.CurrentUser
        };

        await _listingsRepository.CreateListingAsync(listing);
        return Created("", new GetListingCommand(listing.Id, listing.Name, listing.EloFrom, listing.EloTo, listing.CreationDate, listing.PlayerOne, listing.PlayerTwo));
    }

    [HttpPut]
    [Route("{listingId}")]
    public async Task<ActionResult<GetListingCommand>> UpdateListingAsync(int listingId, UpdateListingCommand updateListingCommand)
    {
        var listing = await _listingsRepository.GetListingAsync(listingId);

        // 404 UpdateListingCommand(string? Name, double? EloFrom, double? EloTo);
        if (listing == null)
            return NotFound($"No listing with id of {listingId}");

        listing.Name = updateListingCommand.Name is null ? listing.Name : updateListingCommand.Name;
        listing.EloFrom = updateListingCommand.EloFrom is null ? listing.EloFrom : updateListingCommand.EloFrom;
        listing.EloTo = updateListingCommand.EloTo is null ? listing.EloTo : updateListingCommand.EloTo;

        await _listingsRepository.UpdateListingAsync(listing);

        return Ok(new GetListingCommand(listing.Id, listing.Name, listing.EloFrom, listing.EloTo, listing.CreationDate, listing.PlayerOne, listing.PlayerTwo));
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
