
using BattleShipV3.Models;
using static BattleShipV3.Data.Enums;

public record GetTurnCommand(int Id, int XCoordinate, int YCoordinate, TurnType TurnType, GameMatch GameMatch);