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

namespace miniCRM.Components.EditControls
{
    public partial class PartnerHeaderControl : UserControl, IModelComponent
    {
        Partner partner;
        
        public PartnerHeaderControl(Partner? partner=null)
        {
            InitializeComponent(); 
            this.partner = partner ?? new Partner();
        }

        public Partner GetPartner()
        {
            return partner;
        }
        public void SetPartner(Partner partner)
        {
            this.partner = (Partner)partner.Clone();
            textBox1.Text = partner.FullName;
            textBox2.Text = partner.ShortName;
            textBox3.Text = partner.INN;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox texbox)
            {
                partner.FullName = texbox.Text;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox texbox)
            {
                partner.ShortName = texbox.Text;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox texbox)
            {
                partner.INN = texbox.Text;
            }
        }

        object IModelComponent.Get()
        {
            return GetPartner();
        }
        void IModelComponent.Set(object obj)
        {
            if (obj is Partner partner)
            {
                SetPartner(partner);
                return;
            }
            throw new NotImplementedException();
        }


        //Ввести новый интерфейс редактируемое окно и вынести Edit в него
        void IModelComponent.Edit()
        {
            throw new NotImplementedException();
        }
    }
}
