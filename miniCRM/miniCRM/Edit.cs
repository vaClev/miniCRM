using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Edit : Form
    {
        Action<UserControl> action;
        UserControl userControl;

        public Edit(UserControl userControl,Action<UserControl>  action)
        {
            InitializeComponent();
            var size = new Size(userControl.Width + 10,
                                userControl.Height+button1.Size.Height + 30);
            Size = size;

            Controls.Add(userControl);
            this.action = action;
            this.userControl = userControl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            action(userControl);
            Close();
        }
    }
}
