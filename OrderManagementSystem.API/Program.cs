
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Application.Automapper;
using OrderManagementSystem.Application.Interfaces;
using OrderManagementSystem.Application.Service;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Domain.Interfaces;
using OrderManagementSystem.Infrastructure.DataSeed;
using OrderManagementSystem.Infrastructure.Persistence;
using OrderManagementSystem.Infrastructure.Repositories;
using System.Threading.Tasks;
//using Microsoft.OpenApi.Models;

namespace OrderManagementSystem.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region Add Services
            // Add services to the container.
            builder.Services.AddControllers();

            //swagger / openAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

            //configure DbContext
            builder.Services.AddDbContext<OrderManagementDbContext>(
                options => options.UseLazyLoadingProxies()
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //register Identity
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<OrderManagementDbContext>()
                .AddDefaultTokenProviders();

            //add autoMapper
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });


            //Register Data seeders
            builder.Services.AddScoped<RoleSeeder>();

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IProductService, ProductService>();
            #endregion


            var app = builder.Build();
            #region Seed Initial Data
            //create default roles when the application starts

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var roleSeeder = services.GetRequiredService<RoleSeeder>();
                    await roleSeeder.seedRolesAsync();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding roles.");
                }
            }

            #endregion
            //app.MapOpenApi();
            // Configure the HTTP request pipeline.
            Console.WriteLine(app.Environment.EnvironmentName);
            if (app.Environment.IsDevelopment())
            {

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
