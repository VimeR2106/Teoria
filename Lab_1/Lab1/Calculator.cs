using System;
using System.Globalization;
using System.Text;

namespace Lab1
{
    /// 1) ансамбли A, B из суммы строк/столбцов P(AB)
    /// 2) H(A), H(B), H(AB)
    /// 3) P(B|A) = P(AB)/P(A), P(A|B) = P(AB)/P(B)
    /// 4) H(B|A) = -Σ p(ai)·Σ p(bj|ai)·log2 p(bj|ai)
    /// 5) H(A|B) = -Σ p(bj)·Σ p(ai|bj)·log2 p(ai|bj)
    /// 6) I(A;B) = H(A) - H(A|B)
    public static class Calculator
    {
        private static readonly CultureInfo Ru = CultureInfo.GetCultureInfo("ru-RU");

        // H(X) = -Σ p·log2(p)
        public static double Entropy(double[] p)
        {
            double h = 0;
            for (int i = 0; i < p.Length; i++)
                if (p[i] > 0)
                    h -= p[i] * Math.Log(p[i], 2);
            return h;
        }

        // H(AB) = -ΣΣ p(ai,bj)·log2 p(ai,bj)
        public static double JointEntropy(double[,] pAb)
        {
            int rows = pAb.GetLength(0);
            int cols = pAb.GetLength(1);
            double h = 0;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (pAb[i, j] > 0)
                        h -= pAb[i, j] * Math.Log(pAb[i, j], 2);
            return h;
        }

        // A: сумма по строкам
        public static double[] MarginalA(double[,] pAb)
        {
            int rows = pAb.GetLength(0);
            int cols = pAb.GetLength(1);
            double[] a = new double[rows];
            for (int i = 0; i < rows; i++)
            {
                double s = 0;
                for (int j = 0; j < cols; j++)
                    s += pAb[i, j];
                a[i] = s;
            }
            return a;
        }

        // B: сумма по столбцам
        public static double[] MarginalB(double[,] pAb)
        {
            int rows = pAb.GetLength(0);
            int cols = pAb.GetLength(1);
            double[] b = new double[cols];
            for (int j = 0; j < cols; j++)
            {
                double s = 0;
                for (int i = 0; i < rows; i++)
                    s += pAb[i, j];
                b[j] = s;
            }
            return b;
        }

        // p(bj|ai) = p(ai,bj) / p(ai)
        public static double[,] ConditionalBGivenA(double[,] pAb, double[] a)
        {
            int rows = pAb.GetLength(0);
            int cols = pAb.GetLength(1);
            double[,] m = new double[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    m[i, j] = a[i] > 0 ? pAb[i, j] / a[i] : 0;
            return m;
        }

        // p(ai|bj) = p(ai,bj) / p(bj)
        public static double[,] ConditionalAGivenB(double[,] pAb, double[] b)
        {
            int rows = pAb.GetLength(0);
            int cols = pAb.GetLength(1);
            double[,] m = new double[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    m[i, j] = b[j] > 0 ? pAb[i, j] / b[j] : 0;
            return m;
        }

        // (1.6): H(B|A) = -Σ_i p(ai) · [ Σ_j p(bj|ai) log2 p(bj|ai) ]
        public static double ConditionalEntropyBGivenA(double[] a, double[,] pBGivenA)
        {
            int rows = pBGivenA.GetLength(0);
            int cols = pBGivenA.GetLength(1);
            double h = 0;
            for (int i = 0; i < rows; i++)
            {
                double inner = 0; // энтропия строки B при фиксированном ai
                for (int j = 0; j < cols; j++)
                    if (pBGivenA[i, j] > 0)
                        inner -= pBGivenA[i, j] * Math.Log(pBGivenA[i, j], 2);
                h += a[i] * inner;
            }
            return h;
        }

        // (1.7): H(A|B) = -Σ_j p(bj) · [ Σ_i p(ai|bj) log2 p(ai|bj) ]
        public static double ConditionalEntropyAGivenB(double[] b, double[,] pAGivenB)
        {
            int rows = pAGivenB.GetLength(0);
            int cols = pAGivenB.GetLength(1);
            double h = 0;
            for (int j = 0; j < cols; j++)
            {
                double inner = 0;
                for (int i = 0; i < rows; i++)
                    if (pAGivenB[i, j] > 0)
                        inner -= pAGivenB[i, j] * Math.Log(pAGivenB[i, j], 2);
                h += b[j] * inner;
            }
            return h;
        }

        // P(ai,bj) = p(ai) * p(bj|ai)
        public static double[,] JointFromAAndBGivenA(double[] a, double[,] pBGivenA)
        {
            int rows = a.Length;
            int cols = pBGivenA.GetLength(1);
            double[,] pAb = new double[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    pAb[i, j] = a[i] * pBGivenA[i, j];
            return pAb;
        }

        // P(ai,bj) = p(bj) * p(ai|bj)
        public static double[,] JointFromBAndAGivenB(double[] b, double[,] pAGivenB)
        {
            int rows = pAGivenB.GetLength(0);
            int cols = b.Length;
            double[,] pAb = new double[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    pAb[i, j] = b[j] * pAGivenB[i, j];
            return pAb;
        }

        public static string FormatVector(double[] v)
        {
            string[] parts = new string[v.Length];
            for (int i = 0; i < v.Length; i++)
                parts[i] = v[i].ToString(Ru);
            return string.Join(", ", parts);
        }

        public static string FormatMatrix(double[,] m)
        {
            int rows = m.GetLength(0);
            int cols = m.GetLength(1);
            var sb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (j > 0) sb.Append("  ");
                    sb.Append(m[i, j].ToString("0.0000", Ru));
                }
                if (i < rows - 1) sb.AppendLine();
            }
            return sb.ToString();
        }

        /// «Результаты»
        public static string BuildResultsText(
            double[] a,
            double[] b,
            double[,] pAb,
            bool showJoint,
            bool showBGivenA,
            bool showAGivenB)
        {
            double[,] pBGivenA = ConditionalBGivenA(pAb, a);
            double[,] pAGivenB = ConditionalAGivenB(pAb, b);

            double hA = Entropy(a);
            double hB = Entropy(b);
            double hAb = JointEntropy(pAb);

            // Условные энтропии
            double hBGivenA = ConditionalEntropyBGivenA(a, pBGivenA);
            double hAGivenB = ConditionalEntropyAGivenB(b, pAGivenB);

            // I(AB) = H(A) - H(A|B) 
            double iAb = hA - hAGivenB;

            var sb = new StringBuilder();
            sb.AppendLine("Ансамбль A: " + FormatVector(a));
            sb.AppendLine("Ансамбль B: " + FormatVector(b));
            sb.AppendLine("Энтропия H(A): " + hA.ToString(Ru));
            sb.AppendLine("Энтропия H(B): " + hB.ToString(Ru));
            sb.AppendLine("Условная энтропия H(B|A): " + hBGivenA.ToString(Ru));
            sb.AppendLine("Условная энтропия H(A|B): " + hAGivenB.ToString(Ru));
            sb.AppendLine("Совместная энтропия H(AB): " + hAb.ToString(Ru));
            sb.AppendLine("Взаимная информация I(A;B): " + iAb.ToString(Ru));

            if (showJoint)
            {
                sb.AppendLine("Матрица совместных вероятностей P(a_i, b_j):");
                sb.AppendLine(FormatMatrix(pAb));
            }
            if (showBGivenA)
            {
                sb.AppendLine("Матрица условных вероятностей P(b_j | a_i):");
                sb.AppendLine(FormatMatrix(pBGivenA));
            }
            if (showAGivenB)
            {
                sb.AppendLine("Матрица условных вероятностей P(a_i | b_j):");
                sb.AppendLine(FormatMatrix(pAGivenB));
            }

            return sb.ToString().TrimEnd();
        }

        public static bool TryParseDouble(string text, out double value)
        {
            text = (text ?? "").Trim().Replace(',', '.');
            return double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }
    }
}
