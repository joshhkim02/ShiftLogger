using ShiftLoggerApp.Models;
using ShiftLoggerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShiftLoggerApp.Clients
{
    public class ShiftLoggerClient
    {
        string link = "https://localhost:7036/api/shiftlogger";

        // Inject the classes we want to use
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserInput _input;
        private readonly Validate _validate;
        public ShiftLoggerClient(IHttpClientFactory httpClientFactory, UserInput input, Validate validate)
        {
            _httpClientFactory = httpClientFactory;
            _input = input;
            _validate = validate;
        }

        public async Task ShowEntries()
        {
            Console.Clear();

            var client = _httpClientFactory.CreateClient();

            // Tell the client we are expecting a JSON back
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // Store the JSON as a list and save it to the result variable
            var result = await client.GetFromJsonAsync<List<ShiftDTO>>(link);

            // Access the data from the result list
            foreach (var res in result)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"ID: {res.Id}");
                Console.WriteLine($"Name: {res.Name}");
                Console.WriteLine($"Date: {res.Date}");
                Console.WriteLine($"Hours worked: {res.HoursWorked}");
            }
            Console.WriteLine("---------------------------------");
        }

        public async Task PostEntry()
        {
            var client = _httpClientFactory.CreateClient();

            // Get input for a new shift entry
            var shiftEntry = new ShiftDTO
            {
                Name = _input.GetName(),
                Date = _input.GetDate(),
                HoursWorked = _input.GetHoursWorked()
            };

            // Takes shiftEntry and turns it into a Json which is then posted to the link
            await client.PostAsJsonAsync(link, shiftEntry);
        }

        public async Task UpdateEntry()
        {
            var client = _httpClientFactory.CreateClient();

            // Get the ID entry the user wants to edit
            var input = _input.GetIdEntry();

            // Verify that the entry is of the integer type, if not the request will not go through
            var isInt = _validate.IsInteger(input);

            // Get input for a new shift entry
            var shiftEntry = new ShiftDTO
            {
                Id = isInt,
                Name = _input.GetName(),
                Date = _input.GetDate(),
                HoursWorked = _input.GetHoursWorked()
            };

            // Takes shiftEntry and turns it into a json which is then posted to the specified link
            await client.PutAsJsonAsync($"{link}/{isInt}", shiftEntry);
        }

        public async Task DeleteEntry()
        {
            var client = _httpClientFactory.CreateClient();

            // Get the ID entry the user wants to edit
            var input = _input.GetIdEntry();

            // Verify that the entry is of the integer type, if not the request will not go through
            var isInt = _validate.IsInteger(input);

            await client.DeleteAsync($"{link}/{isInt}");
        }
    }
}
