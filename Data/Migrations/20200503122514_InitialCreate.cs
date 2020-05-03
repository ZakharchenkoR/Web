using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    CountryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufacturers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ManufacturerId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("ef87c39b-2cc6-407e-b974-edbcf20781ad"), "China" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("cc61583f-4ebd-4b68-8e41-b56822aec84e"), "USA" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("fb13009a-e4d3-4770-8c77-957e78b61802"), "South Korea" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("f639ccdd-39d5-40b5-98af-d07211f7b61a"), new Guid("ef87c39b-2cc6-407e-b974-edbcf20781ad"), "Xiaomi" },
                    { new Guid("1bea5a7c-03ca-40a4-aad4-7911b69b39fd"), new Guid("ef87c39b-2cc6-407e-b974-edbcf20781ad"), "Huawei" },
                    { new Guid("62d760f0-648a-4ee0-9923-b63effd17b5b"), new Guid("cc61583f-4ebd-4b68-8e41-b56822aec84e"), "Iphone" },
                    { new Guid("e8b5a606-0b3a-4a16-b15d-c6855d91a4ef"), new Guid("cc61583f-4ebd-4b68-8e41-b56822aec84e"), "Google" },
                    { new Guid("b12dabf7-4845-4788-b55e-b0d7e3d673fb"), new Guid("fb13009a-e4d3-4770-8c77-957e78b61802"), "Samsung" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "Count", "ManufacturerId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("cebee680-2ebf-4620-8a84-5e40e3b516ec"), 1000, new Guid("f639ccdd-39d5-40b5-98af-d07211f7b61a"), "Mi 9", 9000m },
                    { new Guid("366d57df-9f01-4ccf-a46f-fbaf0aa7d07d"), 1000, new Guid("f639ccdd-39d5-40b5-98af-d07211f7b61a"), "Mi 10", 25000m },
                    { new Guid("0b97a35a-d8b7-4704-925a-27cd8a3803a5"), 1000, new Guid("1bea5a7c-03ca-40a4-aad4-7911b69b39fd"), "P40 Pro", 28000m },
                    { new Guid("436b8fe4-69dc-4d84-a30f-1696e4a18f4f"), 1000, new Guid("62d760f0-648a-4ee0-9923-b63effd17b5b"), "6", 3500m },
                    { new Guid("d241ba3b-cb36-4415-829a-451232f78cd1"), 1000, new Guid("62d760f0-648a-4ee0-9923-b63effd17b5b"), "6S", 4500m },
                    { new Guid("2380b3b0-a3e6-46bf-adf7-a8451c62ac15"), 1000, new Guid("62d760f0-648a-4ee0-9923-b63effd17b5b"), "8", 8000m },
                    { new Guid("74ef6172-5389-4470-aea4-b40beb27301f"), 1000, new Guid("62d760f0-648a-4ee0-9923-b63effd17b5b"), "X", 14000m },
                    { new Guid("a85fbe94-7462-4690-ba65-921cc2b7f4e8"), 100, new Guid("e8b5a606-0b3a-4a16-b15d-c6855d91a4ef"), "Pixel 2XL", 8200m },
                    { new Guid("42be4c1c-d92e-4a54-8103-45b57077b44c"), 1000, new Guid("e8b5a606-0b3a-4a16-b15d-c6855d91a4ef"), "Pixel 3XL", 14500m },
                    { new Guid("e813c617-6724-4bd1-bb36-e9c32b71e7fb"), 1000, new Guid("e8b5a606-0b3a-4a16-b15d-c6855d91a4ef"), "Pixel 4", 15500m },
                    { new Guid("3a5558b7-3f4a-492e-b6fe-5d28c9099b35"), 1000, new Guid("e8b5a606-0b3a-4a16-b15d-c6855d91a4ef"), "Pixel 4XL", 17500m },
                    { new Guid("92d01c5c-5056-49db-a323-a65b1de1b218"), 1000, new Guid("b12dabf7-4845-4788-b55e-b0d7e3d673fb"), "P20 Pro", 32000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_CountryId",
                table: "Manufacturers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_ManufacturerId",
                table: "Models",
                column: "ManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
