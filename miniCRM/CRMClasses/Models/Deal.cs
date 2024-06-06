using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMClasses.Models
{
    public class Deal
    {
        public int PartnerID { set; get; }
        public int Id { set; get; }
        public byte StageOfSale { set; get; }
        public string Description { set; get; }

        public override string ToString()
        {
            return $"{Id} {Description}";
        }
    }

    internal static class StagesOfSale
    {
        public static string[] stages = [
            "Вывлен интерес", 
            "Запланирована встреча",
            "Подготовка коммерческого предложения",
            "Рассматривается коммерческоое предложение",
            "Отработка возражений",
            "Подписание договора",
            "Ожидание оплаты",
            "Оказание услуг / поставка товара",
            "Завершена"
        ];
    }
}
