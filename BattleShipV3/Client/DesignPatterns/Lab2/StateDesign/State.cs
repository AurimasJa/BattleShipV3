namespace BattleShipV3.Client.DesignPatterns.Lab2.StateDesign
{
    public interface IState
    {
        void DisplayImage();
    }

    public class LargeImageState : IState
    {
        public void DisplayImage()
        {
            Console.WriteLine("Displaying large image");
        }
    }

    public class SmallImageState : IState
    {
        public void DisplayImage()
        {
            Console.WriteLine("Displaying small image");
        }
    }

    public class MediumImageState : IState
    {
        public void DisplayImage()
        {
            Console.WriteLine("Displaying medium image");
        }
    }

    public class NoImageState : IState
    {
        public void DisplayImage()
        {
            Console.WriteLine("No image to display");
        }
    }

    public class ImageContext
    {
        private IState _state;
        private IState _previousState;

        public ImageContext(IState state)
        {
            _state = state;
        }

        public void SetState(IState state)
        {
            _previousState = _state;
            _state = state;
        }

        public void DisplayImage()
        {
            _state.DisplayImage();
        }

        public void RevertToPreviousState()
        {
            _state = _previousState;
        }
    }
}
