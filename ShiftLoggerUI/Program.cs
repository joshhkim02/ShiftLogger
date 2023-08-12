using System.Net.Http.Headers;
using System.Net.Http.Json;
using ShiftLoggerUI.Models;

using HttpClient client = new();

client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json"));

var link = "https://localhost:7036/api/shiftlogger";

var response = await client.GetAsync(link); 

Console.WriteLine(response);