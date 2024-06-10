using CRMClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMClasses.Behavior
{
    public class ContactBehavior
    {
        public IEnumerable<Contact> GetAllContacts()
        {
            return Repository.Contacts;
        }
        public IEnumerable<Contact> GetContactsByDeal(Deal deal)
        {
            return Repository.Contacts.Where<Contact>(c=>c.Deal==deal);
        }
        public Contact? GetContact(int Id)
        {
            return Repository.Contacts.FirstOrDefault(p => p.Id == Id);
        }
        public void AddContact(Contact contact)
        {
            Repository.Contacts.Add(contact);
        }
        public void RemoveContact(Contact contact)
        {
            Repository.Contacts.Remove(contact);
        }
        public void UpdateContact(Contact contact)
        {
            if (Repository.Contacts.Any(p => p.Id == contact.Id))
            {
                var ContactToChange = Repository.Contacts.First(p => p.Id == contact.Id);
                ContactToChange.Parntner = contact.Parntner;
                ContactToChange.Deal = contact.Deal;
                ContactToChange.GoalDescription = contact.GoalDescription;
                ContactToChange.ResultDescription = contact.ResultDescription;
                ContactToChange.Date = contact.Date;
               
                return;
            }
            throw new ArgumentException("попытка измения данных несуществующей сделки");
        }
    }
}
