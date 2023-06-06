// See https://aka.ms/new-console-template for more information
using json;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        var weatherForecast = new WeatherForecast
        {
            Date = DateTime.Parse("2019-08-01"),
            TemperatureCelsius = 25,
            Summary = "Hot",
            SummaryField = "Hot",
            DatesAvailable = new List<DateTimeOffset>()
                    { DateTime.Parse("2019-08-01"), DateTime.Parse("2019-08-02") },
            TemperatureRanges = new Dictionary<string, HighLowTemps>
            {
                ["Cold"] = new HighLowTemps { High = 20, Low = -10 },
                ["Hot"] = new HighLowTemps { High = 60, Low = 20 }
            },
            SummaryWords = new[] { "Cool", "Windy", "Humid" }
        };

        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(weatherForecast, options);
        string fileName = "WeatherForecast.json";
        File.WriteAllText(fileName, jsonString);

        Console.WriteLine(File.ReadAllText(fileName));
        
        Console.WriteLine(jsonString);
    }
}