namespace BattleShipV3.Client.DesignPatterns.Lab2.Interpreter
{
    public abstract class Expression
    {
        public abstract (int, int) Execute();
        public bool IsCoordinates(string token)
        {
            return (token.Contains(',') && char.IsDigit(token[0]) && char.IsDigit(token[2]));
        }
    }
}
