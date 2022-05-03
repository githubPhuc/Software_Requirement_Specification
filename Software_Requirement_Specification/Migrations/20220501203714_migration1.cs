using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoMon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBoMon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoMon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiLopHoc",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenLoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiLopHoc", x => x.id);
                });

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
                name: "ThuVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTruongHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTruongHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HieuTruong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    loaiId = table.Column<int>(type: "int", nullable: false),
                    loaiLopHocid = table.Column<int>(type: "int", nullable: true),
                    NienKhoa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LopHoc_LoaiLopHoc_loaiLopHocid",
                        column: x => x.loaiLopHocid,
                        principalTable: "LoaiLopHoc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "VaiTro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "NguoiDung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LopHocId = table.Column<int>(type: "int", nullable: false),
                    VaitroId = table.Column<int>(type: "int", nullable: false),
                    IdtaiKhoan = table.Column<int>(type: "int", nullable: false),
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
                name: "MonHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nguoiDungId = table.Column<int>(type: "int", nullable: false),
                    TenMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoMonId = table.Column<int>(type: "int", nullable: false),
                    idLopHoc = table.Column<int>(type: "int", nullable: false),
                    lopHocIdId = table.Column<int>(type: "int", nullable: true),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonHoc_BoMon_BoMonId",
                        column: x => x.BoMonId,
                        principalTable: "BoMon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonHoc_LopHoc_lopHocIdId",
                        column: x => x.lopHocIdId,
                        principalTable: "LopHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonHoc_NguoiDung_nguoiDungId",
                        column: x => x.nguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongBao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiThongBao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiLopHocId = table.Column<int>(type: "int", nullable: false),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    ChuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LopHocId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongBao_LoaiLopHoc_LoaiLopHocId",
                        column: x => x.LoaiLopHocId,
                        principalTable: "LoaiLopHoc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongBao_LopHoc_LopHocId",
                        column: x => x.LopHocId,
                        principalTable: "LopHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThongBao_NguoiDung_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
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
                name: "TaiLieu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tentailieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    monhocId = table.Column<int>(type: "int", nullable: false),
                    PheDuyet = table.Column<bool>(type: "bit", nullable: false),
                    NgayGuiPheDuyet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idNguoiDung = table.Column<int>(type: "int", nullable: false),
                    nguoiDungId = table.Column<int>(type: "int", nullable: true),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiLieu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiLieu_MonHoc_monhocId",
                        column: x => x.monhocId,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaiLieu_NguoiDung_nguoiDungId",
                        column: x => x.nguoiDungId,
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
                    TenTep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheLoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiChinhSua = table.Column<int>(type: "int", nullable: false),
                    NgaySuaCuoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KichThuoc = table.Column<int>(type: "int", nullable: false),
                    idTaiLieu = table.Column<int>(type: "int", nullable: false),
                    TaiLieuId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tep_TaiLieu_TaiLieuId",
                        column: x => x.TaiLieuId,
                        principalTable: "TaiLieu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeThi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tendethi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idMonHoc = table.Column<int>(type: "int", nullable: false),
                    monHocIdId = table.Column<int>(type: "int", nullable: true),
                    HinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    idLopHoc = table.Column<int>(type: "int", nullable: false),
                    lopHocId = table.Column<int>(type: "int", nullable: true),
                    ThoiLuong = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false),
                    NguoiPheDuyet = table.Column<int>(type: "int", nullable: false),
                    PheDuyet = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TepId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeThi_LopHoc_lopHocId",
                        column: x => x.lopHocId,
                        principalTable: "LopHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_DeThi_Tep_TepId",
                        column: x => x.TepId,
                        principalTable: "Tep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_DeThi_lopHocId",
                table: "DeThi",
                column: "lopHocId");

            migrationBuilder.CreateIndex(
                name: "IX_DeThi_monHocIdId",
                table: "DeThi",
                column: "monHocIdId");

            migrationBuilder.CreateIndex(
                name: "IX_DeThi_NguoiDungId",
                table: "DeThi",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_DeThi_TepId",
                table: "DeThi",
                column: "TepId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_loaiLopHocid",
                table: "LopHoc",
                column: "loaiLopHocid");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_BoMonId",
                table: "MonHoc",
                column: "BoMonId");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_lopHocIdId",
                table: "MonHoc",
                column: "lopHocIdId");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_nguoiDungId",
                table: "MonHoc",
                column: "nguoiDungId");

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
                name: "IX_TaiLieu_monhocId",
                table: "TaiLieu",
                column: "monhocId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieu_nguoiDungId",
                table: "TaiLieu",
                column: "nguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_Tep_TaiLieuId",
                table: "Tep",
                column: "TaiLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBao_LoaiLopHocId",
                table: "ThongBao",
                column: "LoaiLopHocId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBao_LopHocId",
                table: "ThongBao",
                column: "LopHocId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBao_NguoiDungId",
                table: "ThongBao",
                column: "NguoiDungId");

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
                name: "BaiGiang");

            migrationBuilder.DropTable(
                name: "DeThi");

            migrationBuilder.DropTable(
                name: "ThongBao");

            migrationBuilder.DropTable(
                name: "ThuVien");

            migrationBuilder.DropTable(
                name: "Tep");

            migrationBuilder.DropTable(
                name: "TaiLieu");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "BoMon");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "LopHoc");

            migrationBuilder.DropTable(
                name: "VaiTro");

            migrationBuilder.DropTable(
                name: "LoaiLopHoc");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "PhanQuyen");
        }
    }
}
