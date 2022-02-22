using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CalculatorService.Client
{
    class Program
    {
        private static readonly string GetMethod = "GET";
        private static readonly string PostMethod = "POST";
        private static readonly HttpClient Client = new HttpClient();

        static async Task Main(string[] args)
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
                    var operation = args[i + 1].ToLower();
                    consoleobject.Operation = operation;
                    consoleobject.Endpoint = FindEndpoint(operation);
                }

                if (args[i] == "-p")
                {
                    consoleobject.Parameters = args[i + 1].ToLower();
                }

                if (args[i] == "-x")
                {
                    consoleobject.TrackingId = args[i + 1];
                }
            }

            var content = ParseParameters(consoleobject.Parameters, consoleobject.Operation);
            HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var uri = new Uri($"{consoleobject.BaseAddress}{consoleobject.Endpoint.Item1}");
            Console.WriteLine(uri.AbsoluteUri);

            ConfigureHttpClient();

            if (!string.IsNullOrWhiteSpace(consoleobject.TrackingId))
            {
                Client.DefaultRequestHeaders.Add("X-Evi-Tracking-Id", consoleobject.TrackingId);
            }

            if (consoleobject.Endpoint.Item2.Equals(PostMethod))
            {
                var result = await Client.PostAsync(uri, httpContent);
                Console.WriteLine(result);
            }
            else
            {
                var result = await Client.GetAsync(uri);
            }

        }

        private static void ConfigureHttpClient()
        {
            Client.DefaultRequestHeaders.Remove("X-Evi-Tracking-Id");
            Client.DefaultRequestHeaders.Remove("Accept");
            Client.DefaultRequestHeaders.Remove("Content-Type");

            Client.DefaultRequestHeaders.Add("Accept", "application/json");
            Client.DefaultRequestHeaders.Add("Content-Type", "application/json");
        }

        private static string ParseParameters(string parameters, string operation)
        {
            return operation switch
            {
                "add" => JsonSerializer.Serialize(new { Number = parameters }),
                "sub" => JsonSerializer.Serialize(new { Number = parameters }),
                "mult" => JsonSerializer.Serialize(new { Number = parameters }),
                "div" => JsonSerializer.Serialize(new { Dividend = parameters }),
                "sqrt" => JsonSerializer.Serialize(new { Number = parameters }),
                "journal" => string.Empty,
                _ => throw new ArgumentException("Endpoint not found. Valid ones are add, sub, mult, div, sqrt and journal."),
            };
        }

        private static Tuple<string, string> FindEndpoint(string operation) => operation switch
        {
            "add" => new Tuple<string, string>("calculator/add", PostMethod),
            "sub" => new Tuple<string, string>("calculator/sub", PostMethod),
            "mult" => new Tuple<string, string>("calculator/mult", PostMethod),
            "div" => new Tuple<string, string>("calculator/div", PostMethod),
            "sqrt" => new Tuple<string, string>("sqrt", PostMethod),
            "journal" => new Tuple<string, string>("journal/query", GetMethod),
            _ => throw new ArgumentException("Endpoint not found. Valid ones are add, sub, mult, div, sqrt and journal."),
        };

        private class ConsoleObject
        {
            public string Operation { get; set; }
            public string BaseAddress => "http://localhost:4361/";
            public Tuple<string,string> Endpoint { get; set; }
            public string Parameters { get; set; }
            public string TrackingId { get; set; }
        }
    }
}
