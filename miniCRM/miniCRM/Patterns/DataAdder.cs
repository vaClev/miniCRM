using miniCRM.Components.EditControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniCRM.Patterns
{
    internal static class DataAdder
    {
        public static void ActAdd(UserControl userControl)
        {
            var act = new ActionComponent(userControl);
            var behave = act.GetBehavior();
            if (userControl is IModelComponent component)
                behave?.Add(component.Get());
        }
    }
}
