using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BikeStore___Project.Data;
using BikeStore___Project.Data.Persistence;
using BikeStore___Project.Domain.Models;
using BikeStore___Project.Domain.Services;
using BikeStore___Project.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStore___Project.Controllers
{
    [Route("api/bikes/{id}/accessory")]
    [ApiController]
    [Authorize]
    public class AccessoryController : ControllerBase
    {

        private readonly IAccessoryService _accessoryService;
        private readonly IMapper _mapper;
        public AccessoryController(IMapper mapper, IAccessoryService accessoryService)
        {
            _accessoryService = accessoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AccessoryResource>> ListAsync()
        {
            var accessories = await _accessoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Accessory>, IEnumerable<AccessoryResource>>(accessories);
            return resources;
        }


     }
}