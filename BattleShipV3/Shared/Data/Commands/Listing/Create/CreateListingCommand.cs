using BattleShipV3.Shared.Data;

namespace BattleShipV3.Shared.Data.Commands.Listing.Create;

public record CreateListingCommand(string Name, double EloFrom, double EloTo);