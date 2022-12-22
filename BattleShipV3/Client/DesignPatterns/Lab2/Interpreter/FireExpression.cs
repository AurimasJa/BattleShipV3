namespace BattleShipV3.Client.DesignPatterns.Lab2.Interpreter
{
    public class FireExpression : Expression
    {
        Expression right;
        Action<int, int> func;
        public FireExpression(Expression right, Action<int, int> func)
        {
            this.right = right;
            this.func = func;
        }
        public override (int, int) Execute()
        {
            var tuple = right.Execute();
            int x = tuple.Item1;
            int y = tuple.Item2;
            func(x,y);
            return (x, y);
        }
    }
}
