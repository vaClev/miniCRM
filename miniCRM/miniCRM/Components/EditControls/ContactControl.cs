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
using CRMClasses.Models;
using CRMClasses.Behavior;
using miniCRM.Patterns;

namespace miniCRM.Components.EditControls
{
    public partial class ContactControl : UserControl, IModelComponent, IEditWindowControl
    {
        Contact contact;
        bool isEdit;
        public ContactControl(Contact contact, bool isEdit = true)
        {
            this.contact = contact;
            this.isEdit = isEdit;
            InitializeComponent();
            if (isEdit) SetContact(contact);
            initializeComboBoxItems();
        }
        public ContactControl() : this(new Contact(), false) { }
        public ContactControl(Deal deal) : this() 
        {
            ComboBoxItemsSetter.SelectPartner(deal.Partner.Id, comboBox1);
            ComboBoxItemsSetter.SelectDeal(deal.Id, comboBox2);
        }


        void initializeComboBoxItems()
        {
            comboBox1.Items.AddRange(new PartnerBehavior().GetPartners().ToArray());
            comboBox2.Items.AddRange(new DealBehavior().GetDeals().ToArray());
            comboBox3.Items.AddRange(TypesOfContact.types);
            comboBox3.SelectedIndex = 0;
        }
        void SetContact(Contact contact)
        {
            this.contact = (Contact)contact.Clone();
            //и в поля установить значения

        }
        Contact GetContact()
        {
            return this.contact;
        }
        object IModelComponent.Get()
        {
            return GetContact();
        }
        void IModelComponent.Set(object obj)
        {
            if (obj is Contact contact)
            {
                SetContact(contact);
                return;
            }
            throw new NotImplementedException();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                this.contact.Partner = (Partner)comboBox1.SelectedItem;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                this.contact.Deal = (Deal)comboBox2.SelectedItem;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.contact.TypeOfContact = (byte)comboBox3.SelectedIndex;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.contact.Date = dateTimePicker1.Value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.contact.GoalDescription = textBox1.Text;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.contact.ResultDescription = textBox2.Text;
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string searchingText = (string)comboBox1.Text ?? "";
            var newItems = new PartnerBehavior().GetPartners().Where(partner => partner.ToString().IndexOf(searchingText) >= 0).ToArray();
            if (newItems.Length != 0)
                comboBox1.Items.AddRange(newItems);
            if (comboBox1.Text?.Length > 0)
                comboBox1.Select(comboBox1.Text.Length, 0);
        }

        void IEditWindowControl.Edit()
        {
            isEdit = true;
        }
        string IEditWindowControl.GetWindowName()
        {
            return isEdit ? $"{TypesOfContact.types[this.contact.TypeOfContact]} {contact.Partner.ShortName}" : "Новый контакт";
        }

    }

}
