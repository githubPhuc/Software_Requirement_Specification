using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongBao_NguoiDung_NguoiDungId",
                table: "ThongBao");

            migrationBuilder.DropIndex(
                name: "IX_ThongBao_NguoiDungId",
                table: "ThongBao");

            migrationBuilder.RenameColumn(
                name: "NguoiDungId",
                table: "ThongBao",
                newName: "idVaitro");

            migrationBuilder.AddColumn<int>(
                name: "vaiTroId",
                table: "ThongBao",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThongBao_vaiTroId",
                table: "ThongBao",
                column: "vaiTroId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBao_VaiTro_vaiTroId",
                table: "ThongBao",
                column: "vaiTroId",
                principalTable: "VaiTro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongBao_VaiTro_vaiTroId",
                table: "ThongBao");

            migrationBuilder.DropIndex(
                name: "IX_ThongBao_vaiTroId",
                table: "ThongBao");

            migrationBuilder.DropColumn(
                name: "vaiTroId",
                table: "ThongBao");

            migrationBuilder.RenameColumn(
                name: "idVaitro",
                table: "ThongBao",
                newName: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBao_NguoiDungId",
                table: "ThongBao",
                column: "NguoiDungId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBao_NguoiDung_NguoiDungId",
                table: "ThongBao",
                column: "NguoiDungId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
