﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;
using BikeStore___Project.Domain.Services.Communication;

namespace BikeStore___Project.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<CategoryResponse> SaveAsync(Category category);
        Task<CategoryResponse> UpdateAsync(int id, Category category, string eTag);
        Task<CategoryResponse> DeleteAsync(int id);
        Task<Category> GetAsync(int id);

    }
}