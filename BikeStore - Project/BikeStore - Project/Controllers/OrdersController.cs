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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrdersController(IMapper mapper, IOrderService orderService)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderResource>> ListAsync()
        {
            var orders = await _orderService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);
            return resources;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var order = await _orderService.GetAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            var eTag = Hashing.GetHashString(order.RowVersion);
            HttpContext.Response.Headers.Add("If-Match", eTag);

            var resource = _mapper.Map<Order, OrderResource>(order);

            return Ok(resource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveOrderResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var order = _mapper.Map<SaveOrderResource, Order>(resource);

            var result = await _orderService.SaveAsync(order);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var orderResource = _mapper.Map<Order, OrderResource>(result.Order);

            return Ok(orderResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveOrderResource resource)
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
            var order = _mapper.Map<SaveOrderResource, Order>(resource);

            var result = await _orderService.UpdateAsync(id, order, eTag);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var orderResource = _mapper.Map<Order, OrderResource>(result.Order);

            return Ok(orderResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _orderService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Order);
        }
    }
}