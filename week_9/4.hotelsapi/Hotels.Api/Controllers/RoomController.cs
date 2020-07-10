﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotels.Api.Data;
using Hotels.Api.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Api.Controllers
{
    // [Route("api/hotels/{id}/rooms")]
    // [ApiController]
    // public class RoomController : ControllerBase
    // {
    //     private readonly ApiDbContext context;
    //     public RoomController(ApiDbContext context)
    //     {
    //         this.context = context;
    //     }
    //
    //     // GET: api/Hotels
    //     [HttpGet]
    //     public async Task<ActionResult<IEnumerable<Hotel>>> GetTodoItems()
    //     {
    //         return await context.Hotels.ToListAsync();
    //     }
    //
    //     // GET: api/Hotel/5
    //     [HttpGet("{id}")]
    //     public async Task<ActionResult<Hotel>> GetHotel(long id)
    //     {
    //         var todoItem = await context.Hotels.FindAsync(id);
    //
    //         if (todoItem == null)
    //         {
    //             return NotFound();
    //         }
    //
    //         return todoItem;
    //     }
    //
    //     // PUT: api/Hotel/5
    //     [HttpPut("{id}")]
    //     public async Task<IActionResult> PutTodoItem(long id, Hotel hotel)
    //     {
    //         if (id < 0)
    //         {
    //             throw new ArgumentException("negative id");
    //         }
    //
    //         context.Entry(hotel).State = EntityState.Modified;
    //
    //         try
    //         {
    //             await context.SaveChangesAsync();
    //         }
    //         catch (DbUpdateConcurrencyException)
    //         {
    //             if (!HotelExists(id))
    //             {
    //                 return NotFound();
    //             }
    //
    //             throw;
    //         }
    //
    //         return NoContent();
    //     }
    //
    //
    //
    //     // POST: api/Hotel
    //     // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    //     // more details see https://aka.ms/RazorPagesCRUD.
    //     [HttpPost]
    //     public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
    //     {
    //         context.Hotels.Add(hotel);
    //         await context.SaveChangesAsync();
    //
    //         return CreatedAtAction($"GetHotel", new { id = hotel.Id }, hotel);
    //     }
    //
    //     // DELETE: api/Hotel/5
    //     [HttpDelete("{id}")]
    //     public async Task<ActionResult<Hotel>> DeleteTodoItem(long id)
    //     {
    //         var hotel = await context.Hotels.FindAsync(id);
    //
    //         if (hotel == null)
    //         {
    //             return NotFound();
    //         }
    //
    //         context.Hotels.Remove(hotel);
    //         await context.SaveChangesAsync();
    //
    //         return hotel;
    //     }
    //
    //     private bool HotelExists(long id)
    //     {
    //         return context.Hotels.Any(e => e.Id == id);
    //     }
    // }
}