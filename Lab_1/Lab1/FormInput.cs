using System;
using System.Windows.Forms;

namespace Lab1
{
    public partial class FormInput : Form
    {
        private readonly InputCase _inputCase;
        private int _rows = 0;
        private int _cols = 0;

        public FormInput(InputCase inputCase)
        {
            _inputCase = inputCase;
            InitializeComponent();
            ApplyCaseLayout();
        }

        private void ApplyCaseLayout()
        {
            switch (_inputCase)
            {
                case InputCase.AAndBGivenA:
                    Text = "Случай 1: Ввести A и p(bj/ai)";
                    labelEnsemble.Text = "Ансамбль A :";
                    labelMatrix.Text = "Условные вероятности p(bj/ai):";
                    labelEnsemble.Visible = true;
                    gridEnsemble.Visible = true;
                    break;

                case InputCase.BAndAGivenB:
                    Text = "Случай 2: Ввести B и p(ai/bj)";
                    labelEnsemble.Text = "Ансамбль B :";
                    labelMatrix.Text = "Условные вероятности p(ai/bj):";
                    labelEnsemble.Visible = true;
                    gridEnsemble.Visible = true;
                    break;

                default:
                    Text = "Случай 3: Ввести матрицу совместных вероятностей P(ai bj)";
                    labelMatrix.Text = "Совместные вероятности P(ai bj):";
                    labelEnsemble.Visible = false;
                    gridEnsemble.Visible = false;
                    // Поднять матрицу выше, если ансамбль скрыт
                    labelMatrix.Top = labelEnsemble.Top;
                    gridMatrix.Top = labelMatrix.Bottom + 6;
                    buttonCalculate.Top = gridMatrix.Bottom + 12;
                    ClientSize = new System.Drawing.Size(ClientSize.Width, buttonCalculate.Bottom + 20);
                    break;
            }
        }

        private void buttonSetSize_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxRows.Text.Trim(), out int rows) || rows < 1 || rows > 4)
            {
                MessageBox.Show("Количество строк: целое число от 1 до 4.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxCols.Text.Trim(), out int cols) || cols < 1 || cols > 4)
            {
                MessageBox.Show("Количество столбцов: целое число от 1 до 4.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _rows = rows;
            _cols = cols;
            BuildGrids(rows, cols);
        }

        private void BuildGrids(int rows, int cols)
        {
            // Матрица
            gridMatrix.Columns.Clear();
            gridMatrix.Rows.Clear();
            for (int j = 0; j < cols; j++)
                gridMatrix.Columns.Add("c" + j, "");
            for (int i = 0; i < rows; i++)
                gridMatrix.Rows.Add();

            // Ансамбль (если нужен)
            if (_inputCase == InputCase.AAndBGivenA)
            {
                // A: одна строка, число элементов = числу строк матрицы
                gridEnsemble.Columns.Clear();
                gridEnsemble.Rows.Clear();
                for (int i = 0; i < rows; i++)
                    gridEnsemble.Columns.Add("a" + i, "");
                gridEnsemble.Rows.Add();
            }
            else if (_inputCase == InputCase.BAndAGivenB)
            {
                // B: одна строка, число элементов = числу столбцов матрицы
                gridEnsemble.Columns.Clear();
                gridEnsemble.Rows.Clear();
                for (int j = 0; j < cols; j++)
                    gridEnsemble.Columns.Add("b" + j, "");
                gridEnsemble.Rows.Add();
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            if (_rows <= 0 || _cols <= 0)
            {
                MessageBox.Show("Сначала задайте размеры матрицы.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string results;
                switch (_inputCase)
                {
                    case InputCase.AAndBGivenA:
                        results = CalculateCase1();
                        break;
                    case InputCase.BAndAGivenB:
                        results = CalculateCase2();
                        break;
                    default:
                        results = CalculateCase3();
                        break;
                }

                MessageBox.Show(results, "Результаты", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string CalculateCase1()
        {
            double[] a = ReadVector(gridEnsemble, _rows);
            double[,] pBGivenA = ReadMatrix(gridMatrix, _rows, _cols);
            double[,] pAb = Calculator.JointFromAAndBGivenA(a, pBGivenA);
            double[] b = Calculator.MarginalB(pAb);
            // На входе были A и P(B|A) — показываем P(AB) и P(A|B)
            return Calculator.BuildResultsText(a, b, pAb, showJoint: true, showBGivenA: false, showAGivenB: true);
        }

        private string CalculateCase2()
        {
            double[] b = ReadVector(gridEnsemble, _cols);
            double[,] pAGivenB = ReadMatrix(gridMatrix, _rows, _cols);
            double[,] pAb = Calculator.JointFromBAndAGivenB(b, pAGivenB);
            double[] a = Calculator.MarginalA(pAb);
            // На входе были B и P(A|B) — показываем P(AB) и P(B|A)
            return Calculator.BuildResultsText(a, b, pAb, showJoint: true, showBGivenA: true, showAGivenB: false);
        }

        private string CalculateCase3()
        {
            double[,] pAb = ReadMatrix(gridMatrix, _rows, _cols);
            double[] a = Calculator.MarginalA(pAb);
            double[] b = Calculator.MarginalB(pAb);
            // На входе была P(AB) — показываем обе условные матрицы
            return Calculator.BuildResultsText(a, b, pAb, showJoint: false, showBGivenA: true, showAGivenB: true);
        }

        private static double[,] ReadMatrix(DataGridView grid, int rows, int cols)
        {
            if (grid.RowCount < rows || grid.ColumnCount < cols)
                throw new InvalidOperationException("Матрица не задана или имеет неверный размер.");

            double[,] m = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    object cell = grid.Rows[i].Cells[j].Value;
                    string text = cell == null ? "" : cell.ToString();
                    if (!Calculator.TryParseDouble(text, out double value))
                        throw new InvalidOperationException(
                            string.Format("Некорректное значение в ячейке матрицы [{0}, {1}]: \"{2}\"", i + 1, j + 1, text));
                    m[i, j] = value;
                }
            }
            return m;
        }

        private static double[] ReadVector(DataGridView grid, int length)
        {
            if (grid.RowCount < 1 || grid.ColumnCount < length)
                throw new InvalidOperationException("Ансамбль не задан или имеет неверный размер.");

            double[] v = new double[length];
            for (int i = 0; i < length; i++)
            {
                object cell = grid.Rows[0].Cells[i].Value;
                string text = cell == null ? "" : cell.ToString();
                if (!Calculator.TryParseDouble(text, out double value))
                    throw new InvalidOperationException(
                        string.Format("Некорректное значение в ансамбле [{0}]: \"{1}\"", i + 1, text));
                v[i] = value;
            }
            return v;
        }
    }
}
