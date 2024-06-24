using CRMClasses.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMClasses.Behavior
{
    public class ContactBehavior
    {
        DBContextClass DBContext;
        public ContactBehavior()
        {
            DBContext = new DBContextClass();
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return DBContext.Contacts.Include(c => c.Partner).Include(c=>c.Deal);
        }
        public IEnumerable<Contact> GetContactsByDeal(Deal deal)
        {
            return DBContext.Contacts.Include(c => c.Partner).Include(c => c.Deal).Where<Contact>(c=>c.Deal != null? c.Deal.Id==deal.Id : false); //проверить c null сделками
        }
        public IEnumerable<Contact> GetContactsByPartner(Partner partner)
        {
            return DBContext.Contacts.Include(c => c.Partner).Include(c => c.Deal).Where<Contact>(c => c.Partner.Id == partner.Id);
        }
        public Contact? GetContact(Guid Id)
        {
            return DBContext.Contacts.Include(c => c.Partner).Include(c => c.Deal).FirstOrDefault(p => p.Id == Id);
        }

        public void AddContact(Contact contact)
        {
            //проверка на привязку к контрагенту
            Partner? partner = new PartnerBehavior().GetPartner(contact.Partner.Id);
            if (partner != null)
            {
                DBContext.Attach(contact.Partner);
                if (contact.Deal == null)
                {
                    DBContext.Contacts.Add(contact);
                    DBContext.SaveChanges();
                }
                if (contact.Deal != null) 
                {
                    Deal temp = contact.Deal;
                    contact.Deal = null;
                    DBContext.Contacts.Add(contact);
                    DBContext.SaveChanges();

                    /*var ContactToChange = DBContext.Contacts.FirstOrDefault(p => p.Id == contact.Id);
                    ContactToChange.Deal = temp;
                    DBContext.Attach(temp);
                    DBContext.SaveChanges();*/
                }
                return;
            }
            throw new ArgumentException("попытка добавления контакта к несуществующему в репозитории контрагенту");
        }
        public void RemoveContact(Contact contact)
        {
            DBContext.Contacts.Remove(contact);
            DBContext.SaveChanges();
        }
        public void UpdateContact(Contact contact)
        {
            if (DBContext.Contacts.Any(p => p.Id == contact.Id))
            {
                var ContactToChange = DBContext.Contacts.First(p => p.Id == contact.Id);
                ContactToChange.Partner = contact.Partner;
                ContactToChange.Deal = contact.Deal;
                ContactToChange.GoalDescription = contact.GoalDescription;
                ContactToChange.ResultDescription = contact.ResultDescription;
                ContactToChange.Date = contact.Date;
                ContactToChange.TypeOfContact = contact.TypeOfContact;
                ContactToChange.IsCompleted = contact.IsCompleted;
                DBContext.SaveChanges();
                return;
            }
            throw new ArgumentException("попытка измения данных несуществующей сделки");
        }
    }
}
