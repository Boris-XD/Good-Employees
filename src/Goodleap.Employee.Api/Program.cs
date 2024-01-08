using Goodleap.Employee.Repository.Models;
using Goodleap.Employee.Repository.Permissions;
using Goodleap.Employee.Repository.Units;
using Goodleap.Employee.Service.Permissions;
using Microsoft.EntityFrameworkCore;

namespace Goodleap.Employee.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            builder.Services
                .AddDbContext<EmployeeDbContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDb")));

            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IPermissionRepository, PermissionRepository>();
            builder.Services.AddTransient<IPermissionService, PermissionService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}