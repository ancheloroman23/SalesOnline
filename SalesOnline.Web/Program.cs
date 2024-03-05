using Microsoft.EntityFrameworkCore;
using SalesOnline.Infraestructure.Context;
using SalesOnline.Ioc.Dependencies;
using SalesOnline.Web.Services;

namespace SalesOnline.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Agregar dependencia del contexto //
            builder.Services.AddDbContext<SalesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SalesContext")));




            // Dependencia de los repositorios //
            builder.Services.AddUsuarioDependecy();
            builder.Services.AddScoped<IWebService, WebService>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}