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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace miniCRM.Components.EditControls
{
    public partial class PartnerControl : UserControl, IModelComponent, IEditWindowControl
    {
        Partner partner;
        PartnerHeaderControl partnerHeaderControl;
        PartnerBodyControl? partnerBodyControl;
        bool isEdit;
        public PartnerControl(Partner partner, bool isEdit)
        {
            this.isEdit = isEdit;
            InitializeComponent();

            this.partner = partner;
            partnerHeaderControl = new PartnerHeaderControl(this.partner);
            if(isEdit) SetPartner(partner);
            InitializeHeader();
            InitializeBody();
        }
        public PartnerControl() : this(new Partner(), false) { }

        void InitializeHeader()
        {
            partnerHeaderControl.Location = new Point(0, 0);
            partnerHeaderControl.Name = "partnerHeaderControl";
            partnerHeaderControl.Size = new Size(574, 132);
            partnerHeaderControl.TabIndex = 0;
            Controls.Add(partnerHeaderControl);
            Size = new Size(partnerHeaderControl.Width, partnerHeaderControl.Height+50);
        }
        void InitializeBody()
        {
            if (!isEdit) return;
            partnerBodyControl = new PartnerBodyControl(this.partner);
            partnerBodyControl.Location = new Point(0, 150);
            partnerBodyControl.Name = "partnerBodyControl";
            partnerBodyControl.Size = new Size(574, 250);
            partnerBodyControl.TabIndex = 0;
            Controls.Add(partnerBodyControl);
            Size = new Size(Size.Width, Size.Height + partnerBodyControl.Size.Height+50);
        }
        public Partner GetPartner()
        {
            return partner;
        }
        public void SetPartner(Partner partner)
        {
            this.partner = (Partner)partner.Clone();
            partnerHeaderControl.Set(this.partner);
            if (isEdit) 
            {
                //также пробросить партнера и в списки сделок и контактов
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

        void IEditWindowControl.Edit()
        {
            isEdit = true;
            InitializeBody();
        }

        string IEditWindowControl.GetWindowName()
        {
            return isEdit ? partner.FullName : "Cоздание нового контрагента";
        }
    }
}
