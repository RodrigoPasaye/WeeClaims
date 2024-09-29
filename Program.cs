
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WeeClaims.AutoMappers;
using WeeClaims.Context;
using WeeClaims.DTO;
using WeeClaims.Models;
using WeeClaims.Repository;
using WeeClaims.Services;
using WeeClaims.Validators;

namespace WeeClaims {
  public class Program {
    public static void Main(string[] args) {
      var builder = WebApplication.CreateBuilder(args);

      builder.Services.AddKeyedScoped<ICommonService<CustomerDto, CustomerInsertDto>, CustomerService>("customerService");

      //Repository
      builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();

      //Entity Framework
      builder.Services.AddDbContext<WeeClaimsContext>(options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("WeeClaimsConnection"));
      });

      //Validators
      builder.Services.AddScoped<IValidator<CustomerInsertDto>, CustomerInsertValidator>();

      //Mappers
      builder.Services.AddAutoMapper(typeof(MappingProfile));

      builder.Services.AddControllers();
      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      //Soporte para CORS
      builder.Services.AddCors(p => p.AddPolicy("PolicyCors", build => {
        build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
      }));

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment()) {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      //Se agregan CORS
      app.UseCors("PolicyCors");

      app.UseAuthorization();


      app.MapControllers();

      app.Run();
    }
  }
}
