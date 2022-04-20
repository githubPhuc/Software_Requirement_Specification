using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "maNguoiDung",
                table: "MonHoc");

            migrationBuilder.AddColumn<int>(
                name: "nguoiDungId",
                table: "MonHoc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_nguoiDungId",
                table: "MonHoc",
                column: "nguoiDungId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonHoc_NguoiDung_nguoiDungId",
                table: "MonHoc",
                column: "nguoiDungId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonHoc_NguoiDung_nguoiDungId",
                table: "MonHoc");

            migrationBuilder.DropIndex(
                name: "IX_MonHoc_nguoiDungId",
                table: "MonHoc");

            migrationBuilder.DropColumn(
                name: "nguoiDungId",
                table: "MonHoc");

            migrationBuilder.AddColumn<string>(
                name: "maNguoiDung",
                table: "MonHoc",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
