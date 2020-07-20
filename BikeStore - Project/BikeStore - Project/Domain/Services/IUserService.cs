﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;

namespace BikeStore___Project.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
    }
}
