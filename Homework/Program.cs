using Newtonsoft.Json;

namespace Program.cs
{
    class Program
    {
        private static readonly string apiKey = "3a938f3d47264a3a9ed191109250501"; 
        private static readonly string baseUrl = "http://api.weatherapi.com/v1/current.json";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Zadejte město pro zjištění počasí:");
            string city = Console.ReadLine();

            var weatherData = await GetWeatherDataAsync(city);

            if (weatherData != null)
            {
                Console.WriteLine($"Počasí v městě {city}:");
                Console.WriteLine($"Teplota: {weatherData.Current.TempC}°C");
                Console.WriteLine($"Stav počasí: {weatherData.Current.Condition.Text}");
                Console.WriteLine($"Vlhkost: {weatherData.Current.Humidity}%");
                Console.WriteLine($"Vítr: {weatherData.Current.WindKph} km/h");
            }
            else
            {
                Console.WriteLine("Nepodařilo se načíst data.");
            }
        }

        // Metoda pro stažení dat
        public static async Task<WeatherResponse> GetWeatherDataAsync(string city)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Sestavení URL s parametry
                    string url = $"{baseUrl}?key={apiKey}&q={city}&aqi=no";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(json);
                        return weatherResponse;
                    }
                    else
                    {
                        Console.WriteLine("Chyba při volání API.");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Došlo k chybě: {ex.Message}");
                    return null;
                }
            }
        }
    }

    // Třída pro deserializaci odpovědi z API
    public class WeatherResponse
    {
        public CurrentWeather Current { get; set; }
    }

    public class CurrentWeather
    {
        public double TempC { get; set; }
        public Condition Condition { get; set; }
        public int Humidity { get; set; }
        public double WindKph { get; set; }
    }

    public class Condition
    {
        public string Text { get; set; }
    }
}
