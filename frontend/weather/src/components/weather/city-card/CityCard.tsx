import React from 'react';
import { CityWeather } from '../../../types/weather';
import './CityCard.css';

interface CityCardProps {
  city: CityWeather;
}

const CityCard: React.FC<CityCardProps> = ({ city }) => {
    const formatDate = (dateString: string) => {
        const date = new Date(dateString);
        return date.toLocaleString();
      };
      
      return (<div className="city-card">
                <div className="city-card-info">
                    <span className="city-card-name">{city.name}</span>
                    <span className="city-card-timestamp">{formatDate(city.timestamp)}</span>
                </div>
                <div className="city-card-temperature">
                    <span className="city-card-temperature-min">{city.minValue}</span>
                    <span className="city-card-temperature-max">{city.maxValue}</span>
                </div>
            </div>);
    };

export default CityCard;