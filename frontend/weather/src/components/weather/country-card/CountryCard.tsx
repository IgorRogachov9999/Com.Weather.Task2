import React from 'react';
import CityCard from '../city-card/CityCard';
import { CountryWeather } from '../../../types/weather';
import './CountryCard.css';

interface CountryCardProps {
  country: CountryWeather;
}

const CountryCard: React.FC<CountryCardProps> = ({ country }) => {
  return (<div className="country-card">
            <div className="country-card-name">{country.name}</div>
            <div className="country-card-cities">
                {country.cities.map((city) => (
                  <CityCard key={city.name} city={city} />
                ))}
              </div>
          </div>);
};
  
export default CountryCard;