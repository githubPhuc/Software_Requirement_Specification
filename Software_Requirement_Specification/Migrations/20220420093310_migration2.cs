using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaiLieu_MonHoc_MonHocIDId",
                table: "TaiLieu");

            migrationBuilder.DropIndex(
                name: "IX_TaiLieu_MonHocIDId",
                table: "TaiLieu");

            migrationBuilder.DropColumn(
                name: "MaNguoiDung",
                table: "VaiTro");

            migrationBuilder.DropColumn(
                name: "NguoiDung",
                table: "VaiTro");

            migrationBuilder.DropColumn(
                name: "MonHocIDId",
                table: "TaiLieu");

            migrationBuilder.DropColumn(
                name: "TenMonHoc",
                table: "TaiLieu");

            migrationBuilder.AddColumn<int>(
                name: "monhocId",
                table: "TaiLieu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieu_monhocId",
                table: "TaiLieu",
                column: "monhocId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaiLieu_MonHoc_monhocId",
                table: "TaiLieu",
                column: "monhocId",
                principalTable: "MonHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaiLieu_MonHoc_monhocId",
                table: "TaiLieu");

            migrationBuilder.DropIndex(
                name: "IX_TaiLieu_monhocId",
                table: "TaiLieu");

            migrationBuilder.DropColumn(
                name: "monhocId",
                table: "TaiLieu");

            migrationBuilder.AddColumn<string>(
                name: "MaNguoiDung",
                table: "VaiTro",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiDung",
                table: "VaiTro",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonHocIDId",
                table: "TaiLieu",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenMonHoc",
                table: "TaiLieu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieu_MonHocIDId",
                table: "TaiLieu",
                column: "MonHocIDId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaiLieu_MonHoc_MonHocIDId",
                table: "TaiLieu",
                column: "MonHocIDId",
                principalTable: "MonHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
