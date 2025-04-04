import React, { useEffect, useState } from 'react';
import { CountryWeather } from '../../../types/weather';
import { getWeather } from '../../../api/services/weatherService';
import CountryCard from '../country-card/CountryCard';
import { toast } from 'react-toastify';
import './WeatherList.css';

const WeatherList: React.FC = () => {
    const [weatherData, setWeatherData] = useState<CountryWeather[]>([]);

    useEffect(() => {
        const fetchWeatherData = async () => {
            try {
                const data = await getWeather();
                setWeatherData(data);
            } catch (error) {
                console.error('Error fetching weather data:', error);
                toast.error('Undable to fetch weather data.');
            }
        };
        fetchWeatherData();
    }, []);

    return (
        <div className="weather-list-container">
            {weatherData.map((country) => (
                <CountryCard key={country.name} country={country} />
            ))}
        </div>
    );
};

export default WeatherList;