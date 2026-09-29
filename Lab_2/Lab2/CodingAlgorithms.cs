using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2
{
    // Одна строка таблицы: символ | вероятность | код
    public class CodeRow
    {
        public char Symbol;
        public double P;
        public string Code;

        public string Name
        {
            get { return Symbol == ' ' ? "[пробел]" : Symbol.ToString(); }
        }
    }

    public static class Coding
    {
        // ========== 1. Частоты и вероятности ==========
        public static List<CodeRow> MakeAlphabet(string text)
        {
            text = (text ?? "").ToLower().Replace("\r", "").Replace("\n", "");

            var count = new Dictionary<char, int>();
            foreach (char c in text)
            {
                if (!count.ContainsKey(c)) count[c] = 0;
                count[c]++;
            }

            int n = text.Length;
            var list = new List<CodeRow>();
            foreach (var kv in count.OrderByDescending(x => x.Value))
            {
                list.Add(new CodeRow
                {
                    Symbol = kv.Key,
                    P = (double)kv.Value / n,
                    Code = ""
                });
            }
            return list;
        }

        // ========== 2. Метрики ==========
        // Энтропия H = -Σ p·log2(p)
        public static double H(List<CodeRow> a)
        {
            double h = 0;
            foreach (var r in a)
                if (r.P > 0) h -= r.P * Math.Log(r.P, 2);
            return h;
        }

        // Средняя длина L = Σ p·длина_кода
        public static double L(List<CodeRow> a)
        {
            double s = 0;
            foreach (var r in a) s += r.P * r.Code.Length;
            return s;
        }

        // Избыточность = (L - H) / L
        public static double R(double h, double l)
        {
            return (l - h) / l;
        }

        // ========== 3. Шеннон–Фано ==========
        // Делим список на 2 группы с близкими суммами p, левым 1, правым 0
        public static List<CodeRow> ShannonFano(string text)
        {
            var a = MakeAlphabet(text);
            if (a.Count == 0) return a;
            SF(a, 0, a.Count - 1, "");
            return a;
        }

        static void SF(List<CodeRow> a, int left, int right, string code)
        {
            if (left > right) return;

            // Один символ — готово
            if (left == right)
            {
                a[left].Code = code == "" ? "0" : code;
                return;
            }

            // Сумма вероятностей участка
            double sum = 0;
            for (int i = left; i <= right; i++) sum += a[i].P;

            // Ищем место разреза: левая и правая суммы почти равны
            int cut = left;
            double best = double.MaxValue, leftSum = 0;
            for (int i = left; i < right; i++)
            {
                leftSum += a[i].P;
                double diff = Math.Abs(sum - 2 * leftSum);
                if (diff < best)
                {
                    best = diff;
                    cut = i;
                }
            }

            SF(a, left, cut, code + "0");        // левая группа
            SF(a, cut + 1, right, code + "1");   // правая группа
        }

        // ========== 4. Хаффман ==========
        // Символы с вероятностями p → склеиваем два самых маленьких p
        // Меньшему — бит 1, большему — бит 0 → от корня собираем код
        class Node
        {
            public char? Sym;   // символ
            public double P;    // вес = вероятность
            public Node Left;   // меньший p → бит 1
            public Node Right;  // больший p → бит 0
        }

        public static List<CodeRow> Huffman(string text)
        {
            var a = MakeAlphabet(text);
            if (a.Count == 0) return a;
            if (a.Count == 1) { a[0].Code = "0"; return a; }

            // Листья сразу из готовых вероятностей p
            var nodes = new List<Node>();
            foreach (var r in a)
                nodes.Add(new Node { Sym = r.Symbol, P = r.P });

            // Склеиваем два самых маленьких p, пока не одно дерево
            while (nodes.Count > 1)
            {
                nodes = nodes.OrderBy(n => n.P).ToList();
                Node x = nodes[0];
                Node y = nodes[1];
                nodes.RemoveAt(0);
                nodes.RemoveAt(0);

                // меньшему p — 1, большему — 0
                Node smaller = x.P <= y.P ? x : y;
                Node larger = x.P <= y.P ? y : x;

                nodes.Add(new Node
                {
                    P = smaller.P + larger.P,
                    Left = smaller,
                    Right = larger
                });
            }

            var codes = new Dictionary<char, string>();
            WalkFromRoot(nodes[0], "", codes);

            foreach (var r in a)
                r.Code = codes[r.Symbol];
            return a;
        }

        // От корня: к меньшему + "1", к большему + "0"
        static void WalkFromRoot(Node n, string code, Dictionary<char, string> codes)
        {
            if (n.Sym != null)
            {
                codes[n.Sym.Value] = code == "" ? "0" : code;
                return;
            }
            WalkFromRoot(n.Left, code + "1", codes);
            WalkFromRoot(n.Right, code + "0", codes);
        }
    }
}
