using BattleShipV3.Data.Models;
using BattleShipV3.Shared.Data.Interfacess;

namespace BattleShipV3.Client.DesignPatterns.Lab2.Template
{
    public abstract class TemplateBase
    {
        protected Ship ship { get; set; }
        protected IPurchase purchase { get; set; }
        protected double Discount { get; set; }
        public TemplateBase(Ship ship)
        {
            this.ship = ship;
        }
        //TemplateMethod
        public IPurchase GetPurchase()
        {
            this.InstantiatePurchase();
            this.SetDiscount();
            this.SetCost();
            return this.purchase;
        }
        protected abstract void SetCost();
        protected abstract void InstantiatePurchase();
        protected virtual void SetDiscount()
        {
            this.Discount = 0;
        }
    }
}
