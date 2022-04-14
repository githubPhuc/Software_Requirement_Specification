using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaiTro_PhanQuyen_PhanQuyenId",
                table: "VaiTro");

            migrationBuilder.RenameColumn(
                name: "PhanQuyenId",
                table: "VaiTro",
                newName: "taiKhoanId");

            migrationBuilder.RenameIndex(
                name: "IX_VaiTro_PhanQuyenId",
                table: "VaiTro",
                newName: "IX_VaiTro_taiKhoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaiTro_TaiKhoan_taiKhoanId",
                table: "VaiTro",
                column: "taiKhoanId",
                principalTable: "TaiKhoan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaiTro_TaiKhoan_taiKhoanId",
                table: "VaiTro");

            migrationBuilder.RenameColumn(
                name: "taiKhoanId",
                table: "VaiTro",
                newName: "PhanQuyenId");

            migrationBuilder.RenameIndex(
                name: "IX_VaiTro_taiKhoanId",
                table: "VaiTro",
                newName: "IX_VaiTro_PhanQuyenId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaiTro_PhanQuyen_PhanQuyenId",
                table: "VaiTro",
                column: "PhanQuyenId",
                principalTable: "PhanQuyen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
