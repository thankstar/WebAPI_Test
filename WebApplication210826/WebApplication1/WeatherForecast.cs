using System;

namespace WebApplication1
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
		public string Test1 { get; set; }
        public string Test2 { get; set; }
        public string Test4 { get; set; }
	    public string Test3 { get; set; }
	    public string Test5 { get; set; }
        public string Test6 { get; set; }
    }
}
