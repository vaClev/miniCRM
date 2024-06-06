using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMClasses.Behavior;
using CRMClasses.Models;


namespace miniCRM.Patterns
{
    internal class BehaviorComponentPartner : IBehaviorPattern
    {
        void IBehaviorPattern.Add(object entity)
        {
            if (entity is Partner partner)
            {
                new PartnerBehavior().AddPartner(partner);
                return;
            }
            throw new NotImplementedException();
        }

        void IBehaviorPattern.Remove(object entity)
        {
            if (entity is Partner partner)
            {
                new PartnerBehavior().RemovePartner(partner);
                return;
            }
            throw new NotImplementedException();
        }

        void IBehaviorPattern.Update(object entity)
        {
            if (entity is Partner partner)
            {
                new PartnerBehavior().UpdatePartner(partner);
                return;
            }
            throw new NotImplementedException();
        }
    }
}
