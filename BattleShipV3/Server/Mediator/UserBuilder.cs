using BattleShipV3.Models;
using BattleShipV3.Shared.Data.Commands.User.Create;

namespace BattleShipV3.Server.Mediator
{
    public class UserBuilder : BaseComponent
    {
        public async Task<User> BuildUser(CreateUserCommand createUserCommand)
        {
            var user = new User
            {
                Name = createUserCommand.Name,
                Email = createUserCommand.Email,
                Password = createUserCommand.Password,
                CreationDate = DateTime.UtcNow,
                Elo = 0,
                Points = 0
            };

            return await this.mediator.notify(this, user);
        }
    }
}
