namespace BattleShipV3.Client.Pages.GameMatches
{
    public class DataGenerator
    {
        public static Task<List<GridModels.Square>> GenerateSquares()
        {
            var result = new List<GridModels.Square>();
            int cur_x = 0;
            int cur_y = 0;

            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    cur_x += 25;
                    cur_y = 0;

                }
                result.Add(new GridModels.Square() { Id = Guid.NewGuid().ToString(), X = cur_x, Y = cur_y });
                cur_y += 25;
            }
            return Task.FromResult(result);
        }

        public static async Task<bool> GenerateShips(List<GridModels.Square> squareList)
        {
            var rnd = new Random();
            try
            {
                Console.WriteLine(await AddShip(5, squareList.Find(o => o.X == 25 * 2 && o.Y == 25), squareList));
                Console.WriteLine(await AddShip(4, squareList.Find(o => o.X == 25 && o.Y == 25 * 3), squareList, true));
                Console.WriteLine(await AddShip(3, squareList.Find(o => o.X == 25 * 4 && o.Y == 25 * 5), squareList));
                Console.WriteLine(await AddShip(3, squareList.Find(o => o.X == 25 * 4 && o.Y == 25 * 6), squareList));
                Console.WriteLine(await AddShip(2, squareList.Find(o => o.X == 25 * 8 && o.Y == 25 * 8), squareList, true));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return true;
        }
        public static Task<bool> AddShip(int squarecount, GridModels.Square firstsquare, List<GridModels.Square> squarelist, bool is_vertical = false)
        {
            if (is_vertical)
            {
                if (firstsquare.Y + 25 * squarecount <= 250)
                {
                    int next_y = firstsquare.Y;
                    //v
                    for (int i = 0; i < squarecount; i++)
                    {
                        if (squarelist.Find(s => s.X == firstsquare.X && s.Y == next_y).Is_Ship == true)
                        {
                            return Task.FromResult(false);
                        }
                        next_y += 25;
                    }
                    next_y = firstsquare.Y;
                    for (int i = 0; i < squarecount; i++)
                    {
                        squarelist.Find(s => s.X == firstsquare.X && s.Y == next_y).Is_Ship = true;
                        next_y += 25;
                    }
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            }
            else
            {
                if (firstsquare.X + 25 * (squarecount - 1) <= 250)
                {
                    int next_x = firstsquare.X;
                    //v
                    for (int i = 0; i < squarecount; i++)
                    {
                        if (squarelist.Find(s => s.Y == firstsquare.Y && s.X == next_x).Is_Ship == true)
                        {
                            return Task.FromResult(false);
                        }
                        next_x += 25;
                    }
                    next_x = firstsquare.X;
                    for (int i = 0; i < squarecount; i++)
                    {
                        squarelist.Find(s => s.Y == firstsquare.Y && s.X == next_x).Is_Ship = true;
                        next_x += 25;
                    }
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            }
            //return Task.FromResult(false);
        }



    }
}
