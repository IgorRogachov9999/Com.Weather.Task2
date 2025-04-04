namespace Com.Weather.Task2.Domain.Services.Dto.Client
{
    public class MainDto
    {
        public decimal Temp { get; set; }
        public decimal Feels_Like { get; set; }
        public decimal Temp_Min { get; set; }
        public decimal Temp_Max { get; set; }
        public int Pressure { get; set; }
        public int Sea_Level { get; set; }
        public int Grnd_Level { get; set; }
        public int Humidity { get; set; }
    }
}
