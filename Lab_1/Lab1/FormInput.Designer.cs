namespace Lab1
{
    partial class FormInput
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
            this.labelRows = new System.Windows.Forms.Label();
            this.textBoxRows = new System.Windows.Forms.TextBox();
            this.labelCols = new System.Windows.Forms.Label();
            this.textBoxCols = new System.Windows.Forms.TextBox();
            this.buttonSetSize = new System.Windows.Forms.Button();
            this.labelEnsemble = new System.Windows.Forms.Label();
            this.gridEnsemble = new System.Windows.Forms.DataGridView();
            this.labelMatrix = new System.Windows.Forms.Label();
            this.gridMatrix = new System.Windows.Forms.DataGridView();
            this.buttonCalculate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridEnsemble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRows
            // 
            this.labelRows.AutoSize = true;
            this.labelRows.Location = new System.Drawing.Point(12, 15);
            this.labelRows.Name = "labelRows";
            this.labelRows.Size = new System.Drawing.Size(108, 13);
            this.labelRows.TabIndex = 0;
            this.labelRows.Text = "Количество строк:";
            // 
            // textBoxRows
            // 
            this.textBoxRows.Location = new System.Drawing.Point(130, 12);
            this.textBoxRows.Name = "textBoxRows";
            this.textBoxRows.Size = new System.Drawing.Size(40, 20);
            this.textBoxRows.TabIndex = 1;
            // 
            // labelCols
            // 
            this.labelCols.AutoSize = true;
            this.labelCols.Location = new System.Drawing.Point(12, 41);
            this.labelCols.Name = "labelCols";
            this.labelCols.Size = new System.Drawing.Size(127, 13);
            this.labelCols.TabIndex = 2;
            this.labelCols.Text = "Количество столбцов:";
            // 
            // textBoxCols
            // 
            this.textBoxCols.Location = new System.Drawing.Point(145, 38);
            this.textBoxCols.Name = "textBoxCols";
            this.textBoxCols.Size = new System.Drawing.Size(40, 20);
            this.textBoxCols.TabIndex = 3;
            // 
            // buttonSetSize
            // 
            this.buttonSetSize.Location = new System.Drawing.Point(12, 68);
            this.buttonSetSize.Name = "buttonSetSize";
            this.buttonSetSize.Size = new System.Drawing.Size(173, 23);
            this.buttonSetSize.TabIndex = 4;
            this.buttonSetSize.Text = "Задать размеры матрицы";
            this.buttonSetSize.UseVisualStyleBackColor = true;
            this.buttonSetSize.Click += new System.EventHandler(this.buttonSetSize_Click);
            // 
            // labelEnsemble
            // 
            this.labelEnsemble.AutoSize = true;
            this.labelEnsemble.Location = new System.Drawing.Point(12, 105);
            this.labelEnsemble.Name = "labelEnsemble";
            this.labelEnsemble.Size = new System.Drawing.Size(76, 13);
            this.labelEnsemble.TabIndex = 5;
            this.labelEnsemble.Text = "Ансамбль A :";
            // 
            // gridEnsemble
            // 
            this.gridEnsemble.AllowUserToAddRows = true;
            this.gridEnsemble.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEnsemble.Location = new System.Drawing.Point(12, 121);
            this.gridEnsemble.Name = "gridEnsemble";
            this.gridEnsemble.RowHeadersWidth = 51;
            this.gridEnsemble.Size = new System.Drawing.Size(560, 70);
            this.gridEnsemble.TabIndex = 6;
            // 
            // labelMatrix
            // 
            this.labelMatrix.AutoSize = true;
            this.labelMatrix.Location = new System.Drawing.Point(12, 205);
            this.labelMatrix.Name = "labelMatrix";
            this.labelMatrix.Size = new System.Drawing.Size(200, 13);
            this.labelMatrix.TabIndex = 7;
            this.labelMatrix.Text = "Совместные вероятности P(ai bj):";
            // 
            // gridMatrix
            // 
            this.gridMatrix.AllowUserToAddRows = true;
            this.gridMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMatrix.Location = new System.Drawing.Point(12, 221);
            this.gridMatrix.Name = "gridMatrix";
            this.gridMatrix.RowHeadersWidth = 51;
            this.gridMatrix.Size = new System.Drawing.Size(560, 160);
            this.gridMatrix.TabIndex = 8;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(12, 395);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(100, 23);
            this.buttonCalculate.TabIndex = 9;
            this.buttonCalculate.Text = "Рассчитать";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // FormInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 431);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.gridMatrix);
            this.Controls.Add(this.labelMatrix);
            this.Controls.Add(this.gridEnsemble);
            this.Controls.Add(this.labelEnsemble);
            this.Controls.Add(this.buttonSetSize);
            this.Controls.Add(this.textBoxCols);
            this.Controls.Add(this.labelCols);
            this.Controls.Add(this.textBoxRows);
            this.Controls.Add(this.labelRows);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "FormInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ввод данных";
            ((System.ComponentModel.ISupportInitialize)(this.gridEnsemble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMatrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelRows;
        private System.Windows.Forms.TextBox textBoxRows;
        private System.Windows.Forms.Label labelCols;
        private System.Windows.Forms.TextBox textBoxCols;
        private System.Windows.Forms.Button buttonSetSize;
        private System.Windows.Forms.Label labelEnsemble;
        private System.Windows.Forms.DataGridView gridEnsemble;
        private System.Windows.Forms.Label labelMatrix;
        private System.Windows.Forms.DataGridView gridMatrix;
        private System.Windows.Forms.Button buttonCalculate;
    }
}
