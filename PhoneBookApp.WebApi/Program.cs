using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBookApp.Application.Interfaces;
using PhoneBookApp.Application.Services;
using PhoneBookApp.Domain.Entities;
using PhoneBookApp.Infrastructure.Repositories;
using System.Collections.Generic;

namespace PhoneBookApp.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IPhoneBookRepository>(serviceProvider =>
            {
                var phoneBookEntries = new List<PhoneBookEntry>
                {
                    new PhoneBookEntry("Tessália", "(66) 99355-9466"),
                    new PhoneBookEntry("Nádia", "(35) 97424-5558"),
                    new PhoneBookEntry("Isabel", "(85) 91254-2065"),
                    new PhoneBookEntry("Joaquin", "(44) 96700-4381 "),
                    new PhoneBookEntry("Camilo", "(54) 91112-9587 "),
                    new PhoneBookEntry("Vicente", "(61) 90511-2116")
                    
                };

                return new PhoneBookRepository(phoneBookEntries);
            });

            builder.Services.AddScoped<IPhoneBookService, PhoneBookService>();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors(options =>
            {
                options.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
