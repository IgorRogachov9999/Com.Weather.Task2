import React from 'react';
import WeatherList from './components/weather/weather-list/WeatherList';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const App: React.FC = () => {
  return (
    <div className="flex flex-col min-h-screen">
      
      <main className="flex-grow container mx-auto p-4">
        <WeatherList />
      </main>

      <ToastContainer position="top-center" autoClose={5000} hideProgressBar={false} />
    </div>
  );
};

export default App;