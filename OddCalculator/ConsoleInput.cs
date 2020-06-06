using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace OddCalculator
{
    class ConsoleInput
    {
        public string Input { get; set; }
        public bool IsValid { get; set; }
        public string ParseTree { get; set; }
        public ConsoleInput(string input)
        {
            Input = input;
        }

        public void Validate()
        {
            bool valid = true;
            for (int i = 0; i < Input.Length; i++)
            {
                if (i + 1 < Input.Length && Input[i + 1] == 'x')
                {
                    if (Input[i] == '0' || Input[i] == 'e' || Input[i] == 'a')
                    {
                        valid = true;
                    }
                    else
                    {
                        IsValid = false;
                        return;
                    }
                }
                if (Input[i] == '0' || Input[i] == '2'
                   || Input[i] == '4' || Input[i] == '6'
                   || Input[i] == '8' || Input[i] == 'A'
                   || Input[i] == 'C' || Input[i] == 'E')
                {
                    if (i + 1 == Input.Length)
                    {
                        IsValid = false;
                        return;
                    }
                    if (Input[i + 1] == '0' || Input[i + 1] == '1'
                        || Input[i + 1] == '2' || Input[i + 1] == '3'
                        || Input[i + 1] == '4' || Input[i + 1] == '5'
                        || Input[i + 1] == '6' || Input[i + 1] == '7'
                        || Input[i + 1] == '8' || Input[i + 1] == '9'
                        || Input[i + 1] == 'A' || Input[i + 1] == 'B'
                        || Input[i + 1] == 'C' || Input[i + 1] == 'D'
                        || Input[i + 1] == 'E' || Input[i + 1] == 'F'
                        || Input[i + 1] == 'x')
                    {
                        valid = true;
                    }
                    else
                    {
                        IsValid = false;
                        return;
                    }
                }
            }
            IsValid = valid;
        }

        public void Proceed(string input, ConsolePrinter printer)
        {
            AntlrInputStream antlrInputStream = new AntlrInputStream(input);
            GrammarLexer grammarLexer = new GrammarLexer(antlrInputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(grammarLexer);
            GrammarParser grammarParser = new GrammarParser(commonTokenStream) { BuildParseTree = true };
            Visitor visitor = new Visitor();
            IParseTree parseTree = grammarParser.operation();
            var error = grammarParser.NumberOfSyntaxErrors;

            if (0 < error)
            {
                printer.InvalidInput();
            }
            else
            {
                if (!visitor.Visit(parseTree).Equals(double.NaN))
                {
                    printer.PrintResult(parseTree, grammarParser, visitor);
                }
            }
        }
    
    }
}
