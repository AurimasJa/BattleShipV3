using BattleShipV3.Shared.Data;
using BattleShipV3.Shared;
//using BattleShipV3.Data.Enums;

namespace BattleShipV3.Shared.Data.Commands.Missile.Create;

public record CreateShipCommand(string Name, int Cooldown, BattleShipV3.Data.Enums.MissileType MissileType);

//public int Id { get; set; }
//public string Name { get; set; }
//public int Cooldown { get; set; }
//public MissileType MissileType { get; set; }