using BattleShipV3.Client.Pages;

namespace BattleShipV3.Client.DesignPatterns.Lab2.State
{
    public abstract class State1
    {
        protected IndexView _context;

        public void SetContext(IndexView context)
        {
            this._context = context;
        }

        public abstract void SetRenderFragment();
    }
}
