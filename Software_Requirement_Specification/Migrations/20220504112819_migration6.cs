using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongBao_LoaiLopHoc_LoaiLopHocId",
                table: "ThongBao");

            migrationBuilder.DropIndex(
                name: "IX_ThongBao_LoaiLopHocId",
                table: "ThongBao");

            migrationBuilder.DropColumn(
                name: "LoaiLopHocId",
                table: "ThongBao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoaiLopHocId",
                table: "ThongBao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ThongBao_LoaiLopHocId",
                table: "ThongBao",
                column: "LoaiLopHocId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBao_LoaiLopHoc_LoaiLopHocId",
                table: "ThongBao",
                column: "LoaiLopHocId",
                principalTable: "LoaiLopHoc",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
