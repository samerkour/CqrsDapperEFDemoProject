using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Salary.Infrastructure.Migrations
{
    public partial class initialsqlmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeSalarys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false),

                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    BaseSalary = table.Column<string>(type: "INTEGER", nullable: false),
                    Allowance = table.Column<string>(type: "INTEGER", nullable: false),
                    Transportation = table.Column<string>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OverTimeCalculator = table.Column<string>(type: "TEXT", nullable: false),
                    TotalSalary = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalarys", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSalarys");
        }
    }
}
