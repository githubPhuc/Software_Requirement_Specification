﻿using System;
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
                    TenThuVien = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    VaiTro = table.Column<int>(type: "int", nullable: false),
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
                name: "MonHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lopHocIdId = table.Column<int>(type: "int", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "TaiLieu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonHocIDId = table.Column<int>(type: "int", nullable: true),
                    SoTaiLieuChoDuyet = table.Column<int>(type: "int", nullable: false),
                    NgayGuiPheDuyet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Tep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiChinhSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySuaLanCuoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KichThuoc = table.Column<int>(type: "int", nullable: false),
                    DeThiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeThi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    monHocIdId = table.Column<int>(type: "int", nullable: true),
                    HinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tepIdId = table.Column<int>(type: "int", nullable: true),
                    ThoiLuong = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false),
                    NguoiPheDuyet = table.Column<int>(type: "int", nullable: false),
                    PheDuyet = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                        name: "FK_DeThi_Tep_tepIdId",
                        column: x => x.tepIdId,
                        principalTable: "Tep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VaiTro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDung = table.Column<int>(type: "int", nullable: false),
                    TenVaiTro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonHocId = table.Column<int>(type: "int", nullable: true),
                    TepRiengTuId = table.Column<int>(type: "int", nullable: true),
                    TaiNguyenId = table.Column<int>(type: "int", nullable: true),
                    DeId = table.Column<int>(type: "int", nullable: true),
                    ThongBao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhanQuyenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaiTro_DeThi_DeId",
                        column: x => x.DeId,
                        principalTable: "DeThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VaiTro_MonHoc_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VaiTro_PhanQuyen_PhanQuyenId",
                        column: x => x.PhanQuyenId,
                        principalTable: "PhanQuyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VaiTro_TaiLieu_TaiNguyenId",
                        column: x => x.TaiNguyenId,
                        principalTable: "TaiLieu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VaiTro_Tep_TepRiengTuId",
                        column: x => x.TepRiengTuId,
                        principalTable: "Tep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeThi_monHocIdId",
                table: "DeThi",
                column: "monHocIdId");

            migrationBuilder.CreateIndex(
                name: "IX_DeThi_tepIdId",
                table: "DeThi",
                column: "tepIdId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_TruongIDId",
                table: "LopHoc",
                column: "TruongIDId");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_lopHocIdId",
                table: "MonHoc",
                column: "lopHocIdId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_QuyenIDId",
                table: "TaiKhoan",
                column: "QuyenIDId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieu_MonHocIDId",
                table: "TaiLieu",
                column: "MonHocIDId");

            migrationBuilder.CreateIndex(
                name: "IX_Tep_DeThiId",
                table: "Tep",
                column: "DeThiId");

            migrationBuilder.CreateIndex(
                name: "IX_VaiTro_DeId",
                table: "VaiTro",
                column: "DeId");

            migrationBuilder.CreateIndex(
                name: "IX_VaiTro_MonHocId",
                table: "VaiTro",
                column: "MonHocId");

            migrationBuilder.CreateIndex(
                name: "IX_VaiTro_PhanQuyenId",
                table: "VaiTro",
                column: "PhanQuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_VaiTro_TaiNguyenId",
                table: "VaiTro",
                column: "TaiNguyenId");

            migrationBuilder.CreateIndex(
                name: "IX_VaiTro_TepRiengTuId",
                table: "VaiTro",
                column: "TepRiengTuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tep_DeThi_DeThiId",
                table: "Tep",
                column: "DeThiId",
                principalTable: "DeThi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeThi_MonHoc_monHocIdId",
                table: "DeThi");

            migrationBuilder.DropForeignKey(
                name: "FK_DeThi_Tep_tepIdId",
                table: "DeThi");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "VaiTro");

            migrationBuilder.DropTable(
                name: "PhanQuyen");

            migrationBuilder.DropTable(
                name: "TaiLieu");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "LopHoc");

            migrationBuilder.DropTable(
                name: "TruongHoc");

            migrationBuilder.DropTable(
                name: "Tep");

            migrationBuilder.DropTable(
                name: "DeThi");
        }
    }
}
