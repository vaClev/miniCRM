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

namespace miniCRM.Components.EditControls
{
    public partial class DealHeaderControl : UserControl, IModelComponent, IEditWindowControl
    {
        Deal deal;
        public DealHeaderControl()
        {
            deal = new Deal();
            InitializeComponent();
            comboBox1.Items.AddRange(new PartnerBehavior().GetPartners().ToArray());
            comboBox2.Items.AddRange(StagesOfSale.stages);
        }
        public Deal GetDeal()
        {
            return deal;
        }
        public void SetDeal(Deal deal)
        {
            this.deal = (Deal)deal.Clone();
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
            }
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
            throw new NotImplementedException();
        }
    }
}
