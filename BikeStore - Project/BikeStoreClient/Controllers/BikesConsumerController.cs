using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BikeStoreClient.Enums;
using BikeStoreClient.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BikeStoreClient.Controllers
{
    [ApiController]
    public class BikesConsumerController : ControllerBase
    {
        private readonly IHttpClientFactory _factory;
        private readonly ILogger<BikesConsumerController> _logger;
        private const string IdentityServerUri = "http://localhost:5050/";
        private const string ApiUri = "http://localhost:56508/";

        public BikesConsumerController(IHttpClientFactory factory, ILogger<BikesConsumerController> logger)
        {
            _factory = factory;
            _logger = logger;
        }

        [HttpGet("/bike/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var client = await GetAuthorizedClient();

            //get bike from store
            var getBikeResponse = await client.GetAsync($"{ApiUri}api/Bikes/{id}");
            if (!getBikeResponse.IsSuccessStatusCode)
            {
                if (getBikeResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    return this.NotFound();
                }

                return StatusCode((int) getBikeResponse.StatusCode);
            }

            var responseStream = await getBikeResponse.Content.ReadAsStreamAsync();

            using var streamReader = new StreamReader(responseStream);
            using var jsonReader = new JsonTextReader(streamReader);
            var bike = new JsonSerializer().Deserialize<BikeModel>(jsonReader);


            return this.Ok(bike);
        }

        [HttpGet("/bikes")]
        public async Task<IActionResult> GetBikesAsync()
        {
            var client = await GetAuthorizedClient();

            //get all bikes from store
            var getBikeResponse = await client.GetAsync($"{ApiUri}api/Bikes");
            if (!getBikeResponse.IsSuccessStatusCode)
            {
                if (getBikeResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    return this.NotFound();
                }

                return StatusCode((int) getBikeResponse.StatusCode);
            }

            var responseStream = await getBikeResponse.Content.ReadAsStreamAsync();

            using var streamReader = new StreamReader(responseStream);
            using var jsonReader = new JsonTextReader(streamReader);
            var bikes = new JsonSerializer().Deserialize<IEnumerable<BikeModel>>(jsonReader);

            return this.Ok(bikes);
        }

        [HttpPost("/bike")]
        public async Task<IActionResult> CreateBikeAsync()
        {
            var client = await GetAuthorizedClient();

            var newBike = new SaveBikeModel
            {
                Color = "Red",
                BikeOwnerId = 1,
                CategoryId = 2,
                FrameSize = EFrameSize.Medium,
                FrameType = EFrameType.Aluminum
            };


            var bikeContent = new StringContent(JsonConvert.SerializeObject(newBike), Encoding.UTF8, "application/json");
            //Add bike to store
            var postResponse = await client.PostAsync($"{ApiUri}api/Bikes", bikeContent);

            var responseStream = await postResponse.Content.ReadAsStringAsync();

            var createdBike = JsonConvert.DeserializeObject<SaveBikeModel>(responseStream);

            return Ok(createdBike);
        } 
        
        [HttpPut("/bike/{id}")]
        public async Task<IActionResult> UpdateBikeAsync(int id)
        {

            //TEST bike update
            var client = await GetAuthorizedClient();

            //get existing bike from store
            var getBikeResponse = await client.GetAsync($"{ApiUri}api/Bikes/{id}");
            if (!getBikeResponse.IsSuccessStatusCode)
            {
                if (getBikeResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    return this.NotFound();
                }

                return StatusCode((int)getBikeResponse.StatusCode);
            }

            var getResponseStream = await getBikeResponse.Content.ReadAsStreamAsync();
            using var streamReader = new StreamReader(getResponseStream);
            using var jsonReader = new JsonTextReader(streamReader);
            var bike = new JsonSerializer().Deserialize<BikeModel>(jsonReader);

            //Only for testing - changing bike properties
            bike.Color = "udated color";
            bike.FrameType = EFrameType.Carbon;
            bike.FrameSize = EFrameSize.ExtraLarge;
            bike.CategoryId = 1;
            bike.BikeOwnerId = 2;

            //Updating store with new object changes
            var bikeContent = new StringContent(JsonConvert.SerializeObject(bike), Encoding.UTF8, "application/json");
            var eTag = getBikeResponse.Headers.GetValues("If-Match");
            client.DefaultRequestHeaders.IfMatch.Add(new EntityTagHeaderValue("\""+ eTag + "\"" ));

            //Add bike to store
            var postResponse = await client.PostAsync($"{ApiUri}api/Bikes", bikeContent);

            var responseStream = await postResponse.Content.ReadAsStringAsync();

            var createdBike = JsonConvert.DeserializeObject<SaveBikeModel>(responseStream);

            return Ok(createdBike);
        }

        [HttpDelete("bike/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var client = await GetAuthorizedClient();
            var deleteAsyncResponse = await client.DeleteAsync($"{ApiUri}api/Bikes/{id}");
            if (!deleteAsyncResponse.IsSuccessStatusCode)
            {
                if (deleteAsyncResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    return NotFound();
                }

                return StatusCode((int) deleteAsyncResponse.StatusCode);
            }

            var responseStream = await deleteAsyncResponse.Content.ReadAsStreamAsync();

            using var streamReader = new StreamReader(responseStream);
            using var jsonReader = new JsonTextReader(streamReader);
            var deletedBike = new JsonSerializer().Deserialize<BikeModel>(jsonReader);

            return Ok(deletedBike);
        }

        private async Task<HttpClient> GetAuthorizedClient()
        {
            var client = _factory.CreateClient("bikes");
            var disco = await client.GetDiscoveryDocumentAsync(IdentityServerUri);
            if (disco.IsError)
            {
                _logger.LogError(disco.Error);
                throw new Exception(disco.Error);
            }

            // request token from identity server
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "api1"
            });

            if (tokenResponse.IsError)
            {
                _logger.LogError(disco.Error);
                throw new Exception(disco.Error);
            }

            // Set bearer token
            client.SetBearerToken(tokenResponse.AccessToken);

            return client;
        }
    }
}