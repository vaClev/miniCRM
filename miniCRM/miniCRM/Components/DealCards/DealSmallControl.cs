using CRMClasses.Models;
using miniCRM.Components.EditControls;
using miniCRM.Patterns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace miniCRM.Components.DealCards
{
    public partial class DealSmallControl : UserControl
    {
        Deal Deal;
        Action UpdateDeals;
        public DealSmallControl(Deal deal, Action UpdateDeals)
        {
            this.Deal = deal;
            this.UpdateDeals = UpdateDeals;
            InitializeComponent();
            renderMiniCard(deal);
        }
        private void renderMiniCard(Deal deal)
        {
            label1.Text = deal.totalCost.ToString();
            label2.Text = deal.Partner?.ShortName ?? "";
            label3.Text = deal.Description?.ToString();
        }

        //Кнопка открытия сделки на редактирование
        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Edit(new DealControl(this.Deal, isEdit: true), actionEdit: ActUpdate);
            form.Show();
        }
        void ActUpdate(UserControl userControl)
        {
            DataAdder.ActUpdate(userControl);
            UpdateDeals();
        }
    }
}
