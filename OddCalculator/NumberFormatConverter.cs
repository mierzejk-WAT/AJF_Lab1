using Antlr4.Runtime.Misc;
using System;
using static OddCalculator.GrammarParser;

namespace OddCalculator
{
    class NumberFormatConverter
    {
        public static double ConvertNumber([NotNull] NumberContext ctx)
        {
            string numer = ctx.GetText();
            if (numer[0] == '0')
            {
                if (numer[1] == 'x')
                {
                    numer = Convert.ToInt64(numer, 16).ToString();
                }
                else
                {
                    numer = Convert.ToInt64(numer, 8).ToString();
                }
            }
            return double.Parse(numer, ConsolePrinter.FORMAT);
        }
    }
}
