using BattleShipV3.Models;

namespace BattleShipV3.Client.DesignPatterns.Decorator
{
    public class EloToDecorator : Decorator
    {
        protected double _eloTo { get; set; }
        public EloToDecorator(CreateListingComponent component, double eloTo) : base(component)
        {
            this._eloTo = eloTo;
        }
        public override Listing GetCreatedListing()
        {
            Listing temp = this._component.GetCreatedListing();
            temp.EloTo = this._eloTo;
            return temp;
        }
    }
}
