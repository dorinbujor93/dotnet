using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BikeStore___Project.Data;
using BikeStore___Project.Data.Entities;
using BikeStore___Project.Data.Persistence;
using BikeStore___Project.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStore___Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        private readonly AppDbContext context;

        public BikeController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/Bikes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BikeResource>>> GetBikes()
        {
            var bikes = await context.Bikes.ToListAsync();
            return Ok(bikes.Select(x => x.MapToResource()));
        }

        // GET: api/Bike/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BikeResource>> GetBike(int id)
        {
            var bike = await context.Bikes.FindAsync(id);

            if (bike == null)
            {
                return NotFound();
            }

            return bike.MapToResource();
        }

        // PUT: api/Bike/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBikeItem(int id, BikeResource bike)
        {
            if (id < 0)
            {
                throw new ArgumentException("Negative ID");
            }

            var entity = await context.Bikes.FindAsync(id);

            // var eTag = MD5.Create().ComputeHash("test").ToString();
            // HttpContext.Response.Headers.Add("ETAG_HEADER", eTag);
            //
            //
            // if (HttpContext.Request.Headers.Keys.Contains("If-None-Match") && HttpContext.Request.Headers["If-None-Match"].ToString() == eTag)
            // {
            //     return new StatusCodeResult(304);
            // }
            //
            // HttpContext.Response.Headers.Add("ETag", new[] { eTag });

            entity.Color = bike.Color;
            entity.Type = bike.Type;

            context.Entry(entity).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BikeExists(id)) return NotFound();
                throw;
            }

            return new StatusCodeResult(200);
        }

        // POST: api/Bike
        [HttpPost]
        public async Task<ActionResult<BikeResource>> PostHotel(BikeResource bike)
        {
            var entity = bike.MapToEntity();
            context.Bikes.Add(entity);

            await context.SaveChangesAsync();

            //notificationService.Notify("message");

            return CreatedAtAction("GetBike", new { id = bike.Id }, entity.MapToResource());
        }

        // DELETE: api/Hotel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bike>> DeleteTodoItem(int id)
        {
            var bike = await context.Bikes.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }

            context.Bikes.Remove(bike);
            await context.SaveChangesAsync();
            return bike;
        }

        private bool BikeExists(int id)
        {
            return context.Bikes.Any(e => e.Id == id);
        }
    }
}