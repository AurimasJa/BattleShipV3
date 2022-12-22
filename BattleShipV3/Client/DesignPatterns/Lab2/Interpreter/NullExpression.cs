namespace BattleShipV3.Client.DesignPatterns.Lab2.Interpreter
{
    public class NullExpression : Expression
    {
        public override (int, int) Execute()
        {
            return (-1, -1);
        }
    }
}
