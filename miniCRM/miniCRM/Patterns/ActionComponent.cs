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
                case PartnerControl:
                    return new BehaviorComponentPartner();

                case DealHeaderControl:
                    return new BehaviorComponentDeal();

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
