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
    public partial class DealBodyControl : UserControl
    {
        Deal deal;
        public DealBodyControl(Deal deal)
        {
            InitializeComponent();
            this.deal = deal;   
        }
    }
}
