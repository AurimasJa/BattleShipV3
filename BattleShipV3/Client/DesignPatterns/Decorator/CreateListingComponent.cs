using BattleShipV3.Models;

namespace BattleShipV3.Client.DesignPatterns.Decorator
{
    public class CreateListingComponent
    {
        public Listing Listing { get; set; }
        public CreateListingComponent()
        {
            Listing = new Listing();
        }

        public virtual Listing GetCreatedListing()
        {
            return this.Listing;
        }
    }
}
