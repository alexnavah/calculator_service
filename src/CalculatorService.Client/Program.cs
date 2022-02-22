using System;

namespace CalculatorService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Arguments missing.");
            }

            var consoleobject = new ConsoleObject();

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-e")
                {
                    consoleobject.Endpoint = FindEndpoint(args[i + 1].ToLower());
                }

                if (args[i] == "-p")
                {
                    consoleobject.Parameters = args[i + 1].ToLower();
                }
            }

            Console.WriteLine($"{consoleobject.Endpoint} {consoleobject.Parameters}");
        }

        private static string FindEndpoint(string operation)
        {
            return operation switch
            {
                "add" => "calculator/add",
                "sub" => "calculator/sub",
                "mult" => "calculator/mult",
                "div" => "calculator/div",
                "sqrt" => "sqrt",
                "journal" => "journal/query",
                _ => throw new ArgumentException("Endpoint not found. Valid ones are add, sub, mult, div, sqrt and journal."),
            };
        }

        private class ConsoleObject
        {
            public string Endpoint { get; set; }
            public string Parameters { get; set; }
        }
    }
}
