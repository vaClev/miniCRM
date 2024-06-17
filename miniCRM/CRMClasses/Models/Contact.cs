using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMClasses.Models
{
    
    public class Contact: ICloneable
    {
        public Guid Id { get; set; }
        public Partner Partner { get; set;}
        public Deal? Deal { get; set;}
        public byte TypeOfContact {  get; set; }
        public string? GoalDescription {  get; set; }
        public string? ResultDescription {  get; set; }
        public DateTime Date { get; set; }

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
            return clone;
        }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()} {TypesOfContact.types[TypeOfContact]}";
        }
    }

    public static class TypesOfContact
    {
        public static string[] types = [
            "Телефонный звонок",
            "Личная встреча",
            "Видеовстреча",
            "Переписка",
            "Оффициальное письмо"
        ];
    }
}
