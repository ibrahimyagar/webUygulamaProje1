using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using webUygulamaProje1.Models;
using webUygulamaProje1.Utility;

namespace webUygulamaProje1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<UygulamaDbContext>(Options=>
            Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //_kitapTuruRepository nesnesi =>Dependecy ýnjection
            builder.Services.AddScoped<IKitapTuruRepository, KitapTuruRepository>();

            //_kitapRepository nesnesi =>Dependecy ýnjection
            builder.Services.AddScoped<IKitapRepository, KitapRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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
