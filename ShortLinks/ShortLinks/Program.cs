using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using ShortLinks.Business;
using ShortLinks.Core;
using ShortLinks.DataBase;

// � �������� ��������� ���������� � �� ���� ����������� �������� �������� � �������������� ������.
// �������� ����������� ������������ �� Microsoft � �� ����� ������ EF Core �� ���� ����������,
// ��� � ����� ������� � ������ �������������.
// ���� ������ ������������, ��������� ����� ���� (� �������� �����������).
// ������ ���������� ����� ����� DbContext.Database.Migrate() (�� �� ����� ���������� �� ������������) ���������� �� ���.
// ���� �� ������������ ������������ � ������������ ����������� �� ������ ����, ���� ����������, ���� ����������.

// ����� � ���� ����, ��� �� ������������ ����� ������������ ��������,
// � ��� ������ ���������� ���������� �� ����� ����������� � ����� �������,
// � ����� �� ������������� Data Access Layer �� ���� ������������ ��� CQRS,
// ���� �������� ����������������� ���������� ������� (��������� ����� ������� ��).

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

