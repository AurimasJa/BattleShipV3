using BattleShipV3.Models;
using BattleShipV3.Shared.Data.Commands.User.Create;
using Microsoft.AspNetCore.Mvc;

namespace BattleShipV3.Server.Mediator
{
    public class CreateUserValidator :  BaseComponent
    {
        public async Task<User> ValidateForBadRequest(CreateUserCommand createUserCommand)
        {
            if (createUserCommand == null)
            {
                throw new ArgumentException("Command is null");
            }

            if (createUserCommand.Name == null)
                throw new ArgumentException("Name can not be empty");
            if (createUserCommand.Password == null)
                throw new ArgumentException("Password can not be empty");
            if (createUserCommand.Email == null || !(createUserCommand.Email.Contains('@')))
                throw new ArgumentException("Email is not valid");
            if (createUserCommand.Password.Length < 3)
                throw new ArgumentException("Your password is too short");


            var User = new User
            {
                Name = createUserCommand.Name,
                Email = createUserCommand.Email,
                Password = createUserCommand.Password,
                CreationDate = DateTime.UtcNow,
                Elo = 0,
                Points = 0
            };


            return await this.mediator.notify(this, User);
        }
    }
}
