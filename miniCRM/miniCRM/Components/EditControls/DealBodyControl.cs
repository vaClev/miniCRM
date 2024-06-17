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
    public partial class DealBodyControl : UserControl
    {
        Deal deal;
        public DealBodyControl(Deal deal)
        {
            InitializeComponent();
            this.deal = deal;
            UpdateContactsListbox();
        }

        //создание нового контакта в карточке сделки
        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Edit(new ContactControl(deal), actionEdit: ActUpdate, actionCreate: ActAdd);
            form.Show();
        }
        private void UpdateContactsListbox()
        {
            var behavePartners = new ContactBehavior();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(behavePartners.GetContactsByDeal(this.deal).ToArray());
        }

        void ActAdd(UserControl userControl)
        {
            DataAdder.ActAdd(userControl);
            UpdateContactsListbox();
        }
        void ActUpdate(UserControl userControl)
        {
            DataAdder.ActUpdate(userControl);
            UpdateContactsListbox();
        }

      /*  //нажатие кнопки открыть контакт
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            Contact? selectedPartner = (Contact?)listBox1.SelectedItem;
            if (selectedPartner == null) return;

            var form = new Edit(new PartnerControl(selectedPartner, isEdit: true), actionEdit: ActUpdate);
            form.Show();
        }*/
    }
}
