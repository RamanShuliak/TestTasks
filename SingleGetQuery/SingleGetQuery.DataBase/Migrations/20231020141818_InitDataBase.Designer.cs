﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SingleGetQuery.DataBase;

#nullable disable

namespace SingleGetQuery.DataBase.Migrations
{
    [DbContext(typeof(SingleGetQueryDbContext))]
    [Migration("20231020141818_InitDataBase")]
    partial class InitDataBase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SingleGetQuery.DataBase.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e13ebfde-1840-4d0f-a942-50da4cf12e4c"),
                            Name = "Food"
                        },
                        new
                        {
                            Id = new Guid("2ca01988-ad74-4da0-8f42-b7fa503c7154"),
                            Name = "Technique"
                        });
                });

            modelBuilder.Entity("SingleGetQuery.DataBase.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9d661f79-f041-4a49-83e1-e150d2df0300"),
                            CategoryId = new Guid("e13ebfde-1840-4d0f-a942-50da4cf12e4c"),
                            Name = "Apple",
                            Price = 10
                        },
                        new
                        {
                            Id = new Guid("cd71f887-7a3a-442e-8392-6eaa1f096254"),
                            CategoryId = new Guid("e13ebfde-1840-4d0f-a942-50da4cf12e4c"),
                            Name = "Lemon",
                            Price = 30
                        },
                        new
                        {
                            Id = new Guid("19dd1d6c-8179-4278-aa2f-e122f5a58a79"),
                            CategoryId = new Guid("e13ebfde-1840-4d0f-a942-50da4cf12e4c"),
                            Name = "Carrot",
                            Price = 9
                        },
                        new
                        {
                            Id = new Guid("d0a0a04b-cb86-4461-a3d3-3e5341f96236"),
                            CategoryId = new Guid("e13ebfde-1840-4d0f-a942-50da4cf12e4c"),
                            Name = "Mango",
                            Price = 40
                        },
                        new
                        {
                            Id = new Guid("35975aa3-3cb8-460f-bfd4-8f0ce369a29f"),
                            CategoryId = new Guid("e13ebfde-1840-4d0f-a942-50da4cf12e4c"),
                            Name = "Orange",
                            Price = 45
                        },
                        new
                        {
                            Id = new Guid("4720599b-6f11-4ab6-9815-c53e35f53630"),
                            CategoryId = new Guid("2ca01988-ad74-4da0-8f42-b7fa503c7154"),
                            Name = "Phone",
                            Price = 1500
                        },
                        new
                        {
                            Id = new Guid("25c2ebc4-58cf-4bba-9f1d-b686038b0a65"),
                            CategoryId = new Guid("2ca01988-ad74-4da0-8f42-b7fa503c7154"),
                            Name = "Laptop",
                            Price = 2500
                        },
                        new
                        {
                            Id = new Guid("ebf22ab2-0fb7-4ea2-8527-dcf14a98ae86"),
                            CategoryId = new Guid("2ca01988-ad74-4da0-8f42-b7fa503c7154"),
                            Name = "Xbox",
                            Price = 1700
                        },
                        new
                        {
                            Id = new Guid("94d096c0-5067-4b0a-b7bd-ce4b797f00e8"),
                            CategoryId = new Guid("2ca01988-ad74-4da0-8f42-b7fa503c7154"),
                            Name = "PlayStation",
                            Price = 2000
                        },
                        new
                        {
                            Id = new Guid("7e07e7a6-6fdc-4d33-a4f1-94d2121848d3"),
                            CategoryId = new Guid("2ca01988-ad74-4da0-8f42-b7fa503c7154"),
                            Name = "TV",
                            Price = 2100
                        });
                });

            modelBuilder.Entity("SingleGetQuery.DataBase.Entities.Product", b =>
                {
                    b.HasOne("SingleGetQuery.DataBase.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SingleGetQuery.DataBase.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}