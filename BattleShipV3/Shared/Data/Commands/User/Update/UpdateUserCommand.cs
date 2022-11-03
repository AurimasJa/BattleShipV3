
namespace BattleShipV3.Shared.Data.Commands.User.Update;

public record UpdateUserCommand(string? Name, string? Email, string? Password,int? Elo, int? Points);
