namespace BattleShipV3.Client.DesignPatterns.Lab2.State
{
    public class LoginState : State
    {
        public override void SetRenderFragment()
        {
            this._context.TransitionTo(new LoginState());
        }
    }
}
