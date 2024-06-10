using miniCRM.Components;

namespace miniCRM
{
    public partial class CRMWindow : Form
    {
        public CRMWindow()
        {
            InitializeComponent();
            RenderDealsTab();
        }

        private void CRMWindow_Resize(object sender, EventArgs e)
        {
            tabControl1.Size = new Size(this.Width - 30, this.Height - 90);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if(sender is TabControl tab)
            {
                //MessageBox.Show($"{tabControl1.SelectedIndex}");

                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        RenderDealsTab();
                        break;
                    case 1:
                        RenderPartnersTab();
                        break;
                    case 2:
                        RenderDaylyReportTab();
                        break;

                    default:
                         throw new ArgumentException("не определена вкладка");
                }
            }
        }

        

        private void RenderDealsTab()
        {
            tabPage1.Controls.Clear();
            tabPage1.Controls.Add(new DealsPipelineControl(tabControl1.Size));
        }

        private void RenderPartnersTab()
        {
            tabPage2.Controls.Clear();
            tabPage2.Controls.Add(new PartnersListControl(tabControl1.Size));
        }
        private void RenderDaylyReportTab()
        {
            tabPage3.Controls.Clear();
            tabPage3.Controls.Add(new ShowDaylyReportControl());
        }
    }
}
