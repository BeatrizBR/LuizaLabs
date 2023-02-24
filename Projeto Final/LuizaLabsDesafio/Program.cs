using LuizaLabsDesafio.Data;
using LuizaLabsDesafio.Repositories.Interface;
using LuizaLabsDesafio.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.Swagger;
using Microsoft.OpenApi.Models;

namespace LuizaLabsDesafio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("Login", new OpenApiInfo { Title = "UserController", Version = "3.0.0" });
			});

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


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }


            //Ativa o Swagger
            app.UseSwagger();
			// Ativa o Swagger UI
			app.UseSwaggerUI(opt =>
				{
					opt.SwaggerEndpoint("/api/user", "Login");
				});


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