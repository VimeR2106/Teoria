using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Lab2
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        // Загрузка .txt → в поле → кодировать
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = "Выберите файл для кодирования";
                dlg.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                textBoxInput.Text = File.ReadAllText(dlg.FileName);
            }
        }

        // Кнопка «Кодировать»
        private void buttonEncode_Click(object sender, EventArgs e)
        {
            Run();
        }

        // Главный сценарий: алфавит → два метода → таблицы и метрики
        void Run()
        {
            string text = textBoxInput.Text ?? "";
            if (text.Trim().Length == 0)
            {
                MessageBox.Show("Введите текст или загрузите файл.");
                return;
            }

            Show(listShannon, textShannonH, textShannonAvg, textShannonRed, Coding.ShannonFano(text));
            Show(listHuffman, textHuffmanH, textHuffmanAvg, textHuffmanRed, Coding.Huffman(text));
        }

        void Show(ListView list, TextBox boxH, TextBox boxL, TextBox boxR, List<CodeRow> rows)
        {
            list.Items.Clear();
            foreach (var r in rows)
            {
                var item = new ListViewItem(r.Name);
                item.SubItems.Add(r.P.ToString("0.000"));
                item.SubItems.Add(r.Code);
                list.Items.Add(item);
            }

            double h = Coding.H(rows);
            double l = Coding.L(rows);
            boxH.Text = h.ToString("0.0000");
            boxL.Text = l.ToString("0.0000");
            boxR.Text = Coding.R(h, l).ToString("0.0000");
        }

        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
