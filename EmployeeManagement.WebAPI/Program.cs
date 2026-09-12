using Entities.WebAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceContracts.WebAPI;
using Services.WebAPI;

namespace EmployeeManagement.WebAPI;

public class Program
{
    /// <summary>
    /// This is the static Main method in Program.cs file
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers(options =>
        {
            //Added in swagger to force only appli/json formate
            options.Filters.Add(new ProducesAttribute("application/json"));
            options.Filters.Add(new ConsumesAttribute("application/json"));
        });

        builder.Services.AddOpenApi();
        builder.Services.AddDbContext<ApplicationDBContext>(
            options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            }
            );
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();

        //swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "api.xml"));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if(app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        //Swagger 
        app.UseSwagger(); //use swagger.json
        app.UseSwaggerUI(); //enable swagger ui

        app.UseHttpsRedirection();
        app.UseAuthorization();

        //map controllers routes
        app.MapControllers();
        app.Run();
    }
}
