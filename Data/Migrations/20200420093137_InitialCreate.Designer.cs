﻿// <auto-generated />
using System;
using Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200420093137_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Domain.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("389447a5-6944-410a-8963-d966b1164fa2"),
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Data.Domain.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d84014c0-b6db-4d6c-899d-5678d6df922a"),
                            Email = "superzaec22@gmail.com",
                            EmailConfirmed = true,
                            Name = "admin",
                            NormalizedEmail = "SUPERZAEC22@GMAIL.COM",
                            NormalizedName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEMswgw5tZFanxZFP3Eooh1cyYHFt6ZGgIjqm5zx5+E27WenwRx6dYxcb//uMya2qrQ=="
                        });
                });

            modelBuilder.Entity("Data.Domain.Entities.AppUserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppUserRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c2487303-39dc-4b9b-9437-811ce2656edb"),
                            RoleId = new Guid("389447a5-6944-410a-8963-d966b1164fa2"),
                            UserId = new Guid("d84014c0-b6db-4d6c-899d-5678d6df922a")
                        });
                });

            modelBuilder.Entity("Data.Domain.Entities.ServiceItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subtitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ServiceItems");
                });

            modelBuilder.Entity("Data.Domain.Entities.TextField", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodeWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subtitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TextFields");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b1fc43ca-5742-4283-87fb-474ff1c06128"),
                            CodeWord = "PageIndex",
                            DateAdded = new DateTime(2020, 4, 20, 9, 31, 36, 419, DateTimeKind.Utc).AddTicks(5947),
                            Text = "Содержание заполняется администратором",
                            Title = "Главная"
                        },
                        new
                        {
                            Id = new Guid("091a9051-3f71-4782-b1d1-c8da75e6629a"),
                            CodeWord = "PageServices",
                            DateAdded = new DateTime(2020, 4, 20, 9, 31, 36, 419, DateTimeKind.Utc).AddTicks(8049),
                            Text = "Содержание заполняется администратором",
                            Title = "Наши услуги"
                        },
                        new
                        {
                            Id = new Guid("ebc491bb-ff1a-4c77-acf4-d49358802e6d"),
                            CodeWord = "PageContacts",
                            DateAdded = new DateTime(2020, 4, 20, 9, 31, 36, 419, DateTimeKind.Utc).AddTicks(8114),
                            Text = "Содержание заполняется администратором",
                            Title = "Контакты"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}