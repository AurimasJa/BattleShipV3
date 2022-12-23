namespace BattleShipV3.Client.DesignPatterns.Lab2.State
{
    public class LoginState : State1
    {
        public override void SetRenderFragment()
        {
            this._context.TransitionTo(new LoginState());
        }
    }
}
