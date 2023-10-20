using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SingleGetQuery.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class InitDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2ca01988-ad74-4da0-8f42-b7fa503c7154"), "Technique" },
                    { new Guid("e13ebfde-1840-4d0f-a942-50da4cf12e4c"), "Food" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("19dd1d6c-8179-4278-aa2f-e122f5a58a79"), new Guid("e13ebfde-1840-4d0f-a942-50da4cf12e4c"), "Carrot", 9 },
                    { new Guid("25c2ebc4-58cf-4bba-9f1d-b686038b0a65"), new Guid("2ca01988-ad74-4da0-8f42-b7fa503c7154"), "Laptop", 2500 },
                    { new Guid("35975aa3-3cb8-460f-bfd4-8f0ce369a29f"), new Guid("e13ebfde-1840-4d0f-a942-50da4cf12e4c"), "Orange", 45 },
                    { new Guid("4720599b-6f11-4ab6-9815-c53e35f53630"), new Guid("2ca01988-ad74-4da0-8f42-b7fa503c7154"), "Phone", 1500 },
                    { new Guid("7e07e7a6-6fdc-4d33-a4f1-94d2121848d3"), new Guid("2ca01988-ad74-4da0-8f42-b7fa503c7154"), "TV", 2100 },
                    { new Guid("94d096c0-5067-4b0a-b7bd-ce4b797f00e8"), new Guid("2ca01988-ad74-4da0-8f42-b7fa503c7154"), "PlayStation", 2000 },
                    { new Guid("9d661f79-f041-4a49-83e1-e150d2df0300"), new Guid("e13ebfde-1840-4d0f-a942-50da4cf12e4c"), "Apple", 10 },
                    { new Guid("cd71f887-7a3a-442e-8392-6eaa1f096254"), new Guid("e13ebfde-1840-4d0f-a942-50da4cf12e4c"), "Lemon", 30 },
                    { new Guid("d0a0a04b-cb86-4461-a3d3-3e5341f96236"), new Guid("e13ebfde-1840-4d0f-a942-50da4cf12e4c"), "Mango", 40 },
                    { new Guid("ebf22ab2-0fb7-4ea2-8527-dcf14a98ae86"), new Guid("2ca01988-ad74-4da0-8f42-b7fa503c7154"), "Xbox", 1700 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
