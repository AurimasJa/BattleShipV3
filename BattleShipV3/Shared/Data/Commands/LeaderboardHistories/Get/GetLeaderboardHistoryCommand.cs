
using BattleShipV3.Models;
using static BattleShipV3.Data.Enums;

public record GetLeaderboardHistoryCommand(int Id, DateTime DateFrom, DateTime DateTo, User? User);
