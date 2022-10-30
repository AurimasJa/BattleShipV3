
using BattleShipV3.Models;
using static BattleShipV3.Data.Enums;

public record GetGameMatchCommand(int Id, DateTime CreationDate, GameState GameState, Listing Listing, User? UserWinner);
