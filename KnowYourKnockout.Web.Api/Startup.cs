using KnowYourKnockout.Business;
using KnowYourKnockout.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
            var connection = @"Server=W530-JELROD\SQLSVR2014;Database=KnowYourKnockout;Trusted_Connection=True";
            services.AddDbContext<KnowYourKnockoutContext>(options => options.UseSqlServer(connection));

            // Add framework services.
            services.AddMvc();

            services.AddTransient<UserLogic, UserLogic>();
            services.AddTransient<TagLogic, TagLogic>();
            services.AddTransient<KnowYourKnockoutContext, KnowYourKnockoutContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(builder => builder.WithOrigins("*"));// This WILL CHANGE!!!!! You know... security and whatnot...
            app.UseMvc();
        }
    }
}
