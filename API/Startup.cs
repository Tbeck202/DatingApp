using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        // In order to use the underscore which denotes a private property,
        // go to preferences > settings, search "private" and enter the underscore character in the text field
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            // the underscore character replaces the "this" keyword.
            // Go to preferences > settings, search for "this", click C# extentions, uncheck the box
            _config = config;
        }

        // public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // This block is needed to connect to the DB
            services.AddDbContext<DataContext>(options =>
            {
                // The connection string comes from appsettings.Development.json,
                // which is where we created the default connection string
                options.UseSqlite(_config.GetConnectionString("DefaultConnection"));
            });

            /* 
                Go to nuget.org and search for "dotnet-ef"
                Click the URL for "dotnet-ef", copy the CLI command but 
                MAKE SURE the version matches your runtime version.
                Paste the command in terminal. 
                You might need to use nuget/nuget gallery to install Microsoft.EntityFrameworkCore.Design
                So do that if neccessary and then try the terminal command again
            */

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIv5 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
