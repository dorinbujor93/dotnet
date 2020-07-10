using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("home")]
public class HomeController : ControllerBase
{
    private readonly IHttpClientFactory factory;
    private readonly ILogger<HomeController> logger;

    public HomeController(IHttpClientFactory factory, ILogger<HomeController> logger)
    {
        this.logger = logger;
        this.factory = factory;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<string>> Get(int id)
    {

        var client = this.factory.CreateClient("hotels-api");
        client.BaseAddress = new Uri("http://localhost:5005");

        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await client.GetAsync($"api/hotels/{id}");
        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return this.NotFound();
            }

            var error = await response.Content.ReadAsStringAsync();
            //this.logger.LogError("Error from Api: " + error);
            return BadRequest();
        }
        
        
        var result = await response.Content.ReadAsStringAsync();
        return result;
    }
}