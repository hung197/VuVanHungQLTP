using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoBackEndQlTp2.Models;
using demoBackEndQlTp2.Service;
using demoBackEndQlTp2.ViewModels.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace demoBackEndQlTp2
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<APIDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Connect"), builder => builder.UseRowNumberForPaging()));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            var mapper = AutoMapperConfig.RegisterMappping().CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<Services>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });
            app.UseCors(Options =>
            {
                Options.WithOrigins("http://localhost:4200")
                .AllowAnyMethod().AllowAnyHeader();
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseSwagger();
            app.UseHttpsRedirection();
            app.UseMvc();
            
        }
    }
}
