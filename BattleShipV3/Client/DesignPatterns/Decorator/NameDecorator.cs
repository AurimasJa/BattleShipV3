using BattleShipV3.Models;

namespace BattleShipV3.Client.DesignPatterns.Decorator
{
    public class NameDecorator : Decorator
    {
        protected string _name { get; set; }
        public NameDecorator(CreateListingComponent component, string Name) : base(component)
        {
            this._name = Name;
        }
        public override Listing GetCreatedListing()
        {
            Listing temp = this._component.GetCreatedListing();
            temp.Name = this._name;
            return temp;
        }
    }
}
