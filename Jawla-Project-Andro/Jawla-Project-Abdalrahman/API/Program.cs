using Repository.Service;
using Repository.IRepositories;
using Repository.Repository;
using Infrastructure.AutoMapperProfile;
using AppContext = Infrastructure.AppContext;
using AutoMapper;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
namespace APIapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register services here
            builder.Services.AddScoped<Repository.Service.TripService>();
            builder.Services.AddScoped<TripService>();
            builder.Services.AddScoped<ITripRepository, TripRepository>();
            builder.Services.AddScoped<AppContext, AppContext>();
            builder.Services.AddDbContext<AppContext>(op =>
       op.UseSqlServer(builder.Configuration.GetConnectionString("myCon")));
            builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppContext>().AddDefaultTokenProviders();
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
