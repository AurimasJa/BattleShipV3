namespace BattleShipV3.Client.DesignPatterns.Lab2.Interpreter
{
    public class CoordinateExpression : Expression
    {
        int x { get; set; }
        int y { get; set; }
        public CoordinateExpression(string token)
        {
            try
            {
                List<string> values = token.Split(',').ToList();
                if(values.Count != 2)
                    throw new ArgumentException("Wrong coordinates format");
                

                x = int.Parse(values[0]) - 1;
                y = int.Parse(values[1]) - 1;


                if (x < 1 || x > 10 || y < 1 || y > 10)
                    throw new ArgumentException("Coordinates should be within the boundaries of [1;10]");
            }
            catch
            {
                throw new ArgumentException("Wrong coordinates format");
            }
        }
        public override (int, int) Execute()
        {
            return (x,y);
        }
    }
}
