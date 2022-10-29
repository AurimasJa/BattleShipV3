using BattleShipV3.Shared.Data;

namespace BattleShipV3.Shared.Data.Commands.ShipPlacement.Get;

public record GetShipPlacementCommand(int Id, int XCoordinate, int YCoordinate, bool IsVerticalRotation, BattleShipV3.Data.Models.Ship Ship, Models.User User, Models.GameMatch gameMatch);

//public int Id { get; set; }
//public int XCoordinate { get; set; }
//public int YCoordinate { get; set; }
//public bool IsVerticalRotation { get; set; }
//public Ship Ship { get; set; }
//public User User { get; set; }
//public GameMatch GameMatch { get; set; }