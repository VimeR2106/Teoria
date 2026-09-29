namespace Lab1
{
    /// <summary>
    /// Вариант ввода данных (см. методичку, рис. 1).
    /// </summary>
    public enum InputCase
    {
        /// <summary>Случай 1: ансамбль A и P(b_j | a_i)</summary>
        AAndBGivenA = 1,

        /// <summary>Случай 2: ансамбль B и P(a_i | b_j)</summary>
        BAndAGivenB = 2,

        /// <summary>Случай 3: матрица совместных вероятностей P(a_i b_j)</summary>
        JointAB = 3
    }
}
