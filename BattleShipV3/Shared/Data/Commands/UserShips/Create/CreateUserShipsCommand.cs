using BattleShipV3.Data.Models;
using BattleShipV3;
using BattleShipV3.Shared;
using BattleShipV3.Shared.Data;
using BattleShipV3.Models;

namespace BattleShipV3.Shared.Data.Commands.UserShips.Create;

//public record CreateUserShipsCommand(BattleShipV3.Models.User User, BattleShipV3.Data.Models.Ship Ship);
public record CreateUserShipsCommand(int UserId, int ShipId);

public record CreateUserSelectedShipCommand(int userId, int shipId);
