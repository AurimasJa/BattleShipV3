using BattleShipV3.Server.Repositories;
using BattleShipV3.Models;
using BattleShipV3.Data.Models;
using BattleShipV3.Shared;
using BattleShipV3.Shared.Data.Commands.Missile.Get;
using BattleShipV3.Shared.Data.Commands.Missile.Create;
using Microsoft.AspNetCore.Mvc;
using BattleShipV3.Shared.Data.Commands.Missile.Update;
using System.Reflection;

namespace BattleShipV3.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class MissilesController : ControllerBase
{
    private readonly IMissilesRepository _missilesRepository;

    public MissilesController(IMissilesRepository missilesRepository)
    {
        _missilesRepository = missilesRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Missile>> GetMissileAsync(int? id)
    {
        var missile = await _missilesRepository.GetMissileAsync(id);
        if (missile == null)
            return NotFound($"Listing does not exist");

        return new Missile { 
            Id = missile.Id,
            Name = missile.Name,
            Cooldown = missile.Cooldown,
            MissileType = missile.MissileType}; // truksta user user2
    }
    [HttpGet]
    public async Task<IEnumerable<Missile>> GetMissilesAsync()
    {
        var listings = await _missilesRepository.GetAllMissilesAsync();
        return listings.Select(x => new Missile
        {
            Id = x.Id,
            Name = x.Name,
            Cooldown = x.Cooldown,
            MissileType = x.MissileType
        });
    }

    [HttpPost]
    public async Task<ActionResult<Missile>> CreateMissileAsync(CreateShipCommand createMissileCommand)
    {
        //var listings = await _usersRepository.get();
        if (createMissileCommand == null)
        {
            return BadRequest("Error");
        }
        // CreateListingCommand(string Name, double EloFrom, double EloTo);
        if (createMissileCommand.Name == null)
            return BadRequest("Name can not be empty");

        //var user = await _usersRepository.GetUserAsync(createListingCommand.User.Id);

        var missile = new Missile
        {
            Name = createMissileCommand.Name,
            Cooldown = createMissileCommand.Cooldown,
            MissileType = createMissileCommand.MissileType
        };

        await _missilesRepository.CreateMissileAsync(missile);
        return Created("", new Missile
        {
            Id = missile.Id,
            Name = missile.Name,
            Cooldown = missile.Cooldown,
            MissileType = missile.MissileType
        });
    }

    [HttpPut]
    [Route("{missileId}")]
    public async Task<ActionResult<Missile>> UpdateListingAsync(int missileId, UpdateShipCommand updateMissileCommand)
    {
        var missile = await _missilesRepository.GetMissileAsync(missileId);

        // 404 UpdateListingCommand(string? Name, double? EloFrom, double? EloTo);
        if (missile == null)
            return NotFound($"No missile with id of {missileId}");

        //var user = await _usersRepository.GetUserAsync(updateMissileCommand.playerTwo.Id);

        missile.Name = updateMissileCommand.Name is null ? missile.Name : updateMissileCommand.Name;
        missile.Cooldown = (int)(updateMissileCommand.Cooldown is null ? missile.Cooldown : updateMissileCommand.Cooldown);
        //missile.MissileType = (Data.Enums.MissileType)updateMissileCommand.MissileType ? updateMissileCommand.MissileType : missile.MissileType;

        await _missilesRepository.UpdateMissileAsync(missile);

        return Ok(new Missile
        {
            Id = missile.Id,
            Name = missile.Name,
            Cooldown = missile.Cooldown,
            MissileType = missile.MissileType
        });
    }

    [HttpDelete("{missileId}")]
    public async Task<ActionResult> Remove(int missileId)
    {
        var missile = await _missilesRepository.GetMissileAsync(missileId);

        // 404
        if (missile == null)
            return NotFound($"No missile with id of {missileId}"); ;

        await _missilesRepository.DeleteMissileAsync(missile);


        // 204
        return NoContent();
    }
}
