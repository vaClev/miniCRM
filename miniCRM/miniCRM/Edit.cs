using miniCRM.Components.EditControls;
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
        Action<UserControl>? actionCreate;
        UserControl userControl;
        bool isEdit;

        public Edit(UserControl userControl, Action<UserControl> actionEdit, Action<UserControl>? actionCreate = null)
        {
            InitializeComponent();
            var size = new Size(userControl.Width + 10,
                                userControl.Height + button1.Size.Height + button2.Size.Height + 70);
            Text = (userControl as IEditWindowControl)?.GetWindowName();
            Size = size;
            Controls.Add(userControl);
            this.action = actionEdit;
            this.actionCreate = actionCreate;
            this.userControl = userControl;

            // Если передан только один делагат --- то окно всегда работает на редактирование данных
            isEdit = (actionCreate == null) ? true : false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                action(userControl);
            }
            else
            {
                actionCreate(userControl);
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                action(userControl);
            }
            else
            {
                actionCreate(userControl);
                //как то убедиться что создание успешно прошло ----- пока просто с певого раза
                (userControl as IEditWindowControl)?.Edit();
                isEdit = true;
            }
        }
    }
}
