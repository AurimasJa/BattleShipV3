
using BattleShipV3.Models;
using static BattleShipV3.Data.Enums;

public record CreateLeaderboardHistoryCommand(DateTime DateFrom, DateTime DateTo, User? User);
