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
using WinFormsApp1;
using miniCRM.Components.EditControls;
using miniCRM.Patterns;

namespace miniCRM.Components
{
    public partial class PartnersListControl : UserControl
    {
        public PartnersListControl(Size parentSize)
        {
            InitializeComponent();
            UpdatePartnersListbox();
            CalcAndSetSize(parentSize);
        }
        private void CalcAndSetSize(Size parentSize)
        {
            Size = parentSize;
            listBox1.Size = new Size(Width = this.Width - 10, Height = this.Height - 50);
        }

        private void UpdatePartnersListbox()
        {
            var behavePartners = new PartnerBehavior();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(behavePartners.GetPartners().ToArray());
        }

        //нажатие кнопки добавить контрагента
        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Edit(new PartnerHeaderControl(), ActAdd);
            form.Show();
        }
        void ActAdd(UserControl userControl)
        {
            DataAdder.ActAdd(userControl);
            UpdatePartnersListbox();
        }

        //нажатие кнопки удалить контрагента
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            DialogResult dialogResult = MessageBox.Show($"{listBox1.SelectedItem} будет удален. \nВы уверены?", "Удаление контрагента", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                IBehaviorPattern behavior = new BehaviorComponentPartner();
                behavior.Remove(listBox1.SelectedItem ?? "");
                UpdatePartnersListbox();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
    }
}
