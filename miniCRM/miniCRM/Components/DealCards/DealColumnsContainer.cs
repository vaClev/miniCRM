using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniCRM.Components.DealCards
{
    internal class DealColumnsContainer: IEnumerable<DealsColumn>
    {
        List<DealsColumn> columns = new List<DealsColumn>();
        public void Add(DealsColumn dealsColumn)
        {
            columns.Add(dealsColumn);
        }
        public DealsColumn? GetByIndex(int index)
        {
            if (columns.Count == 0) return null;
            return columns[index];
        }
        public IEnumerator<DealsColumn> GetEnumerator()
        {
            return columns.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return columns.GetEnumerator();
        }
    }
}
