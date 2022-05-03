using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cauhoidapan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idDeThi = table.Column<int>(type: "int", nullable: false),
                    deThiId = table.Column<int>(type: "int", nullable: true),
                    cauHoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dapAnA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dapAnB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dapAnC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dapAnD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dapAn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trangthai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cauhoidapan", x => x.id);
                    table.ForeignKey(
                        name: "FK_cauhoidapan_DeThi_deThiId",
                        column: x => x.deThiId,
                        principalTable: "DeThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cauhoidapan_deThiId",
                table: "cauhoidapan",
                column: "deThiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cauhoidapan");
        }
    }
}
