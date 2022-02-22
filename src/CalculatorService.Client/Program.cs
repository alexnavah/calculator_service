using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CalculatorService.Client
{
    class Program
    {
        private static readonly string EndpointOption = "-e";
        private static readonly string ParametersOption = "-p";
        private static readonly string TrackingOption = "-x";
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
                if (args[i].Equals(EndpointOption))
                {
                    var operation = args[i + 1].ToLower();
                    consoleobject.Operation = operation;
                    consoleobject.Endpoint = FindEndpoint(operation);
                }

                if (args[i].Equals(ParametersOption))
                {
                    consoleobject.Parameters = args[i + 1];
                }

                if (args[i].Equals(TrackingOption))
                {
                    consoleobject.TrackingId = args[i + 1];
                }
            }

            var content = ParseParameters(consoleobject.Parameters, consoleobject.Operation);
            Console.WriteLine($"Serialized content: {content}");

            HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var uri = new Uri($"{consoleobject.BaseAddress}{consoleobject.Endpoint}");
            Console.WriteLine($"Calling endpoint: {uri.AbsoluteUri}");

            ConfigureHttpClient(consoleobject.TrackingId);

            var response = await Client.PostAsync(uri, httpContent);
            Console.WriteLine($"Result: {await response.Content.ReadAsStringAsync()}");
        }

        private static void ConfigureHttpClient(string trackingId)
        {
            Client.DefaultRequestHeaders.Add("Accept", "application/json");

            if (!string.IsNullOrWhiteSpace(trackingId))
            {
                Client.DefaultRequestHeaders.Add("X-Evi-Tracking-Id", trackingId);
            }
        }

        private static string ParseParameters(string parameters, string operation)
        {
            try
            {
                switch (operation)
                {
                    case "add":
                        var addendsString = parameters.Split("+");
                        var addendsInt = new List<int>();
                        for(var i = 0; i < addendsString.Length; i++)
                        {
                            addendsInt.Add(int.Parse(addendsString[i]));
                        }
                        return JsonSerializer.Serialize(new { addends = addendsInt.ToArray() });
                    case "sub":
                        var subParams = parameters.Split("-");
                        return JsonSerializer.Serialize(new { minuend = int.Parse(subParams[0]), subtrahend = int.Parse(subParams[1]) });
                    case "mult":
                        var factorsString = parameters.Split("*");
                        var factorsInt = new List<int>();
                        for (var i = 0; i < factorsString.Length; i++)
                        {
                            factorsInt.Add(int.Parse(factorsString[i]));
                        }
                        return JsonSerializer.Serialize(new { factors = factorsInt.ToArray() });
                    case "div":
                        var divParams = parameters.Split("/");
                        return JsonSerializer.Serialize(new { dividend = int.Parse(divParams[0]), divisor = int.Parse(divParams[1]) });
                    case "sqrt":
                        return JsonSerializer.Serialize(new { number = int.Parse(parameters) });
                    case "journal":
                        return JsonSerializer.Serialize(parameters);
                    default:
                        throw new ArgumentException($"Endpoint not found ({EndpointOption}). Check documentation for {operation}.");
                }
            }
            catch (Exception)
            {
                throw new ArgumentException($"Invalid parameter format ({ParametersOption}). Check documentation for {operation}.");
            }
        }

        private static string FindEndpoint(string operation) => operation switch
        {
            "add" => "calculator/add",
            "sub" => "calculator/sub",
            "mult" => "calculator/mult",
            "div" => "calculator/div",
            "sqrt" => "sqrt",
            "journal" => "journal/query",
            _ => throw new ArgumentException($"Endpoint not found ({EndpointOption}). Check documentation for {operation}."),
        };

        private class ConsoleObject
        {
            public string Operation { get; set; }
            public string BaseAddress => "http://localhost:4631/";
            public string Endpoint { get; set; }
            public string Parameters { get; set; }
            public string TrackingId { get; set; }
        }
    }
}
