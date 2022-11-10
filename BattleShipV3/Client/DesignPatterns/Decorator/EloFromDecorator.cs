using BattleShipV3.Models;

namespace BattleShipV3.Client.DesignPatterns.Decorator
{
    public class EloFromDecorator : Decorator
    {
        protected double _eloFrom { get; set; }
        public EloFromDecorator(CreateListingComponent component, double eloFrom) : base(component)
        {
            this._eloFrom = eloFrom;
        }
        public override Listing GetCreatedListing()
        {
            Listing temp = this._component.GetCreatedListing();
            temp.EloFrom = this._eloFrom;
            return temp;
        }
    }
}
