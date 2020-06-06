using Antlr4.Runtime.Tree;
using System;
using System.Globalization;

namespace OddCalculator
{
    class ConsolePrinter
    {
        public static readonly NumberFormatInfo FORMAT = new NumberFormatInfo { NumberDecimalSeparator = ".", NumberGroupSeparator = string.Empty };

        private readonly string _helpList = "\nMożliwe operacje na liczbach a i b:\n"
                + "Dodawanie:            a+b\n"
                + "Odejmowanie:          a-b\n"
                + "Mnożenie:             a*b\n"
                + "Dzielenie:            a/b lub a:b\n"
                + "Potęga:               a^b\n"
                + "Liczba do potęgi 2:   a**\n"
                + "Operacja modulo:      a%b\n"
                + "Sufit z liczby:       a'\n"
                + "Podłoga z liczby:     a_\n"
                + "Pierwiastek:          sqrt a\n"
                + "Zaokrąglenie:         a round"
                + "Wartość min i max:    min(a , b) lub max(a , b)\n"
                + "Silnia:               a!\n"
                + "Logarytm:             log a ( b )\n"
                + "logarytm naturalny:   logn a\n"
                + "Stała e do potęgi a:  exp a\n"
                + "Wartość bezwzględna:  abs a\n";

        public void PrintHelp()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(_helpList);
            Console.ResetColor();
            Console.WriteLine("Naciśnij klawisz aby kontynuować...");
        }

        public void Welcome()
        {
            Console.Title = "Kalkulator liczb całkowitych";
            Console.WriteLine("Kalkulator liczb całkowitych");
            Console.WriteLine("Program wykonali:");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Michał Bryła");
            Console.WriteLine("Piotr Kostrzewski");
            Console.WriteLine("Damian Tomasik");
            Console.ResetColor();
            Console.WriteLine("Naciśnij klawisz by kontynuować...");
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("Kalkulator liczb całkowitych operujący na liczbach dziesiętnych (np: 11, 23),");
            Console.WriteLine("liczbach ósemkowych (np: 087, 083) oraz liczbach szesnastkowych (np: 0xA3, 0x7B)");
            Console.WriteLine("Możliwe są operacje złożone z nawiasów");
            Console.WriteLine("Naciśnij klawisz by kontynuować...");
            Console.ReadKey();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!!  Kalkulator przyjmuje jedynie wprowadzone liczby nieparzyste  !!!");
            Console.WriteLine("");
            Console.ResetColor();
        }

        public void PrintInput()
        {
            Console.Write("Wprowadź ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("'help'");
            Console.ResetColor();
            Console.Write(" aby uzyskać listę działań lub");
            Console.WriteLine("");
            Console.WriteLine("Podaj wyrazenie: ");
        }

        public void PrintResult(IParseTree parseTree, GrammarParser grammarParser, Visitor visitor)
        {
            Console.WriteLine("");
            Console.WriteLine("Drzewo parsowania:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(parseTree.ToStringTree(grammarParser));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Wynik = {visitor.Visit(parseTree).ToString("R", FORMAT)}" + "\n");
            Console.ResetColor();
        }

        public void InvalidInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Podałeś niewłaściwy ciąg wejściowy");
            Console.ResetColor();
        }
    }
}