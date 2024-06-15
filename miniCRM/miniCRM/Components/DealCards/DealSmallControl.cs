using CRMClasses.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniCRM.Components.DealCards
{
    public partial class DealSmallControl : UserControl
    {
        public DealSmallControl(Deal deal)
        {
            InitializeComponent();
            renderMiniCard(deal);
        }
        private void renderMiniCard(Deal deal)
        {
           label1.Text = deal.totalCost.ToString();
           label2.Text = deal.Partner?.ShortName ?? "";
           label3.Text = deal.Description.ToString();
        }
    }
}
