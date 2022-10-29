
namespace BattleShipV3.Shared.Data.Commands.Listing.Update;

public record UpdateListingCommand(Models.User playerTwo, string? Name = null, double? EloFrom = null, double? EloTo = null);
