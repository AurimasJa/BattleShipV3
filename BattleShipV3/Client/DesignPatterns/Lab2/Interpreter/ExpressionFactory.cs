namespace BattleShipV3.Client.DesignPatterns.Lab2.Interpreter
{
    public class ExpressionFactory
    {
        public Expression GetExpression(string token)
        {
            Expression exp = new NullExpression();
            try
            {
                exp = new CoordinateExpression(token);
                return exp;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public Expression GetExpression(string token, Expression right, Action<int, int> fireFunc, Action<int, int> placeShipFnc)
        {
            Expression exp = new NullExpression();
            if (token.Equals("fire", StringComparison.OrdinalIgnoreCase))
                return new FireExpression(right, fireFunc);
            if (token.Equals("place", StringComparison.OrdinalIgnoreCase))
                return new PlaceShipExpression(right, placeShipFnc);

            return exp;
        }
    }
}
