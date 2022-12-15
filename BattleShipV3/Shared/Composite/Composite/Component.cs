namespace BattleShipV3.Client.DesignPatterns.Lab2.Composite
{
    public abstract class Component
    {
        public virtual void Add(Component component)
        {

        }
        public virtual void Remove(Component component)
        {

        }
        public virtual bool IsComposite()
        {
            return true;
        }
    }
}
