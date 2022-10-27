namespace BattleShipV3.Shared.Data.Commands.User.Get;


public record GetUserCommand(int Id, string Name, string Email, string Password, DateTime CreationDate, double Elo, int Points);
