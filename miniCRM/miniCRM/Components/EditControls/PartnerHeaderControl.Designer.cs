namespace miniCRM.Components.EditControls
{
    partial class PartnerHeaderControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBox3 = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(89, 18);
            label1.TabIndex = 0;
            label1.Text = "Контрагент";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 29);
            label2.Name = "label2";
            label2.Size = new Size(134, 15);
            label2.TabIndex = 1;
            label2.Text = "Полное наименование";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(143, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(282, 23);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(143, 67);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(282, 23);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 67);
            label3.Name = "label3";
            label3.Size = new Size(135, 15);
            label3.TabIndex = 4;
            label3.Text = "Краткое наименование";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 106);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 5;
            label4.Text = "ИНН";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(43, 103);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(152, 23);
            textBox3.TabIndex = 6;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(201, 106);
            label5.Name = "label5";
            label5.Size = new Size(18, 15);
            label5.TabIndex = 7;
            label5.Text = "ID";
            // 
            // PartnerHeaderControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label5);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "PartnerHeaderControl";
            Size = new Size(436, 138);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private Label label4;
        private TextBox textBox3;
        private Label label5;
    }
}
