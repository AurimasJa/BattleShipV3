using BattleShipV3.Shared.Iterator;
using System.Collections;

namespace BattleShipV3.Client.DesignPatterns.Lab2.Composite
{
    public class Composite : Component, IEnumerable
    {   
        protected List<Component> children { get; set; } = new List<Component>();
        bool _direction = false;
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

        public IEnumerator GetEnumerator()
        {
            return new CompositeIterator(this, _direction);
        }
    }
}
