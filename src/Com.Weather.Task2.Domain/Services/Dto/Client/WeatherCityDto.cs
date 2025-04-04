namespace Com.Weather.Task2.Domain.Services.Dto.Client
{
    public class WeatherCityDto
    {
        public CoordDto Coord { get; set; }
        public SysDto Sys { get; set; }
        public IEnumerable<WeatherDto> Weather { get; set; }
        public MainDto Main { get; set; }
        public int Visibility { get; set; }
        public WindDto Wind { get; set; }
        public CloudsDto Clouds { get; set; }
        public long Dt { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
