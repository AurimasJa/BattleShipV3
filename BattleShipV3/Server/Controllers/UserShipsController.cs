using BattleShipV3.Server.Repositories;
using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Commands.UserShips.Get;
using BattleShipV3.Shared.Data.Commands.UserShips.Create;
using Microsoft.AspNetCore.Mvc;

namespace BattleShipV3.Server.Controllers
{
    [ApiController]
    [Route("/api/pointsshop")]
    public class UserShipsController : ControllerBase
    {
        private readonly IUserShipsRepository _userShipsRepository;

        public UserShipsController(IUserShipsRepository userShipsRepository)
        {
            _userShipsRepository = userShipsRepository;
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
