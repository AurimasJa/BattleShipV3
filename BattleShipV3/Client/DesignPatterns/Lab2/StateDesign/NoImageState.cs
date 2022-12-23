namespace BattleShipV3.Client.DesignPatterns.Lab2.StateDesign
{
    public class NoImageState : IState
    {
        public void DisplayImage()
        {
            Console.WriteLine("No image to display");
        }
    }
}
