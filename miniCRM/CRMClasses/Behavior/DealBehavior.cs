using CRMClasses.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMClasses.Behavior
{
    public class DealBehavior
    {
        DBContextClass DBContext;
        public DealBehavior()
        {
            DBContext = new DBContextClass();
        }
        public IEnumerable<Deal> GetDeals()
        {
            return DBContext.Deals.Include(u => u.Partner);//Достает доп сущность Partner
        }
        public IEnumerable<Deal> GetDealsByPartner(Partner partner)
        {
            return DBContext.Deals.Include(u => u.Partner).Where(d => partner.Id == d.Partner.Id);
        }

        //Включая ссылку на Partner 
        public Deal? GetDeal(Guid Id)
        {
            return DBContext.Deals.Include(u=>u.Partner).FirstOrDefault(p => p.Id == Id);
        }
        public void AddDeal(Deal deal)
        {
            //проверка что сделки с таким Id нет в репозитории
            if (!DBContext.Deals.Any(g => g.Id == deal.Id))
            {
                //проверка что у сделки есть привязка к партнеру
                Partner? partner = new PartnerBehavior().GetPartner(deal.Partner.Id);
                if (partner != null)
                {
                    DBContext.Attach(deal.Partner);
                    DBContext.Deals.Add(deal);
                    DBContext.SaveChanges();
                    return;
                }
            }
                
            throw new ArgumentException("попытка добавления сделки с несуществующим в репозитории контрагенте");
        }
        public void RemoveDeal(Deal deal)
        {
            DBContext.Deals.Remove(deal);
            DBContext.SaveChanges();
        }
        public void UpdateDeal(Deal deal)
        {
            if (DBContext.Deals.Any(p => p.Id == deal.Id))
            {
                var dealToChange = DBContext.Deals.First(p => p.Id == deal.Id);
                dealToChange.Partner = deal.Partner;
                dealToChange.StageOfSale = deal.StageOfSale;
                dealToChange.Description = deal.Description;
                dealToChange.totalCost = deal.totalCost;
                DBContext.SaveChanges();
                return;
            }
            throw new ArgumentException("попытка измения данных несуществующей сделки");
        }
    }
}
