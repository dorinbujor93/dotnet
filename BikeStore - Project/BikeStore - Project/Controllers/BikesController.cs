using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using BikeStore___Project.Data;
using BikeStore___Project.Data.Persistence;
using BikeStore___Project.Domain.Models;
using BikeStore___Project.Domain.Services;
using BikeStore___Project.Extensions;
using BikeStore___Project.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStore___Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikesController : ControllerBase
    {
        private readonly IBikeService _bikeService;
        private readonly IMapper _mapper;
        public BikesController(IMapper mapper, IBikeService bikeService)
        {
            _bikeService = bikeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BikeResource>> ListAsync()
        {
            var bikes = await _bikeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Bike>, IEnumerable<BikeResource>>(bikes);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Negative parameter exception");
            }

            var bike = await _bikeService.GetAsync(id);
            if (bike == null)
            {
                return NotFound();
            }

            var eTag = Hashing.GetHashString(bike.RowVersion);
            HttpContext.Response.Headers.Add("If-Match", eTag);

            var resource = _mapper.Map<Bike, BikeResource>(bike);

            return Ok(resource);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveBikeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var bike = _mapper.Map<SaveBikeResource, Bike>(resource);

            var result = await _bikeService.SaveAsync(bike);

            if (!result.Success)
                return BadRequest(result.Message);

            var bikeResource = _mapper.Map<Bike, BikeResource>(result.Bike);
            return Ok(bikeResource);
        }
    
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBikeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            if (!HttpContext.Request.Headers.ContainsKey("If-Match"))
            {
                return new StatusCodeResult(412);
            }
            var eTag = HttpContext.Request.Headers["If-Match"];
            var bike = _mapper.Map<SaveBikeResource, Bike>(resource);
            var result = await _bikeService.UpdateAsync(id, bike, eTag);
    
            if (!result.Success)
                return BadRequest(result.Message);
    
            var bikeResource = _mapper.Map<Bike, BikeResource>(result.Bike);
            return Ok(bikeResource);
        }
    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _bikeService.DeleteAsync(id);
    
            if (!result.Success)
                return BadRequest(result.Message);
    
            var bikeResource = _mapper.Map<Bike, BikeResource>(result.Bike);
            return Ok(bikeResource);
        }
    }

}
