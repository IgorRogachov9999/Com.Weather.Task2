import axiosClient from '../clients/axiosClient';
import { WeatherResponse } from '../../types/weather';

export const getWeather = async (): Promise<WeatherResponse> => {
  try {
    const response = await axiosClient.get<WeatherResponse>('/api/v1/weather');
    
    if (!response.data) {
      console.warn('API returned empty response');
      return [];
    }
    
    return response.data;
  } catch (error) {
    console.error('Error fetching weather data:', error);
    throw error;
  }
};