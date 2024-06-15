using CRMClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMClasses.Behavior
{
    public class DealBehavior
    {
        public IEnumerable<Deal> GetDeals()
        {
            return Repository.Deals;
        }
        public IEnumerable<Deal> GetDealsByPartner(Partner partner)
        {
            return Repository.Deals.Where(d=>d.Partner.Equals(partner));
        }
        public Deal? GetDeal(int Id)
        {
            return Repository.Deals.FirstOrDefault(p => p.Id == Id);
        }
        public void AddDeal(Deal deal)
        {
            Repository.Deals.Add(deal);
        }
        public void RemoveDeal(Deal deal)
        {
            Repository.Deals.Remove(deal);
        }
        public void UpdateDeal(Deal deal)
        {
            if (Repository.Deals.Any(p => p.Id == deal.Id))
            {
                var dealToChange = Repository.Deals.First(p => p.Id == deal.Id);
                dealToChange.Partner = deal.Partner;
                dealToChange.StageOfSale = deal.StageOfSale;
                dealToChange.Description = deal.Description;
                dealToChange.totalCost = deal.totalCost;
                return;
            }
            throw new ArgumentException("попытка измения данных несуществующей сделки");
        }
    }
}
