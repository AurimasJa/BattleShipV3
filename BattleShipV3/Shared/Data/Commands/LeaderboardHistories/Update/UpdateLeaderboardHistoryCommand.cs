
using BattleShipV3.Models;
using static BattleShipV3.Data.Enums;

public record UpdateLeaderboardHistoryCommand(DateTime DateFrom, DateTime DateTo, User? User);
