﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    ManufacturerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("c35be0f5-53b5-477c-9bc8-b54c639e6995"), "Apple" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("eeb2bbef-b79b-4581-8192-4e0e317c062a"), "Google" });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Count", "ManufacturerId", "Name" },
                values: new object[] { new Guid("a4cee576-8f90-4dbf-b1b4-9e9761a5976f"), 100, new Guid("eeb2bbef-b79b-4581-8192-4e0e317c062a"), "Pixel 2XL" });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Count", "ManufacturerId", "Name" },
                values: new object[] { new Guid("755d18ca-2cb5-435c-82b8-60c2639f59df"), 100, new Guid("eeb2bbef-b79b-4581-8192-4e0e317c062a"), "Pixel 4" });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Count", "ManufacturerId", "Name" },
                values: new object[] { new Guid("c35be0f5-53b5-477c-9bc8-b54c639e6995"), 100, new Guid("eeb2bbef-b79b-4581-8192-4e0e317c062a"), "Iphone 6" });

            migrationBuilder.CreateIndex(
                name: "IX_Phones_ManufacturerId",
                table: "Phones",
                column: "ManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
