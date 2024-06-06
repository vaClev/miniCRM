using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniCRM.Patterns
{
    internal interface IBehaviorPattern
    {
        void Add(object entity);
        void Remove(object entity);
        void Update(object entity);
    }
}
