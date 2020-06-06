using System;

namespace OddCalculator
{
    class Program
    {
        private static readonly ConsolePrinter _printer = new ConsolePrinter();

        static void Main()
        {
            _printer.Welcome();
            _printer.PrintHelp();
            Console.ReadKey();

            while (true)
            {
                _printer.PrintInput();

                ConsoleInput consoleInput = new ConsoleInput(Console.ReadLine());
                consoleInput.Validate();

                if (!consoleInput.IsValid)
                {
                    _printer.InvalidInput();
                    continue;
                }
                consoleInput.Proceed(consoleInput.Input, _printer);
            }
        }
    }
}
