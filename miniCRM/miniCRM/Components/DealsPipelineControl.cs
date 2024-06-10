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
    public partial class DealsPipelineControl : UserControl
    {
        public DealsPipelineControl(Size parentCompSize)
        {
            createTestDeals();
            InitializeComponent();
            tableLayoutPanel1.ColumnCount = StagesOfSale.stages.Length;
            Size = parentCompSize;
            UpdateDeals();
        }

        private void createTestDeals()
        {
            DealBehavior dealBehavior = new DealBehavior();
            Random rnd = new Random();

            for (int i = 0; i < 15; i++)
            {
                Deal testDeal = new Deal();
                testDeal.Partner = new Partner();
                testDeal.Partner.ShortName = "TestPartner";
                testDeal.StageOfSale = (byte)rnd.Next(0, 8);
                dealBehavior.AddDeal(testDeal);
            }
        }

        private void InitializeDealColumns(DealColumnsContainer dealColumnsContainer)
        {
            for (int i = 0; i < StagesOfSale.stages.Length; i++)
            {
                DealsColumn dealsColumn = new DealsColumn();
                dealColumnsContainer.Add(dealsColumn);
            }
        }

        private void UpdateDeals()
        {
            DealColumnsContainer dealColumnsContainer = new DealColumnsContainer();
            InitializeDealColumns(dealColumnsContainer);

            DealBehavior behavior = new DealBehavior();
            var deals = behavior.GetDeals();

            foreach (var deal in deals)
            {
                dealColumnsContainer.GetByIndex(deal.StageOfSale)?.AddDeal(deal);
            }
            for (int i = 0; i < StagesOfSale.stages.Length; i++)
            {
                tableLayoutPanel1.Controls.Add(dealColumnsContainer.GetByIndex(i), i, 1);
            }
        }
    }
}
