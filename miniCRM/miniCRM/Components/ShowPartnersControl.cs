using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRMClasses;
using CRMClasses.Behavior;
using CRMClasses.Models;

namespace miniCRM.Components
{
    public partial class ShowPartnersControl : UserControl
    {
        public ShowPartnersControl(Size parentSize)
        {
            InitializeComponent();
            createTestDataPartners();//заглушка
            UpdatePartnersList();
            CalcAndSetSize(parentSize);
        }
        private void CalcAndSetSize(Size parentSize)
        {
            Size = parentSize;
            listBox1.Size = new Size(Width = this.Width - 10, Height = this.Height - 50);
        }




        private void createTestDataPartners()
        {
            var behavePartners = new PartnerBehavior();
            if (behavePartners.GetPartners().ToArray().Length == 0)
            {
                Partner partner = new Partner();
                partner.INN = "5200565465";
                partner.ShortName = "TestContragent";
                behavePartners.AddPartner(partner);

                Partner partner2 = new Partner();
                partner2.INN = "5200569999";
                partner2.ShortName = "TestContragent2";
                behavePartners.AddPartner(partner2);
            }
        }

        private void UpdatePartnersList()
        {
            var behavePartners = new PartnerBehavior();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(behavePartners.GetPartners().ToArray());
        }

        
    }
}
