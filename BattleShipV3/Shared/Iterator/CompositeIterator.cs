using BattleShipV3.Client.DesignPatterns.Lab2.Composite;
using BattleShipV3.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Iterator
{
    public class CompositeIterator : Iterator
    {
        private Composite _collection;
        private Component _current;
        private List<Component> _components;
        // Stores the current traversal position. An iterator may have a lot of
        // other fields for storing iteration state, especially when it is
        // supposed to work with a particular kind of collection.
        private int _position = -1;

        private bool _reverse = false;

        public CompositeIterator(Composite collection, bool reverse = false)
        {
            Console.WriteLine("BUILDING");
            _collection = collection;
            _reverse = reverse;
            _components = new List<Component>();
            BuildList(_collection, _components);
            if (reverse)
            {
                _position = collection.GetChildren().Count();
            }
        }

        public override object Current()
        {
            return _components.ElementAt(_position);
        }

        private void BuildList(Component root, List<Component> components)
        {
            if (((Composite)root).GetChildren() != null && ((Composite)root).GetChildren().Any())
            {
                var items = ((Composite)root).GetChildren();
                if (items.FirstOrDefault().IsComposite())
                {
                    foreach (var item in items)
                    {
                        BuildList(item, components);
                    }
                }
                else
                {
                    components.AddRange(items);
                }
            }
        }

        public override int Key()
        {
            return _position;
        }

        public override bool MoveNext()
        {
            int updatedPosition = _position + (_reverse ? -1 : 1);

            if (updatedPosition >= 0 && updatedPosition < _components.Count())
            {
                _position = updatedPosition;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            //_position = _reverse ? _collection.GetEnumerator().Count() - 1 : 0;
            _position = -1;
        }
    }

}
