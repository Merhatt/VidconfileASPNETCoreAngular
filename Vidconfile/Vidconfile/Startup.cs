﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Vidconfile.Data;
using Vidconfile.Data.Contracts;
using Vidconfile.Services;
using Vidconfile.Services.Services;
using Vidconfile.Utils;
using Vidconfile.Utils.Contracts;

namespace Vidconfile
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VidconfileDBContext>(x => x.UseSqlite(this.Configuration.GetConnectionString("DefaultConnection")));
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Utils
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            //Services
            services.AddScoped<IVidconfileUserServices, VidconfileUserServices>();

            //Data
            services.AddScoped<IVidconfileDBContext, VidconfileDBContext>();
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseMvc();
        }
    }
}