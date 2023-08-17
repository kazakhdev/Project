
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using project.Helpers;
namespace project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            


            services.AddMvc();

            services.AddControllers();

            services.AddMemoryCache();

            services.AddSession();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            


            //    
            services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(Configuration["ConnectionString"]));

            //   services.AddScoped<IStatusService, StatusService>();
            //   services.AddScoped<IDirectoryRepository, DirectoryRepository>();
            //   services.AddScoped<IDirectoryService, DirectoryService>();
            //   services.AddScoped<IStatusRepository, StatusRepository>();
            //   services.AddScoped<ITodoService, TodoService>();
            //   services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyPolicy");

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