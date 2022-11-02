using BattleShipV3.Server.Repositories;
using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Commands.UserShips.Create;
using Microsoft.AspNetCore.Mvc;
using BattleShipV3.Shared.Data.Commands.Listing.Create;

namespace BattleShipV3.Server.Controllers
{
    [ApiController]
    [Route("/pointsshop")]
    public class UserShipsController : ControllerBase
    {
        private readonly IUserShipsRepository _userShipsRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IShipsRepository _shipsRepository;

        public UserShipsController(IUserShipsRepository userShipsRepository, IUsersRepository usersRepository, IShipsRepository shipsRepository)
        {
            _userShipsRepository = userShipsRepository;
            _usersRepository = usersRepository;
            _shipsRepository = shipsRepository;
        }

        //[HttpGet]
        //public async Task<IEnumerable<UserShip>> GetUserShipsAsync()
        //{
        //    var userShips = await _userShipsRepository.GetAllUserShipsAsync();
        //    return userShips.Select(x => new UserShip
        //    {
        //        Id = x.Id,
        //        Ship = x.Ship,
        //        User = x.User
        //    });
        //}

        [HttpGet]
        public async Task<string> GetUserShipsAsync()
        {
            var userShips = await _userShipsRepository.GetAllUserShipsAsync();
            var selected = userShips.Select(x => new UserShip
            {
                Id = x.Id,
                Ship = x.Ship,
                User = x.User
            });
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(selected);
            return json;
        }

        [HttpPost]
        public async Task<ActionResult<UserShip>> CreateUserShipsAsync(CreateUserShipsCommand createUserShipsCommand)
        {
            if (createUserShipsCommand == null)
            {
                return BadRequest("Error");
            }

            var user = await _usersRepository.GetUserAsync(createUserShipsCommand.User.Id);
            var ship = await _shipsRepository.GetShipAsync(createUserShipsCommand.Ship.Id);

            var userShips = new UserShip
            {
                User = user,
                Ship = ship
            };

            await _userShipsRepository.CreateUserShipsAsync(userShips);
            return Created("", new UserShip
            {
                Id = userShips.Id,
                Ship = userShips.Ship,
                User = userShips.User
            });
        }
    }
}
