using BattleShipV3.Shared.Data;

namespace BattleShipV3.Shared.Data.Commands.Listing.Get;


public record GetListingCommand(int Id, string Name, double? EloFrom, double? EloTo, DateTime CreationDate, Models.User PlayerOne, Models.User? PlayerTwo);