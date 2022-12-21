namespace BattleShipV3.Server.Mediator
{
    public class BaseComponent
    {
        protected IMediator mediator { get;set; }

        public BaseComponent(IMediator mediator = null)
        {
            this.mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }


}
