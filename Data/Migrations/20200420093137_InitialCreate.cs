using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NormalizedName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TitleImagePath = table.Column<string>(nullable: true),
                    MetaTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Keywords = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Subtitle = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TextFields",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Subtitle = table.Column<string>(nullable: true),
                    TitleImagePath = table.Column<string>(nullable: true),
                    MetaTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Keywords = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    CodeWord = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextFields", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "Name", "NormalizedName" },
                values: new object[] { new Guid("389447a5-6944-410a-8963-d966b1164fa2"), "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("c2487303-39dc-4b9b-9437-811ce2656edb"), new Guid("389447a5-6944-410a-8963-d966b1164fa2"), new Guid("d84014c0-b6db-4d6c-899d-5678d6df922a") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Email", "EmailConfirmed", "Name", "NormalizedEmail", "NormalizedName", "PasswordHash" },
                values: new object[] { new Guid("d84014c0-b6db-4d6c-899d-5678d6df922a"), "superzaec22@gmail.com", true, "admin", "SUPERZAEC22@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEMswgw5tZFanxZFP3Eooh1cyYHFt6ZGgIjqm5zx5+E27WenwRx6dYxcb//uMya2qrQ==" });

            migrationBuilder.InsertData(
                table: "TextFields",
                columns: new[] { "Id", "CodeWord", "DateAdded", "Description", "Keywords", "MetaTitle", "Subtitle", "Text", "Title", "TitleImagePath" },
                values: new object[,]
                {
                    { new Guid("b1fc43ca-5742-4283-87fb-474ff1c06128"), "PageIndex", new DateTime(2020, 4, 20, 9, 31, 36, 419, DateTimeKind.Utc).AddTicks(5947), null, null, null, null, "Содержание заполняется администратором", "Главная", null },
                    { new Guid("091a9051-3f71-4782-b1d1-c8da75e6629a"), "PageServices", new DateTime(2020, 4, 20, 9, 31, 36, 419, DateTimeKind.Utc).AddTicks(8049), null, null, null, null, "Содержание заполняется администратором", "Наши услуги", null },
                    { new Guid("ebc491bb-ff1a-4c77-acf4-d49358802e6d"), "PageContacts", new DateTime(2020, 4, 20, 9, 31, 36, 419, DateTimeKind.Utc).AddTicks(8114), null, null, null, null, "Содержание заполняется администратором", "Контакты", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "ServiceItems");

            migrationBuilder.DropTable(
                name: "TextFields");
        }
    }
}
