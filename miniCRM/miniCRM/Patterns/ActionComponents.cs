using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miniCRM.Components;

namespace miniCRM.Patterns
{
    internal class ActionComponents
    {
        UserControl userControl;
        public ActionComponents(UserControl userControl) 
        { 
            this.userControl = userControl;
        }

        public IBehaviorPattern? GetBehavior()
        {
            //Упрощеная связка по типу
            switch(userControl)
            {
                /*case PartnerControl:
                    return new BehaviorComponentPartner();*/
               
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
