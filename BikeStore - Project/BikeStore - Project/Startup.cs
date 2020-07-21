using System;
using System.Collections.Generic;
using System.Linq;
using BikeStore___Project.Data;
using System.Threading.Tasks;
using AutoMapper;
using BikeStore___Project.Data.Persistence;
using BikeStore___Project.Data.Persistence.Repositories;
using BikeStore___Project.Domain.Repositories;
using BikeStore___Project.Domain.Services;
using BikeStore___Project.Middleware;
using BikeStore___Project.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


namespace BikeStore___Project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Bike store API", Version = "v1"});
            });

            // Repositories dependencies binding
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBikeRepository, BikeRepository>();
            services.AddScoped<IAccessoryRepository, AccessoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IShopRepository, ShopRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            // Services dependencies binding
            services.AddScoped<IBikeService, BikeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAccessoryService, AccessoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IOrderService, OrderService>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(env.IsDevelopment() ? "/error-local-development" : "/error");
            app.UseRouting();
            app.UseSwagger();
            app.UseMiddleware<RequestInfoMiddleware>();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bike store API V1"); });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}