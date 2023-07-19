using System.Net.Http.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

using System.Threading.Tasks;
using PhoneBookApp.Domain.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PhoneBookApp.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Replace "API_ENDPOINT_URL" with the actual URL of your Web API endpoint
            string apiEndpointUrl = "https://localhost:7096/api/PhoneBook";

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiEndpointUrl);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            // Output the JSON data to the console to inspect its format
            Console.WriteLine("JSON Data:");
            Console.WriteLine(json);


            try
            {
                var entries = JsonSerializer.Deserialize<IEnumerable<PhoneBookEntry>>(json);
                foreach (var entry in entries)
                {
                    Console.WriteLine($"Name: {entry.PersonName}, Phone Number: {entry.PhoneNumber}");
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON Deserialization Error: {ex.Message}");
            }

        }
    }

}
