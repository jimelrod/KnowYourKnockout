using EODG.FirebaseAuthTool;
using KnowYourKnockout.Business;
using KnowYourKnockout.Data;
using KnowYourKnockout.Data.Models;
using KnowYourKnockout.Data.Repositories;
using KnowYourKnockout.Utility;
using KnowYourKnockout.Web.Api.Auth;
using KnowYourKnockout.Web.Api.Config;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NLog.Extensions.Logging;
using System;
using System.IO;

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
            // Change this to be environmemnt specefic....
            services.AddDbContext<KnowYourKnockoutContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("Local"))
            );

            services.AddMvc();

            services.AddCors(options => {
                options.AddPolicy("AllowAnyOrigin",
                    builder => 
                        builder
                            .AllowAnyOrigin()
                            //.WithOrigins("http://localhost:8080", "http://localhost:9000")
                            .AllowAnyHeader()
                            .AllowAnyMethod());
            });

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAnyOrigin"));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("FirebaseJwt", policy =>
                {
                    // TODO: Pull from appsettings.json...
                    policy.Requirements.Add(new FirebaseAuthRequirement("knowyourknockout"));
                });
            });

            services.AddSingleton<IAuthorizationHandler, FirebaseAuthHandler>();

            services.AddOptions();

            services.Configure<FirebaseAuthSettings>(Configuration.GetSection("FirebaseAuthSettings"));

            // DI Mapping
            // TODO: FIGURE OUT PROPOER TYPE... NOT TRANSIENT PROBABLY
            services.AddTransient<UserLogic, UserLogic>();
            services.AddTransient<TagLogic, TagLogic>();
            services.AddTransient<Log, Log>();
            services.AddTransient<IKnowYourKnockoutContext, KnowYourKnockoutContext>();
            services.AddTransient<IKnowYourKnockoutDataApi, KnowYourKnockoutDataApi>();
            services.AddTransient<IKnowYourKnockoutRepository<User, int>, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            loggerFactory.AddNLog();
            env.ConfigureNLog("nlog.config");

            app.UseMvc();
        }

        private bool MyValidator(SecurityKey k, SecurityToken t, TokenValidationParameters p)
        {
            return true;
        }
    }
}
