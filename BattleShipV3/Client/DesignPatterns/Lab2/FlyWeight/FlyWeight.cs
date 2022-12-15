using BattleShipV3.Client.DesignPatterns.Prototype;
using BattleShipV3.Models;
using Newtonsoft.Json;

namespace BattlePlaySquareV3.Client.DesignPatterns.Lab2.FlyWeight
{
    public class FlyWeight
    {
        private PlaySquare _sharedState;

        public FlyWeight(PlaySquare PlaySquare)
        {
            _sharedState = PlaySquare;
        }


        public (PlaySquare, PlaySquare) GetCopies()
        {
            return (_sharedState.DeepCopy(), _sharedState.ShallowCopy());
        }
    }

    public class FlyWeightFactory
    {
        private List<Tuple<FlyWeight, string>> flyWeights = new List<Tuple<FlyWeight, string>>();

        public FlyWeightFactory(params PlaySquare[] args)
        {
            foreach (var elem in args)
            {
                flyWeights.Add(new Tuple<FlyWeight, string>(new FlyWeight(elem), this.getKey(elem)));
            }
        }

        // Returns a Flyweight's string hash for a given state.
        public string getKey(PlaySquare key)
        {
            List<string> elements = new List<string>();

            elements.Add(key.squareAction);
            elements.Add(key.squareXcoor.ToString());
            elements.Add(key.squareYcoor.ToString());

            elements.Sort();

            return string.Join("_", elements);
        }
        public FlyWeight GetFlyweight(PlaySquare sharedState)
        {
            string key = this.getKey(sharedState);

            if (flyWeights.Where(t => t.Item2 == key).Count() == 0)
            {
                Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
                this.flyWeights.Add(new Tuple<FlyWeight, string>(new FlyWeight(sharedState), key));
            }
            else
            {
                Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
            }
            return this.flyWeights.Where(t => t.Item2 == key).FirstOrDefault().Item1;
        }

        public void ListFlyweights()
        {
            var count = flyWeights.Count;
            Console.WriteLine($"\nFlyweightFactory: I have {count} flyweights:");
            foreach (var flyweight in flyWeights)
            {
                Console.WriteLine(flyweight.Item2);
            }
        }
    }
}
