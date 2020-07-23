using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using BikeStore___Project;
using BikeStore___Project.Domain.Models;
using BikeStore___Project.Domain.Services;
using BikeStore___Project.Extensions;
using BikeStore___Project.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeShop___Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;
        private readonly IMapper _mapper;

        public ShopController(IMapper mapper, IShopService shopService)
        {
            _shopService = shopService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ShopResource>> ListAsync()
        {
            var shops = await _shopService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Shop>, IEnumerable<ShopResource>>(shops);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var shop = await _shopService.GetAsync(id);
            if (shop == null)
            {
                return NotFound();
            }

            var eTag = Hashing.GetHashString(shop.RowVersion);
            HttpContext.Response.Headers.Add("If-Match", eTag);

            var resource = _mapper.Map<Shop, ShopResource>(shop);

            return Ok(resource);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveShopResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var shop = _mapper.Map<SaveShopResource, Shop>(resource);

            var result = await _shopService.SaveAsync(shop);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var shopResource = _mapper.Map<Shop, ShopResource>(result.Shop);

            return Ok(shopResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveShopResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            if (!HttpContext.Request.Headers.ContainsKey("If-Match"))
            {
                return new StatusCodeResult(412);
            }

            var eTag = HttpContext.Request.Headers["If-Match"];

            var shop = _mapper.Map<SaveShopResource, Shop>(resource);

            var result = await _shopService.UpdateAsync(id, shop, eTag);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var shopResource = _mapper.Map<Shop, ShopResource>(result.Shop);

            return Ok(shopResource);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _shopService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var resource = _mapper.Map<Shop, ShopResource>(result.Shop);
            return Ok(resource);
        }
    }
}