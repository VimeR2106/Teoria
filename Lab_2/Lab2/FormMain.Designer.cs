namespace Lab2
{
    partial class FormMain
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
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonEncode = new System.Windows.Forms.Button();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.labelInput = new System.Windows.Forms.Label();
            this.labelShannon = new System.Windows.Forms.Label();
            this.listShannon = new System.Windows.Forms.ListView();
            this.colShannonSymbol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShannonProb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShannonCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelShannonH = new System.Windows.Forms.Label();
            this.textShannonH = new System.Windows.Forms.TextBox();
            this.labelShannonAvg = new System.Windows.Forms.Label();
            this.textShannonAvg = new System.Windows.Forms.TextBox();
            this.labelShannonRed = new System.Windows.Forms.Label();
            this.textShannonRed = new System.Windows.Forms.TextBox();
            this.labelHuffman = new System.Windows.Forms.Label();
            this.listHuffman = new System.Windows.Forms.ListView();
            this.colHuffmanSymbol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHuffmanProb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHuffmanCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelHuffmanH = new System.Windows.Forms.Label();
            this.textHuffmanH = new System.Windows.Forms.TextBox();
            this.labelHuffmanAvg = new System.Windows.Forms.Label();
            this.textHuffmanAvg = new System.Windows.Forms.TextBox();
            this.labelHuffmanRed = new System.Windows.Forms.Label();
            this.textHuffmanRed = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(16, 112);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(213, 28);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Загрузить сообщение";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonEncode
            // 
            this.buttonEncode.Location = new System.Drawing.Point(237, 112);
            this.buttonEncode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonEncode.Name = "buttonEncode";
            this.buttonEncode.Size = new System.Drawing.Size(133, 28);
            this.buttonEncode.TabIndex = 3;
            this.buttonEncode.Text = "Кодировать";
            this.buttonEncode.UseVisualStyleBackColor = true;
            this.buttonEncode.Click += new System.EventHandler(this.buttonEncode_Click);
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(16, 31);
            this.textBoxInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInput.Size = new System.Drawing.Size(1012, 73);
            this.textBoxInput.TabIndex = 1;
            this.textBoxInput.TextChanged += new System.EventHandler(this.textBoxInput_TextChanged);
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(16, 11);
            this.labelInput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(148, 16);
            this.labelInput.TabIndex = 0;
            this.labelInput.Text = "Исходное сообщение:";
            // 
            // labelShannon
            // 
            this.labelShannon.AutoSize = true;
            this.labelShannon.Location = new System.Drawing.Point(16, 154);
            this.labelShannon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelShannon.Name = "labelShannon";
            this.labelShannon.Size = new System.Drawing.Size(196, 16);
            this.labelShannon.TabIndex = 4;
            this.labelShannon.Text = "Кодирование Шеннона-Фано";
            // 
            // listShannon
            // 
            this.listShannon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colShannonSymbol,
            this.colShannonProb,
            this.colShannonCode});
            this.listShannon.FullRowSelect = true;
            this.listShannon.GridLines = true;
            this.listShannon.HideSelection = false;
            this.listShannon.Location = new System.Drawing.Point(16, 174);
            this.listShannon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listShannon.Name = "listShannon";
            this.listShannon.Size = new System.Drawing.Size(492, 270);
            this.listShannon.TabIndex = 5;
            this.listShannon.UseCompatibleStateImageBehavior = false;
            this.listShannon.View = System.Windows.Forms.View.Details;
            // 
            // colShannonSymbol
            // 
            this.colShannonSymbol.Text = "Символ";
            this.colShannonSymbol.Width = 90;
            // 
            // colShannonProb
            // 
            this.colShannonProb.Text = "Вероятность";
            this.colShannonProb.Width = 110;
            // 
            // colShannonCode
            // 
            this.colShannonCode.Text = "Код";
            this.colShannonCode.Width = 140;
            // 
            // labelShannonH
            // 
            this.labelShannonH.AutoSize = true;
            this.labelShannonH.Location = new System.Drawing.Point(16, 462);
            this.labelShannonH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelShannonH.Name = "labelShannonH";
            this.labelShannonH.Size = new System.Drawing.Size(100, 16);
            this.labelShannonH.TabIndex = 6;
            this.labelShannonH.Text = "Энтропия H(Z)";
            // 
            // textShannonH
            // 
            this.textShannonH.Location = new System.Drawing.Point(267, 458);
            this.textShannonH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textShannonH.Name = "textShannonH";
            this.textShannonH.ReadOnly = true;
            this.textShannonH.Size = new System.Drawing.Size(241, 22);
            this.textShannonH.TabIndex = 7;
            // 
            // labelShannonAvg
            // 
            this.labelShannonAvg.Location = new System.Drawing.Point(16, 494);
            this.labelShannonAvg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelShannonAvg.Name = "labelShannonAvg";
            this.labelShannonAvg.Size = new System.Drawing.Size(247, 39);
            this.labelShannonAvg.TabIndex = 8;
            this.labelShannonAvg.Text = "Среднее число символов на один знак сообщения";
            // 
            // textShannonAvg
            // 
            this.textShannonAvg.Location = new System.Drawing.Point(267, 498);
            this.textShannonAvg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textShannonAvg.Name = "textShannonAvg";
            this.textShannonAvg.ReadOnly = true;
            this.textShannonAvg.Size = new System.Drawing.Size(241, 22);
            this.textShannonAvg.TabIndex = 9;
            // 
            // labelShannonRed
            // 
            this.labelShannonRed.AutoSize = true;
            this.labelShannonRed.Location = new System.Drawing.Point(16, 548);
            this.labelShannonRed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelShannonRed.Name = "labelShannonRed";
            this.labelShannonRed.Size = new System.Drawing.Size(136, 16);
            this.labelShannonRed.TabIndex = 10;
            this.labelShannonRed.Text = "Избыточность кода";
            // 
            // textShannonRed
            // 
            this.textShannonRed.Location = new System.Drawing.Point(267, 544);
            this.textShannonRed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textShannonRed.Name = "textShannonRed";
            this.textShannonRed.ReadOnly = true;
            this.textShannonRed.Size = new System.Drawing.Size(241, 22);
            this.textShannonRed.TabIndex = 11;
            // 
            // labelHuffman
            // 
            this.labelHuffman.AutoSize = true;
            this.labelHuffman.Location = new System.Drawing.Point(536, 154);
            this.labelHuffman.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHuffman.Name = "labelHuffman";
            this.labelHuffman.Size = new System.Drawing.Size(169, 16);
            this.labelHuffman.TabIndex = 12;
            this.labelHuffman.Text = "Кодирование Хаффмана";
            // 
            // listHuffman
            // 
            this.listHuffman.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHuffmanSymbol,
            this.colHuffmanProb,
            this.colHuffmanCode});
            this.listHuffman.FullRowSelect = true;
            this.listHuffman.GridLines = true;
            this.listHuffman.HideSelection = false;
            this.listHuffman.Location = new System.Drawing.Point(536, 174);
            this.listHuffman.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listHuffman.Name = "listHuffman";
            this.listHuffman.Size = new System.Drawing.Size(492, 270);
            this.listHuffman.TabIndex = 13;
            this.listHuffman.UseCompatibleStateImageBehavior = false;
            this.listHuffman.View = System.Windows.Forms.View.Details;
            // 
            // colHuffmanSymbol
            // 
            this.colHuffmanSymbol.Text = "Символ";
            this.colHuffmanSymbol.Width = 90;
            // 
            // colHuffmanProb
            // 
            this.colHuffmanProb.Text = "Вероятность";
            this.colHuffmanProb.Width = 110;
            // 
            // colHuffmanCode
            // 
            this.colHuffmanCode.Text = "Код";
            this.colHuffmanCode.Width = 140;
            // 
            // labelHuffmanH
            // 
            this.labelHuffmanH.AutoSize = true;
            this.labelHuffmanH.Location = new System.Drawing.Point(536, 462);
            this.labelHuffmanH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHuffmanH.Name = "labelHuffmanH";
            this.labelHuffmanH.Size = new System.Drawing.Size(100, 16);
            this.labelHuffmanH.TabIndex = 14;
            this.labelHuffmanH.Text = "Энтропия H(Z)";
            // 
            // textHuffmanH
            // 
            this.textHuffmanH.Location = new System.Drawing.Point(787, 458);
            this.textHuffmanH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textHuffmanH.Name = "textHuffmanH";
            this.textHuffmanH.ReadOnly = true;
            this.textHuffmanH.Size = new System.Drawing.Size(241, 22);
            this.textHuffmanH.TabIndex = 15;
            // 
            // labelHuffmanAvg
            // 
            this.labelHuffmanAvg.Location = new System.Drawing.Point(536, 494);
            this.labelHuffmanAvg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHuffmanAvg.Name = "labelHuffmanAvg";
            this.labelHuffmanAvg.Size = new System.Drawing.Size(247, 39);
            this.labelHuffmanAvg.TabIndex = 16;
            this.labelHuffmanAvg.Text = "Среднее число символов на один знак сообщения";
            // 
            // textHuffmanAvg
            // 
            this.textHuffmanAvg.Location = new System.Drawing.Point(787, 498);
            this.textHuffmanAvg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textHuffmanAvg.Name = "textHuffmanAvg";
            this.textHuffmanAvg.ReadOnly = true;
            this.textHuffmanAvg.Size = new System.Drawing.Size(241, 22);
            this.textHuffmanAvg.TabIndex = 17;
            // 
            // labelHuffmanRed
            // 
            this.labelHuffmanRed.AutoSize = true;
            this.labelHuffmanRed.Location = new System.Drawing.Point(536, 548);
            this.labelHuffmanRed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHuffmanRed.Name = "labelHuffmanRed";
            this.labelHuffmanRed.Size = new System.Drawing.Size(136, 16);
            this.labelHuffmanRed.TabIndex = 18;
            this.labelHuffmanRed.Text = "Избыточность кода";
            // 
            // textHuffmanRed
            // 
            this.textHuffmanRed.Location = new System.Drawing.Point(787, 544);
            this.textHuffmanRed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textHuffmanRed.Name = "textHuffmanRed";
            this.textHuffmanRed.ReadOnly = true;
            this.textHuffmanRed.Size = new System.Drawing.Size(241, 22);
            this.textHuffmanRed.TabIndex = 19;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 592);
            this.Controls.Add(this.textHuffmanRed);
            this.Controls.Add(this.labelHuffmanRed);
            this.Controls.Add(this.textHuffmanAvg);
            this.Controls.Add(this.labelHuffmanAvg);
            this.Controls.Add(this.textHuffmanH);
            this.Controls.Add(this.labelHuffmanH);
            this.Controls.Add(this.listHuffman);
            this.Controls.Add(this.labelHuffman);
            this.Controls.Add(this.textShannonRed);
            this.Controls.Add(this.labelShannonRed);
            this.Controls.Add(this.textShannonAvg);
            this.Controls.Add(this.labelShannonAvg);
            this.Controls.Add(this.textShannonH);
            this.Controls.Add(this.labelShannonH);
            this.Controls.Add(this.listShannon);
            this.Controls.Add(this.labelShannon);
            this.Controls.Add(this.buttonEncode);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.labelInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кодирование";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonEncode;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.Label labelShannon;
        private System.Windows.Forms.ListView listShannon;
        private System.Windows.Forms.ColumnHeader colShannonSymbol;
        private System.Windows.Forms.ColumnHeader colShannonProb;
        private System.Windows.Forms.ColumnHeader colShannonCode;
        private System.Windows.Forms.Label labelShannonH;
        private System.Windows.Forms.TextBox textShannonH;
        private System.Windows.Forms.Label labelShannonAvg;
        private System.Windows.Forms.TextBox textShannonAvg;
        private System.Windows.Forms.Label labelShannonRed;
        private System.Windows.Forms.TextBox textShannonRed;
        private System.Windows.Forms.Label labelHuffman;
        private System.Windows.Forms.ListView listHuffman;
        private System.Windows.Forms.ColumnHeader colHuffmanSymbol;
        private System.Windows.Forms.ColumnHeader colHuffmanProb;
        private System.Windows.Forms.ColumnHeader colHuffmanCode;
        private System.Windows.Forms.Label labelHuffmanH;
        private System.Windows.Forms.TextBox textHuffmanH;
        private System.Windows.Forms.Label labelHuffmanAvg;
        private System.Windows.Forms.TextBox textHuffmanAvg;
        private System.Windows.Forms.Label labelHuffmanRed;
        private System.Windows.Forms.TextBox textHuffmanRed;
    }
}
