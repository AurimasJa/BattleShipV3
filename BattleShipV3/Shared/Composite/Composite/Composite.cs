using System.Collections;

namespace BattleShipV3.Client.DesignPatterns.Lab2.Composite
{
    public class Composite : Component
    {
        protected List<Component> children { get; set; } = new List<Component>();

        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public IEnumerable<Component> GetChildren()
        {
            foreach (var item in children)
            {
                yield return item;
            }
        }
    }
}
