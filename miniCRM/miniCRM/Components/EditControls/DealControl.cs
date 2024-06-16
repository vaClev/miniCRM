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

namespace miniCRM.Components.EditControls
{
    
    public partial class DealControl : UserControl, IModelComponent, IEditWindowControl
    {
        Deal deal;
        DealHeaderControl HeaderControl;
        DealBodyControl? BodyControl;
        bool isEdit;
        public DealControl(Deal deal, bool isEdit)
        {
            this.isEdit = isEdit;
            InitializeComponent();

            this.deal = deal;
            HeaderControl = new DealHeaderControl(this.deal);
            if (isEdit) SetDeal(deal);
            InitializeHeader();
            InitializeBody();
        }
        public DealControl() : this(new Deal(), false) { }
        public DealControl(Partner partner) : this(new Deal(), false) 
        {
            HeaderControl.SelectPartner(partner.Id);
            this.deal.Partner=partner;
        }
        public void SetDeal(Deal deal)
        {
            this.deal = (Deal)deal.Clone();
            HeaderControl.SetDeal(this.deal);
            if (isEdit)
            {
                //также пробросить в список контактов по сделке
            }
        }
        void InitializeHeader()
        {
            HeaderControl.Location = new Point(0, 0);
            HeaderControl.Name = "HeaderControl";
            HeaderControl.Size = new Size(1000, 250);
            HeaderControl.TabIndex = 0;
            Controls.Add(HeaderControl);
            Size = new Size(HeaderControl.Width, HeaderControl.Height + 50);
        }
        void InitializeBody()
        {
            if (!isEdit) return;
            BodyControl = new DealBodyControl(this.deal);
            BodyControl.Location = new Point(0, 250);
            BodyControl.Name = "partnerBodyControl";
            BodyControl.Size = new Size(1000, 250);
            BodyControl.TabIndex = 0;
            Controls.Add(BodyControl);
            Size = new Size(Size.Width, Size.Height + BodyControl.Size.Height + 50);
        }

        public void Set(object obj)
        {
            if (obj is Deal deal)
            {
                SetDeal(deal);
                return;
            }
            throw new NotImplementedException();
        }

        public object Get()
        {
            return GetDeal();
        }
        public Deal GetDeal()
        {
            return deal;
        }

        void IEditWindowControl.Edit()
        {
            isEdit = true;
            InitializeBody();
        }

        string IEditWindowControl.GetWindowName()
        {
            return isEdit ? $"{deal.Id} {deal.Description}" : "Cоздание новой сделки";
        }
    }
}
