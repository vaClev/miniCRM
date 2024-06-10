using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRMClasses.Behavior;
using CRMClasses.Models;
using miniCRM.Components.DealCards;

namespace miniCRM.Components
{
    public partial class ShowDealsControl : UserControl
    {
        private DealColumnsContainer dealColumnsContainer; 
        public ShowDealsControl()
        {
            dealColumnsContainer = new DealColumnsContainer();
            InitializeComponent();
            UpdateDeals();
        }
        private void InitializeDealColumns() 
        {
            dealColumnsContainer = new DealColumnsContainer();
            tableLayoutPanel1.ColumnCount = StagesOfSale.stages.Length;
            for (int i = 0; i < StagesOfSale.stages.Length; i++)
            {
                DealsColumn dealsColumn = new DealsColumn();
                dealColumnsContainer.Add(dealsColumn);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void UpdateDeals()
        {
            InitializeDealColumns();
            DealBehavior behavior = new DealBehavior();
            var deals = behavior.GetDeals();

            foreach (var deal in deals)
            {
                dealColumnsContainer.GetByIndex(deal.StageOfSale)?.AddDeal(deal);
            }
            for (int i = 0; i < StagesOfSale.stages.Length; i++)
            {
                //
                tableLayoutPanel1.Controls.Add(dealColumn, i, 1);               
            }
        } 
    }
}
