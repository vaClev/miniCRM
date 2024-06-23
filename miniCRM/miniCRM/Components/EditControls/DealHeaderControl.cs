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
using CRMClasses.Behavior;
using miniCRM.Patterns;

namespace miniCRM.Components.EditControls
{
    public partial class DealHeaderControl : UserControl, IModelComponent, IEditWindowControl
    {
        Deal deal;
        public DealHeaderControl(Deal deal)
        {
            this.deal = deal;
            InitializeComponent();
            comboBox1.Items.AddRange(new PartnerBehavior().GetPartners().ToArray());
            comboBox2.Items.AddRange(StagesOfSale.Stages);
        }
        public DealHeaderControl() : this(new Deal()) { }
        public Deal GetDeal()
        {
            return deal;
        }
        public void SetDeal(Deal deal)
        {
            this.deal = deal;
            textBox1.Text = deal.Id.ToString();
            textBox2.Text = deal.Description;
            textBox3.Text = deal.totalCost.ToString();
        }
        //измененение поля описание
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox texbox)
            {
                this.deal.Description = texbox.Text;
            }
        }
        //измененение поля сумма
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox texbox)
            {
                if (texbox.Text.Equals("")) { return; }

                int userVal;
                if (int.TryParse(texbox.Text, out userVal))
                {
                    this.deal.totalCost = userVal;
                }
                else
                {
                    MessageBox.Show("Введите только целое число в поле сумма!");
                    texbox.Clear();
                }

            }
        }

        //Выбор этапа сделки
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.deal.StageOfSale = (byte)comboBox2.SelectedIndex;
        }

        //Выбор контрагента
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                this.deal.Partner = (Partner)comboBox1.SelectedItem;
                //MessageBox.Show(this.deal.Partner.Id.ToString());
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string searchingText=(string)comboBox1.Text?? ""; 
            var newItems = new PartnerBehavior().GetPartners().Where(partner => partner.ToString().IndexOf(searchingText) >= 0).ToArray();
            if(newItems.Length != 0)
                comboBox1.Items.AddRange(newItems);
            if(comboBox1.Text?.Length > 0)
                comboBox1.Select(comboBox1.Text.Length , 0);
        }

        object IModelComponent.Get()
        {
            return GetDeal();
        }
        void IModelComponent.Set(object obj)
        {
            if (obj is Deal deal)
            {
                SetDeal(deal);
                return;
            }
            throw new NotImplementedException();
        }

        void IEditWindowControl.Edit()
        {
            throw new NotImplementedException();
        }

        string IEditWindowControl.GetWindowName()
        {
            return "Окно Сделки";
        }
        public void SelectPartner(Guid partnerID)
        {
            ComboBoxItemsSetter.SelectPartner(partnerID, comboBox1);
        }
    }
}
