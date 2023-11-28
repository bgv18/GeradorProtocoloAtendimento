using GeradorProtocoloAtendimento.EF;
using GeradorProtocoloAtendimento.Middleware;
using GeradorProtocoloAtendimento.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace GeradorProtocoloAtendimento
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

            builder.Services.AddDbContext<Contexto>(opt =>
                    opt.UseInMemoryDatabase("ProtocoloBD"));
            
            builder.Services.AddScoped<IGerarProtocolo, GerarProtocolo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ErroHandler>();
            
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}