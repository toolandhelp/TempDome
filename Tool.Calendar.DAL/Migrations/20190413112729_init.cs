using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tool.Calendar.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<DateTime>(nullable: false),
                    CreteTime = table.Column<DateTime>(nullable: false),
                    CTName = table.Column<string>(maxLength: 20, nullable: false),
                    CTDescription = table.Column<string>(maxLength: 500, nullable: false),
                    CTLabelClass = table.Column<string>(maxLength: 50, nullable: false),
                    CTSort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
