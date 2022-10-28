using BattleShipV3.Data.Models;

namespace BattleShipV3.Shared.Data.Commands.UserShips.Get;

public record GetUserShipsCommand(int Id, Models.User User, Ship Ship);