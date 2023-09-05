using ConsoleApp1;

WeatherData weatherData = new WeatherData();
WeatherDisplay weatherDisplay = new WeatherDisplay(weatherData);

weatherData.SetTemperature(25);
weatherData.SetTemperature(30);