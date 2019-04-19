using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tool.Calendar.Repository.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_ConsumptionTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ConsumptionTypeGuid = table.Column<byte[]>(nullable: false),
                    ConsumptionTypeName = table.Column<string>(nullable: true),
                    ConsumptionTypeCreateDate = table.Column<DateTime>(nullable: false),
                    ConsumptionTypeClass = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_ConsumptionTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "t_WebUser",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    UserGuid = table.Column<byte[]>(nullable: false),
                    UserMail = table.Column<string>(nullable: true),
                    UserPwd = table.Column<string>(nullable: true),
                    EncryptCode = table.Column<string>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_WebUser", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_ConsumptionTypes");

            migrationBuilder.DropTable(
                name: "t_WebUser");
        }
    }
}
