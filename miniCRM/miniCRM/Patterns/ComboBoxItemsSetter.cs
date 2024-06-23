using CRMClasses.Behavior;
using CRMClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniCRM.Patterns
{
    internal static class ComboBoxItemsSetter
    {
        public static void SelectPartner(Guid partnerID, ComboBox comboBox)
        {
            comboBox.Items.Clear();
            Partner? SelectedPartner = new PartnerBehavior().GetPartner(partnerID);
            if (SelectedPartner != null)
            {
                comboBox.Items.Add(SelectedPartner);
                comboBox.SelectedIndex = 0;
                return;
            }
            throw new ArgumentNullException("Контрагента с таким ID нет в репозитории");
        }
        public static void SelectDeal(Guid dealID, ComboBox comboBox)
        {
            comboBox.Items.Clear();
            Deal? Selected = new DealBehavior().GetDeal(dealID);
            if (Selected != null)
            {
                comboBox.Items.Add(Selected);
                comboBox.SelectedIndex = 0;
                return;
            }
            throw new ArgumentNullException("Сделки с таким ID нет в репозитории");
        }
        public static void SelectDealsByPartner(Partner partner, ComboBox comboBox)
        {
            comboBox.Items.Clear();
            Deal[] Deals = new DealBehavior().GetDealsByPartner(partner).ToArray();
            if (Deals.Length != 0)
            {
                comboBox.Items.AddRange(Deals);
                return;
            }
        }

    }
}
