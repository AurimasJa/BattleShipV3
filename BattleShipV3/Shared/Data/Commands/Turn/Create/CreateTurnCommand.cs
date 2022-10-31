
using BattleShipV3.Models;
using static BattleShipV3.Data.Enums;

public record CreateTurnCommand(int XCoordinate, int YCoordinate, TurnType TurnType, GameMatch GameMatch);
