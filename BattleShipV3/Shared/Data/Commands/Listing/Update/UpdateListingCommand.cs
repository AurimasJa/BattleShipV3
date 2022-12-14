
namespace BattleShipV3.Shared.Data.Commands.Listing.Update;

public record UpdateListingCommand(BattleShipV3.Models.User playerTwo = null, string? Name = null,
    double? EloFrom = null, double? EloTo = null, bool removePlayerTwo = false);
