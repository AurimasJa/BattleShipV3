using BattleShipV3.Server.Repositories;
using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Commands.UserShips.Get;
using BattleShipV3.Shared.Data.Commands.UserShips.Create;
using Microsoft.AspNetCore.Mvc;
using BattleShipV3.Shared.Data.Commands.User.Get;
using BattleShipV3.Shared.Data.Commands.Listing.Create;

namespace BattleShipV3.Server.Controllers
{
    [ApiController]
    [Route("/pointsshop")]
    public class UserShipsController : ControllerBase
    {
        private readonly IUserShipsRepository _userShipsRepository;
        private readonly IUsersRepository _usersRepository;

        public UserShipsController(IUserShipsRepository userShipsRepository, IUsersRepository usersRepository)
        {
            _userShipsRepository = userShipsRepository;
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<GetUserShipsCommand>> GetUserShipsAsync()
        {
            var userShips = await _userShipsRepository.GetAllUserShipsAsync();
            return userShips.Select(x => new GetUserShipsCommand(x.Id, x.User, x.Ship));
        }

        [HttpPost]
        public async Task<ActionResult<GetUserShipsCommand>> CreateUserShipsAsync(CreateUserShipsCommand createUserShipsCommand)
        {
            if (createUserShipsCommand == null)
            {
                return BadRequest("Error");
            }

            var user = await _usersRepository.GetUserAsync(createUserShipsCommand.User.Id);

            var userShips = new UserShip
            {
                User = user,
                Ship = createUserShipsCommand.Ship
            };

            await _userShipsRepository.CreateUserShipsAsync(userShips);
            return Created("", new GetUserShipsCommand(userShips.Id, userShips.User, userShips.Ship));
        }
    }
}
