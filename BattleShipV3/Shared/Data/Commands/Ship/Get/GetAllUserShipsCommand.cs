namespace BattleShipV3.Shared.Data.Commands.Ship.Get;


public record GetAllUserShipsCommand(int Id, string Name, int Length, BattleShipV3.Data.Models.Missile Missile);
//public int Id { get; set; }
//public string Name { get; set; }
//public int Length { get; set; }
//public Missile Missile { get; set; }