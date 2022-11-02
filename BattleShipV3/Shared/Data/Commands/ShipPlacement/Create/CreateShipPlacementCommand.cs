using BattleShipV3.Models;
using BattleShipV3.Shared.Data;

namespace BattleShipV3.Shared.Data.Commands.ShipPlacement.Create;

public record CreateShipPlacementCommand(int XCoordinate, int YCoordinate, bool IsVerticalRotation,
    BattleShipV3.Data.Models.Ship Ship, BattleShipV3.Models.User User, GameMatch gameMatch);


