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
        
    }
}
