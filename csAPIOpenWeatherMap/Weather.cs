using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace csAPIOpenWeatherMap
{
    public class Weather
    {
        public string APIResponse { get; set; }
        public double Temperature { get; set; }
        public double HeatIndex { get; set; }
        public string Condition { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
        public string CityName { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public void GetAPIResponse(string zipcode)
        {
            var key = File.ReadAllText("C:\\Users\\Owner\\repos\\csAPIOpenWeatherMap\\csAPIOpenWeatherMap\\appsettings.json");
            var APIKey = JObject.Parse(key).GetValue("DefaultKey").ToString();
            //            Console.WriteLine(APIKey);
            var countryCode = "US";
            var APIZipCall = $"http://api.openweathermap.org/geo/1.0/zip?zip={zipcode},{countryCode}&appid={APIKey}";
            var client = new HttpClient();
            var response = client.GetStringAsync(APIZipCall).Result;
            var lat = JObject.Parse(response)
                .GetValue("lat").ToString();
            var lon = JObject.Parse(response)
                .GetValue("lon").ToString();
            //            Console.WriteLine(lat+" "+lon);


            var APICall = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={APIKey}&units=imperial";
            var weatherResponse = client.GetStringAsync(APICall).Result;
            this.APIResponse = weatherResponse;
        }

        public void GetTemp()
        {
            this.Temperature = double.Parse(JObject.Parse(this.APIResponse)["main"]["temp"].ToString());
        }
        public void GetHeatIndex() {
            this.HeatIndex = double.Parse(JObject.Parse(this.APIResponse)["main"]["feels_like"].ToString());
        }
        public void GetCondition()
        {
            this.Condition = JObject.Parse(this.APIResponse)["weather"][0]["description"].ToString();
        }
        public void GetHumidity()
        {
            this.Humidity = double.Parse(JObject.Parse(this.APIResponse)["main"]["humidity"].ToString());
        }
        public void GetWindSpeed()
        {
            this.WindSpeed = double.Parse(JObject.Parse(this.APIResponse)["wind"]["speed"].ToString());
        }
        public void GetCityName()
        {
            this.CityName = JObject.Parse(this.APIResponse)["name"].ToString();

        }

            /*
             * 
             "weather": [
    {
      "id": 800,
      "main": "Clear",
      "description": "clear sky",
      "icon": "01d"
    }
  ],
  "base": "stations",
  "main": {
    "temp": 282.55,
    "feels_like": 281.86,
    "temp_min": 280.37,
    "temp_max": 284.26,
    "pressure": 1023,
    "humidity": 100
  },
  "visibility": 10000,
  "wind": {
    "speed": 1.5,
    "deg": 350
  },
  "clouds": {
    "all": 1
  },
  "dt": 1560350645,
  "sys": {
    "type": 1,
    "id": 5122,
    "message": 0.0139,
    "country": "US",
    "sunrise": 1560343627,
    "sunset": 1560396563
  },
  "timezone": -25200,
  "id": 420006353,
  "name": "Mountain View",
  "cod": 200
  }               */
        
    }
}
