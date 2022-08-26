using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFConsoleTutorial.Migrations
{
    public partial class RemovedCourseIdFromStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
