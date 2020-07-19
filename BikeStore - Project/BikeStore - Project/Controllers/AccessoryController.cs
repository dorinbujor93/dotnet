using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Data;
using BikeStore___Project.Data.Entities;
using BikeStore___Project.Data.Persistence;
using BikeStore___Project.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaddleStore___Project.Resources;

namespace BikeStore___Project.Controllers
{
    [Route("api/bikes/{id}/accessory")]
    [ApiController]
    public class AccessoryController : ControllerBase
    {
        // private readonly AppDbContext context;
        //
        // public AccessoryController(AppDbContext context)
        // {
        //     this.context = context;
        // }
        //
        // [HttpGet("{accessoryId}")]
        // public async Task<ActionResult<AccessoryResource>> GetAccessory(int id, long accessoryId)
        // {
        //     var bike = await context.Bikes.Include(x => x.Accessories).FirstAsync(x => x.Id == id);
        //     var accessory = bike.Accessories.FirstOrDefault(x => x.Id == accessoryId);
        //
        //     if (accessory == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     return Ok(new AccessoryResource
        //     {
        //         Name = accessory.Name,
        //         Brand = accessory.Brand,
        //         Weight = accessory.Weight,
        //         Id = accessory.Id,
        //     });
        // }

        // [HttpPost("")]
        // public async Task<ActionResult<Accessory>> CreateAccessory(int id, AccessoryResource accessory)
        // {
        //     // var bike = await context.Bikes.FindAsync(id);
        //
        //     // var accessoryEntity = accessory.MapToEntity();
        //
        //     // accessoryEntity.Bike = bike;
        //
        //     // context.Accessories.Add(accessoryEntity);
        //
        //     // await context.SaveChangesAsync();
        //
        //     // return CreatedAtAction("GetAccessory", new { id = bike.Id, accessoryId = accessory.Id }, accessoryEntity.MapToResource());
        // }
    }
}