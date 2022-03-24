using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WebApi.Data;

namespace WebApi;

class Programm {
   static void Main(string[] args) {

      var builder = WebApplication.CreateBuilder(args);
      //
      // Add services (dependency injection)
      //
      // Controller
      builder.Services.AddControllers();
      // Database
      var connectionString = 
         @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=WebApi;Integrated Security=True;";
      builder.Services.AddDbContext<CDbContext>(options => 
      options.UseSqlServer(connectionString)
          .LogTo(message => Debug.WriteLine(message), LogLevel.Information)
          .EnableSensitiveDataLogging()
      );
      builder.Services.AddScoped<IRepository, CRepository>();
      var app = builder.Build();
      //
      // Configure request pipeline.
      //
      app.UseAuthorization();
      app.MapControllers();  
      app.Run();
   }
}
