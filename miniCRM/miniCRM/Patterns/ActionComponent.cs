using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miniCRM.Components;
using miniCRM.Components.EditControls;

namespace miniCRM.Patterns
{
    internal class ActionComponent
    {
        UserControl userControl;
        public ActionComponent(UserControl userControl) 
        { 
            this.userControl = userControl;
        }

        public IBehaviorPattern? GetBehavior()
        {
            //Упрощеная связка по типу
            switch(userControl)
            {
                case PartnerHeaderControl:
                    return new BehaviorComponentPartner();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
