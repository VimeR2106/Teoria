namespace Lab1
{
    partial class FormCaseSelect
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.radioCase1 = new System.Windows.Forms.RadioButton();
            this.radioCase2 = new System.Windows.Forms.RadioButton();
            this.radioCase3 = new System.Windows.Forms.RadioButton();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(95, 18);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(103, 13);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Выберите случай";
            // 
            // radioCase1
            // 
            this.radioCase1.AutoSize = true;
            this.radioCase1.Location = new System.Drawing.Point(28, 52);
            this.radioCase1.Name = "radioCase1";
            this.radioCase1.Size = new System.Drawing.Size(198, 17);
            this.radioCase1.TabIndex = 1;
            this.radioCase1.TabStop = true;
            this.radioCase1.Text = "Ввести для рассчета: A, p(bj/ai)";
            this.radioCase1.UseVisualStyleBackColor = true;
            // 
            // radioCase2
            // 
            this.radioCase2.AutoSize = true;
            this.radioCase2.Location = new System.Drawing.Point(28, 75);
            this.radioCase2.Name = "radioCase2";
            this.radioCase2.Size = new System.Drawing.Size(198, 17);
            this.radioCase2.TabIndex = 2;
            this.radioCase2.TabStop = true;
            this.radioCase2.Text = "Ввести для рассчета: B, p(ai/bj)";
            this.radioCase2.UseVisualStyleBackColor = true;
            // 
            // radioCase3
            // 
            this.radioCase3.AutoSize = true;
            this.radioCase3.Checked = true;
            this.radioCase3.Location = new System.Drawing.Point(28, 98);
            this.radioCase3.Name = "radioCase3";
            this.radioCase3.Size = new System.Drawing.Size(180, 17);
            this.radioCase3.TabIndex = 3;
            this.radioCase3.TabStop = true;
            this.radioCase3.Text = "Ввести для рассчета: p(ai bj)";
            this.radioCase3.UseVisualStyleBackColor = true;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(28, 135);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect.TabIndex = 4;
            this.buttonSelect.Text = "Выбрать";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // FormCaseSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 181);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.radioCase3);
            this.Controls.Add(this.radioCase2);
            this.Controls.Add(this.radioCase1);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormCaseSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Теория информации";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.RadioButton radioCase1;
        private System.Windows.Forms.RadioButton radioCase2;
        private System.Windows.Forms.RadioButton radioCase3;
        private System.Windows.Forms.Button buttonSelect;
    }
}
