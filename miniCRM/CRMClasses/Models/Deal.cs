using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMClasses.Models
{
    public class Deal: ICloneable
    {
        public int Id { set; get; }
        public Partner Partner { set; get; }
        public byte StageOfSale { set; get; }
        public string Description { set; get; }
        public int totalCost {  set; get; } 
        public Deal() 
        {
            Description = "test";
            totalCost = 100000;
        }

        public override string ToString()
        {
            return $"{Id} {Description}";
        }
      
        public object Clone()
        {
            Deal clone = new Deal();
            clone.Partner = this.Partner;
            clone.StageOfSale = this.StageOfSale;
            clone.Description = this.Description;
            clone.totalCost = this.totalCost;
            clone.Id = this.Id;
            return clone;
        }
        
    }

    public static class StagesOfSale
    {
        public static string[] stages = [
            "Вывлен интерес", 
            "Запланирована встреча",
            "Подготовка коммерческого предложения",
            "Рассматривается коммерческоое предложение",
            "Отработка возражений",
            "Подписание договора",
            "Ожидание оплаты",
            "Оказание услуг / поставка товара"
        ];
    }
}
