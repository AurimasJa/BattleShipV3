using BattleShipV3.Data.Models;

namespace BattleShipV3.Shared.Data.Commands.Ship.Create;

public record CreateShipCommand(string Name, int Length, BattleShipV3.Data.Models.Missile Missile);
