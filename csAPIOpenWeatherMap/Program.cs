using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csAPIOpenWeatherMap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Weather w = new Weather();
            w.GetAPIResponse("10023");
            w.GetTemp();
            w.GetHumidity();
            w.GetCondition();
            w.GetWindSpeed();
            w.GetCityName();
            Console.WriteLine(w.Temperature);
            Console.WriteLine(w.HeatIndex);
            Console.WriteLine(w.Condition);
            Console.WriteLine(w.Humidity);
            Console.WriteLine(w.WindSpeed);
            Console.WriteLine(w.CityName); 


    }
}
}
