using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniCRM.Components.EditControls
{
    public interface IModelComponent
    {
        void Set(object obj);
        object Get();
    }
}
