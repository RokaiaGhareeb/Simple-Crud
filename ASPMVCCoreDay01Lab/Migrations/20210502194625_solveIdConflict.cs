using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPMVCCoreDay01Lab.Migrations
{
    public partial class solveIdConflict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Departments",
                newName: "DeptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeptId",
                table: "Departments",
                newName: "Id");
        }
    }
}
