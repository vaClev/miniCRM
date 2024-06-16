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
        public IEnumerable<Partner> GetPartners()
        {
            return Repository.Partners;
        }
        public Partner? GetPartner(string partnerINN)
        {
            return Repository.Partners.FirstOrDefault(p => p.INN.Equals(partnerINN));
        }
        public void AddPartner(Partner partner)
        {
            if(!Repository.Partners.Any(p=>p.INN.Equals(partner.INN)))
            {
                Repository.Partners.Add(partner);
                return;
            }
            throw new ArgumentException("ИНН уже существует в базе");
        }
        public void RemovePartner(Partner partner)
        {
            Repository.Partners.Remove(partner);
        }
        public void UpdatePartner(Partner partner)
        {
            if (Repository.Partners.Any(p => p.Id.Equals(partner.Id)))
            { 
                var partnerToChange = Repository.Partners.First(p => p.Id.Equals(partner.Id));
                partnerToChange.ShortName = partner.ShortName;
                partnerToChange.FullName = partner.FullName;

                //надо проверить что ИНН не задублируется
                var partnersSameINN = Repository.Partners.Where(p => p.INN.Equals(partner.INN)).ToArray();
                if (partnersSameINN.Length==0)
                {
                    partnerToChange.INN = partner.INN;
                }
                else if (partnersSameINN[0].Id.Equals(partner.Id))
                {
                    //это и есть наш контрагент переприсваивать не нужно
                    return;
                }
                else
                {
                    throw new ArgumentException("Такой ИНН уже есть в базе");
                } 
                return;
            }
            throw new ArgumentException("попытка измения данных несуществующего контрагента");
        }
    }
}
