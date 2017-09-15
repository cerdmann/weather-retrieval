using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using WeatherRetrieval.DataContracts;
using Pivotal.Discovery.Client;

namespace WeatherRetrieval.Controllers
{
    [Route("[controller]")]
    public class HourlyForecastController : Controller
    {
        DiscoveryHttpClientHandler _handler;

        public HourlyForecastController(IDiscoveryClient client)
        {
          _handler = new DiscoveryHttpClientHandler(client);
        }

        // GET /hourlyforecast?latitude=xxx&longitude=yyyy
        [HttpGet]
        public async Task<IActionResult> Get(string latitude, string longitude)
        {
          if (String.IsNullOrEmpty(latitude) || String.IsNullOrEmpty(longitude))
          {
            return NotFound("Latitude and Longitude are required: /hourlyforecast?latitude=xxxx&longitude=yyyy");
          }

          using (var client = new HttpClient())
          {
            try
            {
              client.BaseAddress = new Uri("http://api.weather.gov");
              client.DefaultRequestHeaders.Accept.Clear();
              client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
              client.DefaultRequestHeaders.Add("User-Agent", "web api client");

              var streamTask = client.GetStreamAsync($"/points/{latitude},{longitude}/forecast/hourly");

              var serializer = new DataContractJsonSerializer(typeof(HourlyWeather));

              var hourlyWeather = serializer.ReadObject(await streamTask) as HourlyWeather;

              return Ok(hourlyWeather.properties);
            }
            catch (HttpRequestException httpRequestException)
            {
              return NotFound("Could not retrieve hourly forecast");
            }
          }
        }


        [HttpGet("byzip/{zip}")]
        public async Task<IActionResult> Get(string zip)
        {
          if (String.IsNullOrEmpty(zip))
          {
            return NotFound("Zip is required");
          }

          using (var client = new HttpClient(_handler, false))
          {
            try
            {
              client.BaseAddress = new Uri("http://latlong-retrieval");
              client.DefaultRequestHeaders.Accept.Clear();
              client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
              client.DefaultRequestHeaders.Add("User-Agent", "web api client");

              var streamTask = client.GetStreamAsync($"/byzip/{zip}");

              var serializer = new DataContractJsonSerializer(typeof(LatLong));

              var latlong = serializer.ReadObject(await streamTask) as LatLong;

              return Ok(Get(latlong.latitude, latlong.longitude));
            }
            catch (HttpRequestException httpRequestException)
            {
              return NotFound("Could not retrieve hourly forecast by zipcode");
            }
          }
        }
    }
}
