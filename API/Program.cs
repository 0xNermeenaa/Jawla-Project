using Repository.Service;
using Repository.IRepositories;
using Repository.Repository;
using Infrastructure.AutoMapperProfile;
using AppContext = Infrastructure.AppContext;
using AutoMapper;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;

namespace APIapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            //builder.Services.AddDbContext<AppContext>(options =>
               // options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            
           // builder.Services.AddIdentity<User, IdentityRole>()
             //   .AddEntityFrameworkStores<AppContext>()
             //   .AddDefaultTokenProviders();

            // Register application services
            builder.Services.AddScoped<ITripService, TripService>();
            builder.Services.AddScoped<ITripRepository, TripRepository>();
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<IDriverRepository, DriverRepository>();
            builder.Services.AddScoped<IDriverService, DriverService>();
            builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();

            builder.Services.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<AppContext>().AddDefaultTokenProviders();

            

            // builder.Services.AddScoped<AppContext, AppContext>();
            builder.Services.AddDbContext<AppContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



            builder.Services.AddScoped<ITourguideRepository, TourguideRepository>();
            builder.Services.AddScoped<ITourguideService, TourguideService>();
            // Add services to the container.
            builder.Services.AddScoped<IHelpIssueRepository, HelpIssueRepository>();
            builder.Services.AddScoped<IHelpIssueService, HelpIssueService>();

            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            builder.Services.Configure<CloudinarySettings>(
                builder.Configuration.GetSection("CloudinarySettings"));
            builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();

            // Add controllers and Swagger
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
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

            app.UseCors(corsBuilder =>
                corsBuilder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());

            app.Run();
        }
    }
}
