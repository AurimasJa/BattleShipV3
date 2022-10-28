using BattleShipV3.Server.Repositories;
using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Commands.UserShips.Get;
using BattleShipV3.Shared.Data.Commands.UserShips.Create;
using Microsoft.AspNetCore.Mvc;
using BattleShipV3.Shared.Data.Commands.User.Get;

namespace BattleShipV3.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserShipsController : ControllerBase
    {
        private readonly IUserShipsRepository _userShipsRepository;

        public UserShipsController(IUserShipsRepository userShipsRepository)
        {
            _userShipsRepository = userShipsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<GetUserShipsCommand>> GetUserShipsAsync()
        {
            var userShips = await _userShipsRepository.GetAllUserShipsAsync();
            return userShips.Select(x => new GetUserShipsCommand(x.Id, x.User, x.Ship));
        }

        [HttpPost]
        public async Task<ActionResult<GetUserShipsCommand>> CreateUserAsync(CreateUserShipsCommand createUserShipsCommand)
        {
            if (createUserShipsCommand == null)
            {
                return BadRequest("Error");
            }

            var userShips = new UserShip
            {
                User = createUserShipsCommand.User,
                Ship = createUserShipsCommand.Ship
            };

            await _userShipsRepository.CreateUserShipsAsync(userShips);
            return Created("", new GetUserShipsCommand(userShips.Id, userShips.User, userShips.Ship));
        }
    }
}
