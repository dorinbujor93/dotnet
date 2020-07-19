using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using BikeStore___Project.Data;
using BikeStore___Project.Data.Entities;
using BikeStore___Project.Data.Persistence;
using BikeStore___Project.Domain.Models;
using BikeStore___Project.Domain.Services;
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

    }
}