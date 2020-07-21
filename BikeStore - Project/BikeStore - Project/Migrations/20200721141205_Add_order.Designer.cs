﻿// <auto-generated />
using System;
using BikeStore___Project.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BikeStore___Project.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200721141205_Add_order")]
    partial class Add_order
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BikeStore___Project.Domain.Models.Accessory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("AccessoryType")
                        .HasColumnType("tinyint");

                    b.Property<int>("BikeId")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BikeId");

                    b.ToTable("Accessories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessoryType = (byte)6,
                            BikeId = 1,
                            Brand = "Shimano",
                            Name = "Altus",
                            Weight = 100
                        },
                        new
                        {
                            Id = 2,
                            AccessoryType = (byte)2,
                            BikeId = 2,
                            Brand = "Kring",
                            Name = "Lighting",
                            Weight = 10
                        },
                        new
                        {
                            Id = 3,
                            AccessoryType = (byte)1,
                            BikeId = 2,
                            Brand = "Smith",
                            Name = "Ringer",
                            Weight = 15
                        });
                });

            modelBuilder.Entity("BikeStore___Project.Domain.Models.Bike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BikeOwnerId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("FrameSize")
                        .HasColumnType("tinyint");

                    b.Property<byte>("FrameType")
                        .HasColumnType("tinyint");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BikeOwnerId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ShopId");

                    b.ToTable("Bikes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BikeOwnerId = 2,
                            CategoryId = 1,
                            Color = "Red",
                            FrameSize = (byte)3,
                            FrameType = (byte)1
                        },
                        new
                        {
                            Id = 2,
                            BikeOwnerId = 2,
                            CategoryId = 2,
                            Color = "Yellow",
                            FrameSize = (byte)3,
                            FrameType = (byte)4
                        },
                        new
                        {
                            Id = 3,
                            BikeOwnerId = 3,
                            CategoryId = 3,
                            Color = "Gray",
                            FrameSize = (byte)3,
                            FrameType = (byte)2
                        });
                });

            modelBuilder.Entity("BikeStore___Project.Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Road Bike"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mountain Bike"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Touring Bike"
                        });
                });

            modelBuilder.Entity("BikeStore___Project.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BikeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("ShopId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BikeId = 2,
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShopId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("BikeStore___Project.Domain.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Shops");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Mihai Eminescu 23",
                            Name = "Vello Express"
                        });
                });

            modelBuilder.Entity("BikeStore___Project.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<byte>("Role")
                        .HasColumnType("tinyint");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "mike@mail.com",
                            FirstName = "Mike",
                            Gender = (byte)1,
                            LastName = "Ekim",
                            Password = "very_strong_pass",
                            Role = (byte)2,
                            Username = "mike.ekim"
                        },
                        new
                        {
                            Id = 2,
                            Email = "sally@mail.com",
                            FirstName = "Sally",
                            Gender = (byte)2,
                            LastName = "Harry",
                            Password = "very_strong_pass",
                            Role = (byte)1,
                            Username = "sally.harry"
                        },
                        new
                        {
                            Id = 3,
                            Email = "harry@mail.com",
                            FirstName = "Harry",
                            Gender = (byte)1,
                            LastName = "Sally",
                            Password = "very_strong_pass",
                            Role = (byte)1,
                            Username = "harry.sally"
                        });
                });

            modelBuilder.Entity("BikeStore___Project.Domain.Models.Accessory", b =>
                {
                    b.HasOne("BikeStore___Project.Domain.Models.Bike", "Bike")
                        .WithMany("Accessories")
                        .HasForeignKey("BikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BikeStore___Project.Domain.Models.Bike", b =>
                {
                    b.HasOne("BikeStore___Project.Domain.Models.User", "BikeOwner")
                        .WithMany("Bikes")
                        .HasForeignKey("BikeOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeStore___Project.Domain.Models.Category", "Category")
                        .WithMany("Bikes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeStore___Project.Domain.Models.Shop", null)
                        .WithMany("Bikes")
                        .HasForeignKey("ShopId");
                });

            modelBuilder.Entity("BikeStore___Project.Domain.Models.User", b =>
                {
                    b.HasOne("BikeStore___Project.Domain.Models.Shop", null)
                        .WithMany("Users")
                        .HasForeignKey("ShopId");
                });
#pragma warning restore 612, 618
        }
    }
}
