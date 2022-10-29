namespace BattleShipV3.Shared.Data.Commands.Missile.Get;


public record GetMissileCommand(int Id, string Name, int Cooldown, BattleShipV3.Data.Enums.MissileType MissileType);
//public int Id { get; set; }
//public string Name { get; set; }
//public int Cooldown { get; set; }
//public MissileType MissileType { get; set; }