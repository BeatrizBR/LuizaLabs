using LuizaLabsDesafio.Data;
using LuizaLabsDesafio.Repositories.Interface;
using LuizaLabsDesafio.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LuizaLabsDesafio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddEntityFrameworkSqlServer()
                                .AddDbContext<UserSystemContext>(
                                                options => options.UseSqlServer(
                                                                builder.Configuration.GetConnectionString("DataBase"),
                                                                options => options.EnableRetryOnFailure()
                                                                )
                                                );
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

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