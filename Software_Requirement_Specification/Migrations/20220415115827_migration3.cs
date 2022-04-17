using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quyen",
                table: "TaiKhoan");

            migrationBuilder.AddColumn<int>(
                name: "idQuyen",
                table: "TaiKhoan",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idQuyen",
                table: "TaiKhoan");

            migrationBuilder.AddColumn<string>(
                name: "Quyen",
                table: "TaiKhoan",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
