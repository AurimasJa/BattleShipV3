using BattleShipV3.Client.DesignPatterns.Facade;
using BattleShipV3.Client.DesignPatterns.Factory;
using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Interfacess;
using BattleShipV3.Shared;
using static BattleShipV3.Data.Enums;

namespace BattleShipV3.Client.Pages.PointsShop
{
    partial class PointsShop
    {
        List<Ship> ownedShips { get; set; }
        List<Ship> ships { get; set; }
        Ship selectedShip { get; set; }

        PurchaseType? purchaseType { get; set; } = PurchaseType.POINTS;
        Facade facade { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if (Global.CurrentUser is null)
            {
                Navigation.NavigateTo("/login");
                return;
            }
            ownedShips = await shipService.GetShipsByUserAsync(Global.CurrentUser.Id);
            ships = await shipService.GetShipsAsync();
            facade = new Facade(userShipsService, shipService, userService);
            await InvokeAsync(StateHasChanged);
            StateHasChanged();
        }

        public void SetPurchaseType(PurchaseType type)
        {
            this.purchaseType = type;
            StateHasChanged();
        }

        protected string GetCost(Ship ship)
        {
            IPurchase purchase;
            if (ship is null)
                return "";

            switch (purchaseType)
            {
                case PurchaseType.TICKET:
                    purchase = CreatePurchase(new TicketPurchaseFactory(), ship);
                    break;
                case PurchaseType.CASH:
                    purchase = CreatePurchase(new CashPurchaseFactory(), ship);
                    break;
                default:
                    purchase = CreatePurchase(new PointsPurchaseFactory(), ship);
                    break;

            }
            if (purchaseType == PurchaseType.CASH)
                return "$" + purchase.Cost;

            return purchase.Cost.ToString();
        }

        protected async Task BuyShip()
        {
            IPurchase purchase;

            switch (purchaseType)
            {
                case PurchaseType.TICKET:
                    purchase = CreatePurchase(new TicketPurchaseFactory(), selectedShip);
                    break;
                case PurchaseType.CASH:
                    purchase = CreatePurchase(new CashPurchaseFactory(), selectedShip);
                    break;
                default:
                    purchase = CreatePurchase(new PointsPurchaseFactory(), selectedShip);
                    break;
            }

            await facade.HandleShipPurchase(purchase, purchaseType.Value, selectedShip, ownedShips);
            await InvokeAsync(StateHasChanged);
        }

        protected IPurchase CreatePurchase(Factory factory, Ship ship)
        {
            IPurchase purchase = factory.GetCreatedPurchase(ship);
            return purchase;
        }

        private bool FilterFunc(Ship element)
        {
            if (ownedShips.Any(e => e.Id == element.Id))
                return false;
            return true;
        }
    }
}
