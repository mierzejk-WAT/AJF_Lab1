using System;
using Antlr4.Runtime.Misc;
using static OddCalculator.GrammarParser;

namespace OddCalculator
{
    public sealed class Visitor : GrammarBaseVisitor<double>
    {
        private readonly Calculator _calculator = new Calculator();
        private readonly ConsolePrinter _printer = new ConsolePrinter();
        public override double VisitNumber([NotNull] NumberContext ctx) => NumberFormatConverter.ConvertNumber(ctx);

        public override double VisitOperation([NotNull] OperationContext ctx)
        {
            if (null == ctx.op)
            {
                return Visit(ctx.GetChild(0));
            }

            switch (ctx.op.Type)
            {
                case Help:
                    _printer.PrintHelp();
                    return double.NaN;
                case Factorial:
                    return _calculator.Factorial(Visit(ctx.GetChild(0)));
                case Multiply:
                    return Visit(ctx.GetChild(0)) * Visit(ctx.GetChild(2));
                case MultiMultiply:
                    return Math.Pow(Visit(ctx.GetChild(0)), 2);
                case SQRT:
                    return Math.Sqrt(Visit(ctx.GetChild(1)));
                case Divide:
                    return Visit(ctx.GetChild(0)) / Visit(ctx.GetChild(2));
                case Add:
                    return Visit(ctx.GetChild(0)) + Visit(ctx.GetChild(2));
                case Subtract:
                    return ctx.GetChild(0).GetText().Equals("-") ? 
                        0 - (Visit(ctx.GetChild(1))) : 
                        Visit(ctx.GetChild(0)) - Visit(ctx.GetChild(2));
                case Pow:
                    return Math.Pow(Visit(ctx.GetChild(0)), Visit(ctx.GetChild(2)));
                case Modulo:
                    return Visit(ctx.GetChild(0)) % Visit(ctx.GetChild(2));
                case Logn:
                    return Math.Log(Visit(ctx.GetChild(1)));
                case Log:
                    return Math.Log(Visit(ctx.GetChild(3)), Visit(ctx.GetChild(1)));
                case Round:
                    return Math.Round(Visit(ctx.GetChild(0)));
                case Max:
                    return Math.Max(Visit(ctx.GetChild(2)), Visit(ctx.GetChild(4)));
                case Min:
                    return Math.Min(Visit(ctx.GetChild(2)), Visit(ctx.GetChild(4)));
                case Floor:
                    return Math.Floor(Visit(ctx.GetChild(0)));
                case Ceiling:
                    return Math.Ceiling(Visit(ctx.GetChild(0)));
                case Exp:
                    return Math.Exp(Visit(ctx.GetChild(1)));
                case Abs:
                    return Math.Abs(Visit(ctx.GetChild(1)));
                case LB:
                    return Visit(ctx.GetChild(1));
                case RB:
                    return Visit(ctx.GetChild(1));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }  
    }
}
