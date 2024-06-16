using CRMClasses.Behavior;
using CRMClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniCRM.Patterns
{
    internal class BehaviorComponentContact : IBehaviorPattern
    {
        void IBehaviorPattern.Add(object entity)
        {
            if (entity is Contact contact)
            {
                new ContactBehavior().AddContact(contact);
                return;
            }
            throw new NotImplementedException();
        }

        void IBehaviorPattern.Remove(object entity)
        {
            if (entity is Contact contact)
            {
                new ContactBehavior().RemoveContact(contact);
                return;
            }
            throw new NotImplementedException();
        }

        void IBehaviorPattern.Update(object entity)
        {
            if (entity is Contact contact)
            {
                new ContactBehavior().UpdateContact(contact);
                return;
            } 
            throw new NotImplementedException();
        }
    }
}
