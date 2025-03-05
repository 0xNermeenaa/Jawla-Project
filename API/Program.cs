using Repository.Service;
using Repository.IRepositories;
using Repository.Repository;
using Infrastructure.AutoMapperProfile;
using AppContext = Infrastructure.AppContext;
using AutoMapper;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
namespace APIapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register services here
            builder.Services.AddScoped<ITripService, TripService>();
            builder.Services.AddScoped<ITripRepository, TripRepository>();
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<IDriverRepository, DriverRepository>();
            builder.Services.AddScoped<IDriverService, DriverService>();



            // builder.Services.AddScoped<AppContext, AppContext>();
            builder.Services.AddDbContext<AppContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));




            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


            // Add services to the container
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddAutoMapper(typeof(AutoMapper.Mapper));

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.UseCors(builder =>
                builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.Run();
        }
    }
}
