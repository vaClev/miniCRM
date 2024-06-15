using CRMClasses.Behavior;
using CRMClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniCRM.Patterns
{
    internal class BehaviorComponentDeal:IBehaviorPattern
    {
        void IBehaviorPattern.Add(object entity)
        {
            if (entity is Deal deal)
            {
                new DealBehavior().AddDeal(deal);
                return;
            }
            throw new NotImplementedException();
        }

        void IBehaviorPattern.Remove(object entity)
        {
            if (entity is Deal deal)
            {
                new DealBehavior().RemoveDeal(deal);
                return;
            }
            throw new NotImplementedException();
        }

        void IBehaviorPattern.Update(object entity)
        {
            if (entity is Deal deal)
            {
                new DealBehavior().UpdateDeal(deal);
                return;
            }
            throw new NotImplementedException();
        }
    }
}
