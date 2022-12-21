using BattleShipV3.Models;
using BattleShipV3.Server.Repositories;
using BattleShipV3.Shared.Data.Commands.User.Create;

namespace BattleShipV3.Server.Mediator
{
    public class UserMediator : IMediator
    {
        private UsersRepository repo { get; set; }
        private CreateUserValidator validator { get; set; }
        private UserBuilder builder { get; set; }

        public UserMediator(IUsersRepository repo, CreateUserValidator validator, UserBuilder builder)
        {
            this.repo = (UsersRepository?)repo;
            this.repo.SetMediator(this);
            this.validator = validator;
            this.validator.SetMediator(this);
            this.builder = builder;
            this.builder.SetMediator(this);
        }

        public async Task<User> notify(object sender, object data)
        {
            if(data.GetType().Equals(typeof(CreateUserCommand)))
            {
                await builder.BuildUser((CreateUserCommand)data);
            }
            if(data.GetType().Equals(typeof(User)))
            {
                return await repo.CreateUserAsync((User)data);
            }
            throw new ArgumentException("Mediator Failed");
        }
    }
}
