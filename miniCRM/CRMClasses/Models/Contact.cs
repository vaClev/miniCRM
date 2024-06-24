using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMClasses.Models
{

    public class Contact : ICloneable
    {
        public Guid Id { get; set; }
        public Partner Partner { get; set; }
        public Deal? Deal { get; set; }

        public byte TypeOfContact { get; set; }
        public string? GoalDescription { get; set; }
        public string? ResultDescription { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }

        public Contact()
        {
            //this.Id = Guid.NewGuid();
            Partner = new Partner();
            Deal = null;
            TypeOfContact = 0;
            GoalDescription = null;
            ResultDescription = null;
            Date = DateTime.Now;
            IsCompleted = false;
        }



        public object Clone()
        {
            Contact clone = new Contact();
            clone.Id = this.Id;
            clone.Partner = this.Partner;
            clone.Deal = this.Deal;
            clone.TypeOfContact = this.TypeOfContact;
            clone.GoalDescription = this.GoalDescription;
            clone.ResultDescription = this.ResultDescription;
            clone.Date = this.Date;
            clone.IsCompleted = this.IsCompleted;
            return clone;
        }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()} {TypesOfContact.Types[TypeOfContact]} {TypesOfContact.Statuses[IsCompleted? 0 : 1]}";
        }
    }

    public static class TypesOfContact
    {
        public  static string[] Types = [
            "Телефонный звонок",
            "Личная встреча",
            "Видеовстреча",
            "Переписка",
            "Оффициальное письмо"
        ];
        public static string[] Statuses = ["Завершен", "Запланирован"];
    }
}
