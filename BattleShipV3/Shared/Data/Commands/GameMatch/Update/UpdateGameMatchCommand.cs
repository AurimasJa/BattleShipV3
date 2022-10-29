
using BattleShipV3.Models;
using static BattleShipV3.Data.Enums;

public record UpdateGameMatchCommand(GameState GameState, User? UserWinner);
