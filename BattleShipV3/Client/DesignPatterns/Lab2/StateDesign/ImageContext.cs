namespace BattleShipV3.Client.DesignPatterns.Lab2.StateDesign
{
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
