using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRMClasses.Models;
using static System.Net.Mime.MediaTypeNames;

namespace miniCRM.Components.DealCards
{
    public partial class DealsColumn : UserControl
    {
        public DealsColumn()
        {
            InitializeComponent();
        }
        public void AddDeal(Deal deal)
        {
            DealSmallControl dealSmallControl = new DealSmallControl(deal);
            flowLayoutPanel1.Controls.Add(dealSmallControl);
        }
    }
}
