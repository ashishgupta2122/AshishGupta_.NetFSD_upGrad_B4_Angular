import { getWeatherWithPromise, getWeatherAsync } from './weatherService.js';

const city = "Mumbai";

getWeatherWithPromise(city).then((result) => {
    console.log("=== Promise Version ===");
    console.log(result);
});


const runAsync = async () => {
    const result = await getWeatherAsync(city);
    console.log("=== Async/Await Version ===");
    console.log(result);
};

runAsync();