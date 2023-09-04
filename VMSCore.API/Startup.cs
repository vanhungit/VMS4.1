using Microsoft.AspNetCore.Authentication;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMSCore.API.EntityModels.Models;
using VMSCore.API.Middlewares;
using VMSCore.Infrastructure.Base.Repositories;
using Hangfire;
using Hangfire.SqlServer;
using VMSCore.API.Services;

namespace VMSCore.API
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VMSCore.API", Version = "v1" });
            });

            // Add AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddControllers().AddNewtonsoftJson();

            // Add DbContext
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EntityDataContextCore>(
                    options => options.UseSqlServer(connectionString));

            // Add repositories
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepositoryCore<>));
            services.AddScoped(typeof(BaseRepositoryCore<>));
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
            //Add authorize
            services.AddAuthentication("BasicAuthentication")
              .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));
            //// Add the processing server as IHostedService
            services.AddHangfireServer();
            //// Add framework services.
            //services.AddMvc();

            //services.AddHangfire(x => x.UseSqlServerStorage("DefaultConnection"));
            //services.AddHangfireServer();
            services.AddTransient<IDummyEmailService, DummyEmailService>();
        }
        //public void Configure(IApplicationBuilder app, IBackgroundJobClient backgroundJobs, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        //{
        //    // ...
        //    app.UseStaticFiles();

        //    app.UseHangfireDashboard();
        //    backgroundJobs.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));

        //    app.UseMvc(routes =>
        //    {
        //        routes.MapRoute(
        //            name: "default",
        //            template: "{controller=Home}/{action=Index}/{id?}");
        //    });
        //}
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())//tắt khi publish
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VMSCore.API v1"));
            }

            app.UseHttpsRedirection();//tắt nếu môi trường cần xác thực

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseHangfireDashboard();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapHangfireDashboard();
            });
        }
    }
}
