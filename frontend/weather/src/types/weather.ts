export interface CityWeather {
    name: string;
    minValue: number;
    maxValue: number;
    timestamp: string;
  }
  
  export interface CountryWeather {
    name: string;
    cities: CityWeather[];
  }
  
  export type WeatherResponse = CountryWeather[];