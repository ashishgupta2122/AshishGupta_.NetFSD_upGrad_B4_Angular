import fetch from 'node-fetch';

const API_KEY = "8216d7a788834b794fb69f9cc3c3f154";


const getWeatherURL = (city) =>
    `https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${API_KEY}&units=metric`;


export const getWeatherWithPromise = (city) => {
    return fetch(getWeatherURL(city))
        .then((response) => {
            if (!response.ok) {
                throw new Error("City not found or API error");
            }
            return response.json();
        })
        .then((data) => formatWeather(data))
        .catch((error) => {
            return `Error: ${error.message}`;
        });
};


export const getWeatherAsync = async (city) => {
    try {
        const response = await fetch(getWeatherURL(city));

        if (!response.ok) {
            throw new Error("City not found or API error");
        }

        const data = await response.json();
        return formatWeather(data);

    } catch (error) {
        return `Error: ${error.message}`;
    }
};

const formatWeather = (data) => {
    return `
    Weather Report for ${data.name}

    Temperature: ${data.main.temp}°C
    Feels Like: ${data.main.feels_like}°C
    Condition: ${data.weather[0].description}
    Humidity: ${data.main.humidity}%
    Wind Speed: ${data.wind.speed} m/s
`;
};