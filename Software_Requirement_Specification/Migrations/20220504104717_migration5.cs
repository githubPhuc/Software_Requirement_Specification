using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongBao_VaiTro_vaiTroId",
                table: "ThongBao");

            migrationBuilder.RenameColumn(
                name: "vaiTroId",
                table: "ThongBao",
                newName: "phanQuyenId");

            migrationBuilder.RenameColumn(
                name: "idVaitro",
                table: "ThongBao",
                newName: "idQuyen");

            migrationBuilder.RenameIndex(
                name: "IX_ThongBao_vaiTroId",
                table: "ThongBao",
                newName: "IX_ThongBao_phanQuyenId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBao_PhanQuyen_phanQuyenId",
                table: "ThongBao",
                column: "phanQuyenId",
                principalTable: "PhanQuyen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongBao_PhanQuyen_phanQuyenId",
                table: "ThongBao");

            migrationBuilder.RenameColumn(
                name: "phanQuyenId",
                table: "ThongBao",
                newName: "vaiTroId");

            migrationBuilder.RenameColumn(
                name: "idQuyen",
                table: "ThongBao",
                newName: "idVaitro");

            migrationBuilder.RenameIndex(
                name: "IX_ThongBao_phanQuyenId",
                table: "ThongBao",
                newName: "IX_ThongBao_vaiTroId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBao_VaiTro_vaiTroId",
                table: "ThongBao",
                column: "vaiTroId",
                principalTable: "VaiTro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
