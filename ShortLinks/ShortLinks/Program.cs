using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using ShortLinks.Business;
using ShortLinks.Core;
using ShortLinks.DataBase;

// В процессе написания приложения я не смог реализовать создание миграций в автоматическом режиме.
// Изучение официальной документации от Microsoft и на сайте самого EF Core не дало результата,
// как и поиск ответов у других пользователей.
// Тема крайне непопулярная, материала очень мало (в основном устаревшего).
// Способ реализации через метод DbContext.Database.Migrate() (он же самый актуальный по документации) результата не дал.
// Если вы располагаете полноценными и современными туториалами по данной теме, буду благодарен, если поделитесь.

namespace ShortLinks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(connectionString));

            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient<ILinkService, LinkService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Link}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

