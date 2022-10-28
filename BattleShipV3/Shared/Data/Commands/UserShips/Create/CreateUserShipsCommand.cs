using BattleShipV3.Data.Models;

namespace BattleShipV3.Shared.Data.Commands.UserShips.Create;

public record CreateUserShipsCommand(Models.User User, Ship Ship);
