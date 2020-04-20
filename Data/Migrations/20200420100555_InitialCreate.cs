using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    AppUserId = table.Column<Guid>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: false),
                    AppRoleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NormalizedName = table.Column<string>(nullable: true),
                    AppUserRoleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRoles_AppUserRoles_AppUserRoleId",
                        column: x => x.AppUserRoleId,
                        principalTable: "AppUserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    PasswordHash = table.Column<string>(nullable: true),
                    AppUserRoleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUsers_AppUserRoles_AppUserRoleId",
                        column: x => x.AppUserRoleId,
                        principalTable: "AppUserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "AppUserRoleId", "Name", "NormalizedName" },
                values: new object[] { new Guid("389447a5-6944-410a-8963-d966b1164fa2"), null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "Id", "AppRoleId", "AppUserId", "RoleId", "UserId" },
                values: new object[] { new Guid("c2487303-39dc-4b9b-9437-811ce2656edb"), null, null, new Guid("389447a5-6944-410a-8963-d966b1164fa2"), new Guid("d84014c0-b6db-4d6c-899d-5678d6df922a") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AppUserRoleId", "Email", "EmailConfirmed", "Name", "NormalizedEmail", "NormalizedName", "PasswordHash" },
                values: new object[] { new Guid("d84014c0-b6db-4d6c-899d-5678d6df922a"), null, "superzaec22@gmail.com", true, "admin", "SUPERZAEC22@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAELVFWCCkxY8CdfOMCQSqMdPZ3OUxJbVwgvO/e1L4yOZJSgglnONxofTji3kyiWMcJg==" });

            migrationBuilder.InsertData(
                table: "TextFields",
                columns: new[] { "Id", "CodeWord", "DateAdded", "Description", "Keywords", "MetaTitle", "Subtitle", "Text", "Title", "TitleImagePath" },
                values: new object[,]
                {
                    { new Guid("b1fc43ca-5742-4283-87fb-474ff1c06128"), "PageIndex", new DateTime(2020, 4, 20, 10, 5, 54, 551, DateTimeKind.Utc).AddTicks(6150), null, null, null, null, "Содержание заполняется администратором", "Главная", null },
                    { new Guid("091a9051-3f71-4782-b1d1-c8da75e6629a"), "PageServices", new DateTime(2020, 4, 20, 10, 5, 54, 551, DateTimeKind.Utc).AddTicks(9541), null, null, null, null, "Содержание заполняется администратором", "Наши услуги", null },
                    { new Guid("ebc491bb-ff1a-4c77-acf4-d49358802e6d"), "PageContacts", new DateTime(2020, 4, 20, 10, 5, 54, 551, DateTimeKind.Utc).AddTicks(9657), null, null, null, null, "Содержание заполняется администратором", "Контакты", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppRoles_AppUserRoleId",
                table: "AppRoles",
                column: "AppUserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_AppRoleId",
                table: "AppUserRoles",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_AppUserId",
                table: "AppUserRoles",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_AppUserRoleId",
                table: "AppUsers",
                column: "AppUserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserRoles_AppRoles_AppRoleId",
                table: "AppUserRoles",
                column: "AppRoleId",
                principalTable: "AppRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserRoles_AppUsers_AppUserId",
                table: "AppUserRoles",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppRoles_AppUserRoles_AppUserRoleId",
                table: "AppRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppUserRoles_AppUserRoleId",
                table: "AppUsers");

            migrationBuilder.DropTable(
                name: "ServiceItems");

            migrationBuilder.DropTable(
                name: "TextFields");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
