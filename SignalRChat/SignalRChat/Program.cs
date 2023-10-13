using Microsoft.EntityFrameworkCore;
using SignalRChat.Business.Hubs;
using SignalRChat.Business.ServicesImplementation;
using SignalRChat.Core.Abstractions;
using SignalRChat.Data.Abstractions;
using SignalRChat.Data.Repositories;
using SignalRChat.DataBase;
using SignalRChat.DataBase.Entities;

namespace SignalRChat
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionString = builder.Configuration.GetConnectionString("Default");

            builder.Services.AddDbContext<SignalRChatDbContext>(
                            optionBuilder => optionBuilder.UseSqlServer(connectionString));

            builder.Services.AddControllers();

            builder.Services.AddSignalR();

            builder.Services.AddTransient<IUserService, UserService>();

            builder.Services.AddScoped<IRepository<User>, Repository<User>>();
            builder.Services.AddScoped<IRepository<Chat>, Repository<Chat>>();
            builder.Services.AddScoped<IRepository<UserChat>, Repository<UserChat>>();
            builder.Services.AddScoped<IRepository<Message>, Repository<Message>>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapHub<ChatHub>("/chatHub");

            app.MapControllers();

            app.Run();
        }
    }
}