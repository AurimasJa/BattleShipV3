using BattleShipV3.Models;

namespace BattleShipV3.Client.DesignPatterns.Decorator
{
    public abstract class Decorator : CreateListingComponent
    {
        protected CreateListingComponent _component { get; set; }
        public Decorator(CreateListingComponent component)
        {
            this._component = component;
        }

        public override Listing GetCreatedListing()
        {
            return this._component.GetCreatedListing();
        }

    }
}
