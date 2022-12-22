using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipV3.Shared.Iterator
{
    public abstract class IteratorAggregate : IEnumerable
    {
        // Returns an Iterator or another IteratorAggregate for the implementing
        // object.
        public virtual IEnumerator GetEnumerator()
        {
            yield break;
        }
    }
}
