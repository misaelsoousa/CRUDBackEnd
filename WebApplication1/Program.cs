using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;

namespace WebApplication1
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

            //  CONEXÃO DO BANCO AQUI
            builder.Services.AddDbContext<ConteinerContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("Database"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors(option => { option.AllowAnyOrigin(); option.AllowAnyHeader(); option.AllowAnyMethod(); });


            app.MapControllers();

            app.Run();
        }
    }
}