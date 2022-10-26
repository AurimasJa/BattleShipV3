﻿using BattleShipV3.Server.Repositories;
using BattleShipV3.Models;
using BattleShipV3.Shared.Data.Commands.User.Get;
using BattleShipV3.Shared.Data.Commands.User.Create;
using Microsoft.AspNetCore.Mvc;
using BattleShipV3.Shared.Data.Commands.User.Update;

namespace BattleShipV3.Server.Controllers;

[ApiController]
[Route(("api/users"))]
public class UsersController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;

    public UsersController(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetUserCommand>> GetUserAsync(int? id, string? email)
    {
        var user = await _usersRepository.GetUserAsync(id, email);
        if (user == null)
            return NotFound($"User does not exist");

        return new GetUserCommand(user.Id, user.Name, user.Email, user.CreationDate, user.Elo, user.Points);
    }

    [HttpGet]
    public async Task<IEnumerable<GetUserCommand>> GetUsersAsync()
    {
        var users = await _usersRepository.GetAllUsersAsync();
        return users.Select(x => new GetUserCommand(x.Id, x.Name, x.Email, x.CreationDate, x.Elo, x.Points));
    }

    [HttpPost]
    public async Task<ActionResult<GetUserCommand>> CreateUserAsync(CreateUserCommand createUserCommand)
    {
        if(createUserCommand == null)
        {
            return BadRequest("Error");
        }

        if (createUserCommand.Name == null)
            return BadRequest("Name can not be empty");
        if (createUserCommand.Password == null)
            return BadRequest("Password can not be empty");
        if (createUserCommand.Email == null || !(createUserCommand.Email.Contains('@')))
            return BadRequest("Email is not valid");
        if (createUserCommand.Password.Length < 3)
            return BadRequest("Your password is too short");

        var user = new User
        {
            Name = createUserCommand.Name,
            Email = createUserCommand.Email,
            Password = createUserCommand.Password,
            CreationDate = DateTime.UtcNow,
            Elo = 0,
            Points = 0
        };

        await _usersRepository.CreateUserAsync(user);
        return Created("", new GetUserCommand(user.Id, user.Name, user.Email, user.CreationDate, user.Elo, user.Points));
    }

    [HttpPut]
    [Route("{userId}")]
    public async Task<ActionResult<GetUserCommand>> UpdateUserAsync(int userId, UpdateUserCommand updateUserCommand)
    {
        var user = await _usersRepository.GetUserAsync(userId, null);

        // 404
        if (user == null)
            return NotFound($"No user with id of {userId}");
        if (updateUserCommand.Email is not null && updateUserCommand.Email.Contains('@'))
        {
            return BadRequest("Email is not valid");
        }
        if (updateUserCommand.Password is not null && updateUserCommand.Password.Length < 3)
        {
            return BadRequest("Your password is too short");
        }
        else
        {
            user.Name = updateUserCommand.Name is null ? user.Name : updateUserCommand.Name;
            user.Email = updateUserCommand.Email is null ? user.Email : updateUserCommand.Email;
            user.Password = updateUserCommand.Password is null ? user.Password : updateUserCommand.Password;

            await _usersRepository.UpdateUserAsync(user);

            return Ok(new GetUserCommand(user.Id, user.Name, user.Email, user.CreationDate, user.Elo, user.Points));
        }
    }

    [HttpDelete("{userId}")]
    public async Task<ActionResult> Remove(int userId)
    {
        var user = await _usersRepository.GetUserAsync(userId, null);

        // 404
        if (user == null)
            return NotFound($"No user with id of {userId}"); ;

        await _usersRepository.DeleteUserAsync(user);


        // 204
        return NoContent();
    }
}