using CRMClasses.Behavior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMClasses.Models
{
    internal static class Repository
    {
        public static List<Contact> Contacts = new List<Contact>();
        public static List<Deal> Deals = new List<Deal>();
        public static List<Partner> Partners = new List<Partner>();

        static Repository()
        {
            Random rnd = new Random();
            for (int i = 0; i < 15; i++)
            {
                Deal testDeal = new Deal();
                testDeal.Partner = new Partner();
                testDeal.Partner.ShortName = "TestPartner";
                testDeal.Partner.INN = "52156"+rnd.Next(1000).ToString();
                testDeal.StageOfSale = (byte)rnd.Next(0, 8);
                //Deals.Add(testDeal);
                Partners.Add(testDeal.Partner);
            }
        }
    }
}
