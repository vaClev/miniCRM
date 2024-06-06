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
            return Repository.Partners.FirstOrDefault(p => p.INN == partnerINN);
        }
        public void AddPartner(Partner partner)
        {
            if(!Repository.Partners.Any(p=>p.INN==partner.INN))
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
            if (Repository.Partners.Any(p => p.Id == partner.Id))
            {
                var partnerToChange = Repository.Partners.First(p=>p.Id == partner.Id);
                partnerToChange.ShortName = partner.ShortName;
                partnerToChange.FullName = partner.FullName;
                partnerToChange.ShortName = partner.ShortName;
                return;
            }
            throw new ArgumentException("попытка измения данных несуществующего контрагента");
        }
    }
}
