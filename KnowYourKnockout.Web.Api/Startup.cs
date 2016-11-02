using KnowYourKnockout.Business;
using KnowYourKnockout.Data;
using KnowYourKnockout.Data.Models;
using KnowYourKnockout.Data.Repositories;
using KnowYourKnockout.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;

namespace KnowYourKnockout.Web.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=DESKTOP-STNOHJO;Database=KnowYourKnockout;Trusted_Connection=True";
            services.AddDbContext<KnowYourKnockoutContext>(options => options.UseSqlServer(connection));

            // Add framework services.
            services.AddMvc();

            services.AddCors(options => {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => 
                        builder
                            //.AllowAnyOrigin()
                            .WithOrigins("http://localhost:8080", "http://localhost:9000")
                            .AllowAnyHeader()
                            .AllowAnyMethod());
            });

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
            });

            // DI Mapping
            services.AddTransient<UserLogic, UserLogic>();
            services.AddTransient<TagLogic, TagLogic>();
            services.AddTransient<Log, Log>();
            services.AddTransient<IKnowYourKnockoutContext, KnowYourKnockoutContext>();
            services.AddTransient<IKnowYourKnockoutDataApi, KnowYourKnockoutDataApi>();
            services.AddTransient<IKnowYourKnockoutRepository<User, Guid>, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            loggerFactory.AddNLog();
            env.ConfigureNLog("nlog.config");

            //app.UseCors(builder => builder.AllowAnyMethod().AllowAnyOrigin());// This WILL CHANGE!!!!! You know... security and whatnot...
            app.UseMvc();

        }
    }
}
