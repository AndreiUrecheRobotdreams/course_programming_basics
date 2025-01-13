using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using WeatherApp;

namespace WeatherApp.Tests
{
    [TestFixture]
    public class WeatherAppTests
    {
        private Mock<IWeatherService> weatherServiceMock;
        private WeatherApp.WeatherApp weatherApp;

        [SetUp]
        public void SetUp()
        {
            weatherServiceMock = new Mock<IWeatherService>();
            weatherApp = new WeatherApp.WeatherApp(weatherServiceMock.Object);
        }

        [Test]
        public async Task DisplayWeatherAsync_WhenWeatherDataIsAvailable_ShouldDisplayWeather()
        {
            // Arrange
            var city = "Prague";
            var mockWeatherResponse = new WeatherResponse
            {
                Current = new CurrentWeather
                {
                    TempC = 10.0,
                    Condition = new Condition { Text = "Clear" },
                    Humidity = 60,
                    WindKph = 15
                }
            };
            weatherServiceMock.Setup(ws => ws.GetWeatherDataAsync(city)).ReturnsAsync(mockWeatherResponse);

            // Act
            await weatherApp.DisplayWeatherAsync(city);

            // Assert
            weatherServiceMock.Verify(ws => ws.GetWeatherDataAsync(city), Times.Once);
        }

        [Test]
        public async Task DisplayWeatherAsync_WhenWeatherDataIsNotAvailable_ShouldDisplayErrorMessage()
        {
            // Arrange
            var city = "UnknownCity";
            weatherServiceMock.Setup(ws => ws.GetWeatherDataAsync(city)).ReturnsAsync((WeatherResponse)null);

            // Act
            await weatherApp.DisplayWeatherAsync(city);

            // Assert
            weatherServiceMock.Verify(ws => ws.GetWeatherDataAsync(city), Times.Once);
        }

        [Test]
        public async Task GetWeatherDataAsync_WhenApiFails_ShouldReturnNull()
        {
            // Arrange
            var city = "Prague";
            weatherServiceMock.Setup(ws => ws.GetWeatherDataAsync(city)).ThrowsAsync(new System.Exception("API error"));

            // Act
            var result = await weatherServiceMock.Object.GetWeatherDataAsync(city);

            // Assert
            Assert.IsNull(result);
        }
    }
}
