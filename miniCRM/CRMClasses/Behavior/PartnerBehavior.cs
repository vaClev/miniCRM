using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMClasses.Models;

namespace CRMClasses.Behavior
{
    public class PartnerBehavior
    {
        DBContextClass DBContext;
        public PartnerBehavior()
        {
            DBContext = new DBContextClass();
        }
        public IEnumerable<Partner> GetPartners()
        {
            return DBContext.Partners;
        }
        public Partner? GetPartner(Guid partnerID)
        {
            return DBContext.Partners.FirstOrDefault(p => p.Id==partnerID);
        }
        public void AddPartner(Partner partner)
        {
            if(!DBContext.Partners.Any(p=>p.INN.Equals(partner.INN)))
            {
                DBContext.Partners.Add(partner);
                DBContext.SaveChanges();
                return;
            }
            throw new ArgumentException("ИНН уже существует в базе");
        }
        public void RemovePartner(Partner partner)
        {
            DBContext.Partners.Remove(partner);
            DBContext.SaveChanges();
        }
        public void UpdatePartner(Partner partner)
        {
            if (DBContext.Partners.Any(p => p.Id ==partner.Id))
            { 
                var partnerToChange = DBContext.Partners.First(p => p.Id ==partner.Id);
                partnerToChange.ShortName = partner.ShortName;
                partnerToChange.FullName = partner.FullName;

                //надо проверить что ИНН не задублируется
                var partnersSameINN = DBContext.Partners.Where(p => p.INN.Equals(partner.INN)).ToArray();
                if (partnersSameINN.Length==0)
                {
                    partnerToChange.INN = partner.INN;
                }
                else if (partnersSameINN[0].Id.Equals(partner.Id))
                {
                    //это и есть наш контрагент переприсваивать не нужно
                }
                else
                {
                    throw new ArgumentException("Такой ИНН уже есть в базе");
                }
                DBContext.SaveChanges();
                return;
            }
            throw new ArgumentException("попытка измения данных несуществующего контрагента");
        }
    }
}
