using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRMClasses.Behavior;
using CRMClasses.Models;
using miniCRM.Patterns;
using WinFormsApp1;

namespace miniCRM.Components.EditControls
{
    public partial class PartnerBodyControl : UserControl
    {
        Partner partner;
        public PartnerBodyControl(Partner partner)
        {
            InitializeComponent();
            this.partner = partner;
            updateDealsList();
            updateContactsList();
        }
        private void updateContactsList()
        {

        }

        void updateDealsList()
        {
            listBox1.Items.Clear();
            DealBehavior beh = new DealBehavior();
            listBox1.Items.AddRange(beh.GetDealsByPartner(partner).ToArray());
        }

        //Создание новой сделки из диалога контрагента
        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Edit(new DealControl(partner), actionEdit: ActUpdateDeal, actionCreate: ActAddDeal);
            form.Show();
        }

        void ActAddDeal(UserControl userControl)
        {
            DataAdder.ActAdd(userControl);
            updateDealsList();
        }
        void ActUpdateDeal(UserControl userControl)
        {
            DataAdder.ActUpdate(userControl);
            updateDealsList();
        }

        
    }
}
