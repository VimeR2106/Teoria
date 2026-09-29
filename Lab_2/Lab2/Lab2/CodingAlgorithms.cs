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
            return l > 0 ? (l - h) / l : 0;
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

            SF(a, left, cut, code + "1");        // левая группа
            SF(a, cut + 1, right, code + "0");   // правая группа
        }

        // ========== 4. Хаффман (как в тетради) ==========
        // 1) Пишем символы и их веса (частоты ~ вероятностям)
        // 2) Берём два самых маленьких веса, склеиваем
        // 3) Меньшему из пары — бит 1, большему — бит 0
        // 4) Повторяем, пока не останется одно дерево
        // 5) От корня к символу собираем код
        class Node
        {
            public char? Sym;   // символ (только у листа)
            public int Freq;    // вес = частота (как p, только целым числом)
            public Node Left;   // меньший ребёнок → бит 1
            public Node Right;  // больший ребёнок → бит 0
        }

        public static List<CodeRow> Huffman(string text)
        {
            var a = MakeAlphabet(text);
            if (a.Count == 0) return a;
            if (a.Count == 1) { a[0].Code = "0"; return a; }

            // Листья: каждая буква — свой узел с весом
            string t = (text ?? "").ToLower().Replace("\r", "").Replace("\n", "");
            var freq = new Dictionary<char, int>();
            foreach (char c in t)
            {
                if (!freq.ContainsKey(c)) freq[c] = 0;
                freq[c]++;
            }

            var nodes = new List<Node>();
            foreach (var kv in freq)
                nodes.Add(new Node { Sym = kv.Key, Freq = kv.Value });

            // Склеиваем, пока не одно дерево
            while (nodes.Count > 1)
            {
                // два самых маленьких веса (как на бумаге)
                nodes = nodes.OrderBy(n => n.Freq).ToList();
                Node x = nodes[0];
                Node y = nodes[1];
                nodes.RemoveAt(0);
                nodes.RemoveAt(0);

                // меньшему — 1, большему — 0 (как в тетради)
                Node smaller, larger;
                if (x.Freq <= y.Freq)
                {
                    smaller = x;
                    larger = y;
                }
                else
                {
                    smaller = y;
                    larger = x;
                }

                nodes.Add(new Node
                {
                    Freq = smaller.Freq + larger.Freq,
                    Left = smaller,   // при спуске допишем "1"
                    Right = larger    // при спуске допишем "0"
                });
            }

            // От корня идём к листьям и записываем код
            var codes = new Dictionary<char, string>();
            WalkFromRoot(nodes[0], "", codes);

            foreach (var r in a)
                r.Code = codes[r.Symbol];
            return a;
        }

        // Спуск от корня: влево (меньший) + "1", вправо (больший) + "0"
        static void WalkFromRoot(Node n, string code, Dictionary<char, string> codes)
        {
            if (n.Sym != null)
            {
                codes[n.Sym.Value] = code == "" ? "0" : code;
                return;
            }
            WalkFromRoot(n.Left, code + "1", codes);   // меньший вес
            WalkFromRoot(n.Right, code + "0", codes);  // больший вес
        }
    }
}
