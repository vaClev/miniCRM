﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRMClasses.Behavior;
using CRMClasses.Models;
using miniCRM.Components.DealCards;
using miniCRM.Components.EditControls;
using miniCRM.Patterns;
using WinFormsApp1;

namespace miniCRM.Components
{
    public partial class DealsPipelineControl : UserControl
    {
        DealColumnsContainer dealColumnsContainer;
        public DealsPipelineControl(Size parentCompSize)
        {
            dealColumnsContainer = new DealColumnsContainer(StagesOfSale.Stages.Length);
            InitializeComponent();
            InitializeTable();
            Size = parentCompSize;
            UpdateDeals();
        }
        private void InitializeTable()
        {
            tableLayoutPanel1.ColumnCount = StagesOfSale.Stages.Length;
            int i= 0;
            foreach (string  stage in StagesOfSale.Stages) 
            {
                System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                label.Text = stage;
                label.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 104);
                label.Size = new Size(150, 200);
                tableLayoutPanel1.Controls.Add(label, i, 0);
                i++;
            }
        }
        private void UpdateDeals()
        {
            dealColumnsContainer.Clear();
            DealBehavior behavior = new DealBehavior();
            var deals = behavior.GetDeals();

            //сортировка сделок по колонкам
            foreach (var deal in deals)
            {
                dealColumnsContainer.GetByIndex(deal.StageOfSale)?.AddDeal(deal, UpdateDeals);
            }
            // добавление колонок со сделками в отрисованную таблицу
            int i = 0;
            foreach (var column in dealColumnsContainer)
            {
                tableLayoutPanel1.Controls.Add(column, i, 1);
                i++;
            }
        }
        //Кнопка создать новую сделку
        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Edit(new DealControl(), actionEdit: ActUpdate, actionCreate: ActAdd);
            form.Show();
        }
        void ActAdd(UserControl userControl)
        {
            DataAdder.ActAdd(userControl);
            UpdateDeals();
        }
        void ActUpdate(UserControl userControl)
        {
            DataAdder.ActUpdate(userControl);
            UpdateDeals();
        }
    }
}
