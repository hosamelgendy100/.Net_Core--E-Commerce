﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EcommerceApplication.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using EcommerceApplication.Models;
using EcommerceApplication.Services.Infrastructure;
using EcommerceApplication.Services.Repository;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace EcommerceApplication
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddDbContext<MyContext>(options=>options.UseSqlServer(Configuration
                ["ConnectionStrings:DefaultConnection"]));

            services.AddIdentity<Customer, ApplicationRole>()
                .AddEntityFrameworkStores<MyContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IProduct, ProductRepository>();
            services.AddScoped<ICategory, CategoryRepository>();
            services.AddScoped<ISubCategory, SubCategoryRepository>();
            services.AddSingleton<IOrder, OrderRepository>();
            services.AddScoped<IOrderLine, OrderLineRepository>();
            services.AddTransient<IPicture, PictureRepository>();
            services.AddScoped<ICartItem, CartItemRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            
            // Using Angular Folder
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"client")),
                RequestPath = new PathString("/client")
            });

            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                // Admin Area route
                routes.MapRoute(
                    name: "AdminAreaRoute",
                    template: "{area:exists}/{controller=Products}/{actions=Index}/{id?}"); 
            });
        }
    }
}
