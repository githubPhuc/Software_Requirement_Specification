using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhanQuyen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanQuyen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TruongHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTruong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idThuVien = table.Column<int>(type: "int", nullable: false),
                    HieuTruong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruongHoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNguoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idQuyen = table.Column<int>(type: "int", nullable: false),
                    QuyenIDId = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiKhoan_PhanQuyen_QuyenIDId",
                        column: x => x.QuyenIDId,
                        principalTable: "PhanQuyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NienKhoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idtruong = table.Column<int>(type: "int", nullable: false),
                    TruongIDId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LopHoc_TruongHoc_TruongIDId",
                        column: x => x.TruongIDId,
                        principalTable: "TruongHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThuVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TruongHocId = table.Column<int>(type: "int", nullable: false),
                    TenHeThong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChiTruyCap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgonNguXacDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NienKhoaMacDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThuVien_TruongHoc_TruongHocId",
                        column: x => x.TruongHocId,
                        principalTable: "TruongHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaiTro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNguoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenVaiTro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idQuyen = table.Column<int>(type: "int", nullable: false),
                    ThongBao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phanQuyenId = table.Column<int>(type: "int", nullable: true),
                    TaiKhoanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaiTro_PhanQuyen_phanQuyenId",
                        column: x => x.phanQuyenId,
                        principalTable: "PhanQuyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VaiTro_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maNguoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idLopHoc = table.Column<int>(type: "int", nullable: false),
                    lopHocIdId = table.Column<int>(type: "int", nullable: true),
                    vaiTroId = table.Column<int>(type: "int", nullable: true),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonHoc_LopHoc_lopHocIdId",
                        column: x => x.lopHocIdId,
                        principalTable: "LopHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonHoc_VaiTro_vaiTroId",
                        column: x => x.vaiTroId,
                        principalTable: "VaiTro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LopHocId = table.Column<int>(type: "int", nullable: false),
                    VaitroId = table.Column<int>(type: "int", nullable: false),
                    TaiKhoanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguoiDung_LopHoc_LopHocId",
                        column: x => x.LopHocId,
                        principalTable: "LopHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NguoiDung_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NguoiDung_VaiTro_VaitroId",
                        column: x => x.VaitroId,
                        principalTable: "VaiTro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaiGiang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheLoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonHocId = table.Column<int>(type: "int", nullable: false),
                    NguoiDungId = table.Column<int>(type: "int", nullable: true),
                    NguoiChinhSua = table.Column<int>(type: "int", nullable: false),
                    NguoiChinhSuaCuoi = table.Column<int>(type: "int", nullable: false),
                    PheDuyet = table.Column<bool>(type: "bit", nullable: false),
                    KichThuoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiGiang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaiGiang_MonHoc_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaiGiang_NguoiDung_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeThi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idMonHoc = table.Column<int>(type: "int", nullable: false),
                    HinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    ThoiLuong = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false),
                    NguoiPheDuyet = table.Column<int>(type: "int", nullable: false),
                    PheDuyet = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    monHocIdId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeThi_MonHoc_monHocIdId",
                        column: x => x.monHocIdId,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeThi_NguoiDung_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaiLieu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonHocIDId = table.Column<int>(type: "int", nullable: true),
                    SoTaiLieuChoDuyet = table.Column<int>(type: "int", nullable: false),
                    NgayGuiPheDuyet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false),
                    NguoiDungId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiLieu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiLieu_MonHoc_MonHocIDId",
                        column: x => x.MonHocIDId,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaiLieu_NguoiDung_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Loai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KichThuoc = table.Column<int>(type: "int", nullable: false),
                    TaiLieuId = table.Column<int>(type: "int", nullable: true),
                    BaiGiangId = table.Column<int>(type: "int", nullable: true),
                    DeThiId = table.Column<int>(type: "int", nullable: true),
                    VaiTroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tep_BaiGiang_BaiGiangId",
                        column: x => x.BaiGiangId,
                        principalTable: "BaiGiang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tep_DeThi_DeThiId",
                        column: x => x.DeThiId,
                        principalTable: "DeThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tep_TaiLieu_TaiLieuId",
                        column: x => x.TaiLieuId,
                        principalTable: "TaiLieu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tep_VaiTro_VaiTroId",
                        column: x => x.VaiTroId,
                        principalTable: "VaiTro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiGiang_MonHocId",
                table: "BaiGiang",
                column: "MonHocId");

            migrationBuilder.CreateIndex(
                name: "IX_BaiGiang_NguoiDungId",
                table: "BaiGiang",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_DeThi_monHocIdId",
                table: "DeThi",
                column: "monHocIdId");

            migrationBuilder.CreateIndex(
                name: "IX_DeThi_NguoiDungId",
                table: "DeThi",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_TruongIDId",
                table: "LopHoc",
                column: "TruongIDId");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_lopHocIdId",
                table: "MonHoc",
                column: "lopHocIdId");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_vaiTroId",
                table: "MonHoc",
                column: "vaiTroId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_LopHocId",
                table: "NguoiDung",
                column: "LopHocId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_TaiKhoanId",
                table: "NguoiDung",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_VaitroId",
                table: "NguoiDung",
                column: "VaitroId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_QuyenIDId",
                table: "TaiKhoan",
                column: "QuyenIDId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieu_MonHocIDId",
                table: "TaiLieu",
                column: "MonHocIDId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieu_NguoiDungId",
                table: "TaiLieu",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_Tep_BaiGiangId",
                table: "Tep",
                column: "BaiGiangId");

            migrationBuilder.CreateIndex(
                name: "IX_Tep_DeThiId",
                table: "Tep",
                column: "DeThiId");

            migrationBuilder.CreateIndex(
                name: "IX_Tep_TaiLieuId",
                table: "Tep",
                column: "TaiLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_Tep_VaiTroId",
                table: "Tep",
                column: "VaiTroId");

            migrationBuilder.CreateIndex(
                name: "IX_ThuVien_TruongHocId",
                table: "ThuVien",
                column: "TruongHocId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VaiTro_phanQuyenId",
                table: "VaiTro",
                column: "phanQuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_VaiTro_TaiKhoanId",
                table: "VaiTro",
                column: "TaiKhoanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tep");

            migrationBuilder.DropTable(
                name: "ThuVien");

            migrationBuilder.DropTable(
                name: "BaiGiang");

            migrationBuilder.DropTable(
                name: "DeThi");

            migrationBuilder.DropTable(
                name: "TaiLieu");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "LopHoc");

            migrationBuilder.DropTable(
                name: "VaiTro");

            migrationBuilder.DropTable(
                name: "TruongHoc");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "PhanQuyen");
        }
    }
}
