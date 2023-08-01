using EmployeeTax.Models;
using EmployeeTax.Data;
using Microsoft.EntityFrameworkCore;
using EmployeeTax.Service;
//using EmployeeTax.Service.interfaces;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<EmployeeContext>(options =>
        options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection") , new MySqlServerVersion(new Version(8, 0, 28))));
        

        builder.Services.AddControllers();
        builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddScoped<EmployeeService>();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

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