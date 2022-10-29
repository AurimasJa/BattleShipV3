
namespace BattleShipV3.Shared.Data.Commands.ShipPlacement.Update;

public record UpdateShipPlacementCommand(int XCoordinate, int YCoordinate, bool IsVerticalRotation);


//public int Id { get; set; }
//public int XCoordinate { get; set; }
//public int YCoordinate { get; set; }
//public bool IsVerticalRotation { get; set; }
//public Ship Ship { get; set; }
//public User User { get; set; }
//public GameMatch GameMatch { get; set; }