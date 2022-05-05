using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongBao_LopHoc_LopHocId",
                table: "ThongBao");

            migrationBuilder.DropIndex(
                name: "IX_ThongBao_LopHocId",
                table: "ThongBao");

            migrationBuilder.DropColumn(
                name: "LopHocId",
                table: "ThongBao");

            migrationBuilder.DropColumn(
                name: "Ten",
                table: "BaiGiang");

            migrationBuilder.RenameColumn(
                name: "TheLoai",
                table: "BaiGiang",
                newName: "tenBaiGiang");

            migrationBuilder.RenameColumn(
                name: "KichThuoc",
                table: "BaiGiang",
                newName: "idTep");

            migrationBuilder.AddColumn<int>(
                name: "tepId",
                table: "BaiGiang",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaiGiang_tepId",
                table: "BaiGiang",
                column: "tepId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaiGiang_Tep_tepId",
                table: "BaiGiang",
                column: "tepId",
                principalTable: "Tep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaiGiang_Tep_tepId",
                table: "BaiGiang");

            migrationBuilder.DropIndex(
                name: "IX_BaiGiang_tepId",
                table: "BaiGiang");

            migrationBuilder.DropColumn(
                name: "tepId",
                table: "BaiGiang");

            migrationBuilder.RenameColumn(
                name: "tenBaiGiang",
                table: "BaiGiang",
                newName: "TheLoai");

            migrationBuilder.RenameColumn(
                name: "idTep",
                table: "BaiGiang",
                newName: "KichThuoc");

            migrationBuilder.AddColumn<int>(
                name: "LopHocId",
                table: "ThongBao",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ten",
                table: "BaiGiang",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThongBao_LopHocId",
                table: "ThongBao",
                column: "LopHocId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBao_LopHoc_LopHocId",
                table: "ThongBao",
                column: "LopHocId",
                principalTable: "LopHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
