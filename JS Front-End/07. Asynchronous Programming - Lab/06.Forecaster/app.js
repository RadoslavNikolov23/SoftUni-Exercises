function attachEvents() {
  const weatherSymbols = {
    Sunny: "&#x2600",
    "Partly sunny": "&#x26C5",
    Overcast: "&#x2601",
    Rain: "&#x2614",
    Degrees: "&#176",
  };


  const locationInput = document.getElementById("location");
  const getWeatherBtn = document.getElementById("submit");

  const forecastDiv = document.getElementById("forecast");
  const currentDiv = document.getElementById("current");
  const upcomingDiv = document.getElementById("upcoming");

  getWeatherBtn.addEventListener("click", getWeather);

  async function getWeather() {
    const url = `http://localhost:3030/jsonstore/forecaster/locations`;
    const locationName = locationInput.value;

    try {
      const response = await fetch(url);

      if (!response.ok) {
        dispayError();
        return;
      }

      const dataResponse = await response.json();
      let locationCode = "";

      for (const { name, code } of dataResponse) {
        if (name === locationName) {
          locationCode = code;
          break;
        }
      }

      if (locationCode === "") {
        dispayError();
        return;
      }

      const todayUrl = `http://localhost:3030/jsonstore/forecaster/today/${locationCode}`;
      const upcomingUrl = `http://localhost:3030/jsonstore/forecaster/upcoming/${locationCode}`;

      const todayResponse = await fetch(todayUrl);
      const upcomingResponse = await fetch(upcomingUrl);

      if (!todayResponse.ok || !upcomingResponse.ok) {
        dispayError();
        return;
      }

      const today = await todayResponse.json();
      const upcoming = await upcomingResponse.json();
      
      appendCurrentWeather(today,upcoming);
      appendUpcomingWeather(today,upcoming);   

      forecastDiv.style.display = "block";
      currentDiv.style.display = "block";
      upcomingDiv.style.display = "block";

      
      locationInput.value = "";

    } catch (error) {
         dispayError();
    }
  }

  function  appendCurrentWeather(today, upcoming){
      const currentCondition = document.createElement("div");
      currentCondition.classList.add("forecasts");
      currentCondition.innerHTML = `
            <span class="condition symbol">${weatherSymbols[today.forecast.condition]}</span>
            <span class="condition">
                <span class="forecast-data">${today.name}</span>
                <span class="forecast-data">${today.forecast.low}${weatherSymbols.Degrees}/${today.forecast.high}${weatherSymbols.Degrees}</span>
                <span class="forecast-data">${today.forecast.condition}</span>
            </span>`;
      currentDiv.appendChild(currentCondition); 
  }

  function appendUpcomingWeather(today, upcoming){
      const upcomingForecast = document.createElement("div");
      upcomingForecast.classList.add("forecast-info");

      for (const day of upcoming.forecast) {
        const upcomingSpan = document.createElement("span");
        upcomingSpan.classList.add("upcoming");
        upcomingSpan.innerHTML = `
                <span class="symbol">${weatherSymbols[day.condition]}</span>
                <span class="forecast-data">${day.low}${weatherSymbols.Degrees}/${day.high}${weatherSymbols.Degrees}</span>
                <span class="forecast-data">${day.condition}</span> `;
        upcomingForecast.appendChild(upcomingSpan);
      }

      upcomingDiv.appendChild(upcomingForecast);
  }

  
  function dispayError() {
        forecastDiv.style.display = "block";
        const errorDiv = document.createElement("div");
        errorDiv.textContent = "Error";
        forecastDiv.appendChild(errorDiv);
        currentDiv.style.display = "none";
        upcomingDiv.style.display = "none";

        locationInput.value = "";
  }
}

attachEvents();
