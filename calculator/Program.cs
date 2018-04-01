using System;
using Sprache;

namespace calculator
{
    internal static class Program
    {
        public static void Main()
        {
            while (Prompt(out var line))
            {
                try
                {
                    var parsed = ExpressionParser.ParseExpression(line);
                    Console.WriteLine($"Parsed as {parsed}");
                    Console.WriteLine($"Value is {parsed.Compile()()}");
                }
                catch (ParseException ex)
                {
                    Console.WriteLine($"There was a problem with your input: {ex.Message}");
                }

                Console.WriteLine();
            }
        }

        private static bool Prompt(out string value)
        {
            Console.Write("Enter a numeric expression, or 'q' to quit: ");
            var line = Console.ReadLine();
            
            if (line?.ToLowerInvariant().Trim() == "q")
            {
                value = null;
                return false;
            }
            value = line;
            return true;
        }
    }
}