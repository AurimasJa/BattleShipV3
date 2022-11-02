namespace BattleShipV3.Client.Pages.GameMatches
{
    public class GridModels
    {
        public class Square
        {
            public string Id { get; set; }
            public bool Is_Ship { get; set; }
            public bool Is_Destroyed { get; set; }
            public bool Is_Empty { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
