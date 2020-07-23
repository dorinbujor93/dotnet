using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BikeStoreClient.Controllers
{
    [ApiController]
    public class BikesController : ControllerBase
    {
        private readonly IHttpClientFactory _factory;

        public BikesController(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        [HttpGet("/consumePut/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5050");
            if (disco.IsError)
            {
                return Problem(disco.Error);
            }

            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "api1"
            });

            if (tokenResponse.IsError)
            {
                return Problem(tokenResponse.Error);
            }


            // call api
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync("http://localhost:56508/identity");
            if (!response.IsSuccessStatusCode)
            {
                return Problem(response.ReasonPhrase);
            }


            //get bike from store
            var getBikeResponse = await client.GetAsync($"http://localhost:56508/api/Bikes/" + id);
            
            if (!getBikeResponse.IsSuccessStatusCode)
            {
                if (getBikeResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    return this.NotFound();
                }
            }
            var getHotelResource = JsonConvert.DeserializeObject<dynamic>(getBikeResponse.Headers.ToString());
            //update bike using put method

            // var putBikeResponse = await client.PutAsync($"http://localhost:56508/api/Bikes/" + id);
            //
            // if (!getBikeResponse.IsSuccessStatusCode)
            // {
            //     if (getBikeResponse.StatusCode == HttpStatusCode.NotFound)
            //     {
            //         return this.NotFound();
            //     }
            // }




            return this.Ok();
        }
    }
}