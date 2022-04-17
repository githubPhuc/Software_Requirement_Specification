﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Software_Requirement_Specification.Data;

namespace Software_Requirement_Specification.Migrations
{
    [DbContext(typeof(Software_Requirement_SpecificationContext))]
    [Migration("20220415115827_migration3")]
    partial class migration3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Software_Requirement_Specification.Models.DeThi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhThuc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int>("NguoiPheDuyet")
                        .HasColumnType("int");

                    b.Property<bool>("PheDuyet")
                        .HasColumnType("bit");

                    b.Property<int>("ThoiLuong")
                        .HasColumnType("int");

                    b.Property<bool>("TinhTrang")
                        .HasColumnType("bit");

                    b.Property<int?>("VaiTroId")
                        .HasColumnType("int");

                    b.Property<int>("idMonHoc")
                        .HasColumnType("int");

                    b.Property<int?>("monHocIdId")
                        .HasColumnType("int");

                    b.Property<int?>("tepIdId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VaiTroId");

                    b.HasIndex("monHocIdId");

                    b.HasIndex("tepIdId");

                    b.ToTable("DeThi");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.LopHoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NienKhoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenLop")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TruongIDId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TruongIDId");

                    b.ToTable("LopHoc");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.MonHoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenMonHoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TinhTrang")
                        .HasColumnType("bit");

                    b.Property<int>("idLopHoc")
                        .HasColumnType("int");

                    b.Property<int?>("lopHocIdId")
                        .HasColumnType("int");

                    b.Property<string>("maNguoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("vaiTroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("lopHocIdId");

                    b.HasIndex("vaiTroId");

                    b.ToTable("MonHoc");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.PhanQuyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenQuyen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("PhanQuyen");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.TaiKhoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuyenIDId")
                        .HasColumnType("int");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNguoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.Property<int>("idQuyen")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuyenIDId");

                    b.ToTable("TaiKhoan");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.TaiLieu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MonHocIDId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayGuiPheDuyet")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoTaiLieuChoDuyet")
                        .HasColumnType("int");

                    b.Property<string>("TenMonHoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TinhTrang")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MonHocIDId");

                    b.ToTable("TaiLieu");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.Tep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DeThiId")
                        .HasColumnType("int");

                    b.Property<int>("KichThuoc")
                        .HasColumnType("int");

                    b.Property<string>("LoaiFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySuaLanCuoi")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiChinhSua")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTep")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeThiId");

                    b.ToTable("Tep");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.TruongHoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HieuTruong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenThuVien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTruong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.Property<string>("WebSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TruongHoc");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.VaiTro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdTaiKhoan")
                        .HasColumnType("int");

                    b.Property<string>("MaNguoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NguoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenVaiTro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TepRiengTuId")
                        .HasColumnType("int");

                    b.Property<string>("ThongBao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("taikhoanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TepRiengTuId");

                    b.HasIndex("taikhoanId");

                    b.ToTable("VaiTro");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.DeThi", b =>
                {
                    b.HasOne("Software_Requirement_Specification.Models.VaiTro", null)
                        .WithMany("De")
                        .HasForeignKey("VaiTroId");

                    b.HasOne("Software_Requirement_Specification.Models.MonHoc", "monHocId")
                        .WithMany("deThis")
                        .HasForeignKey("monHocIdId");

                    b.HasOne("Software_Requirement_Specification.Models.Tep", "tepId")
                        .WithMany()
                        .HasForeignKey("tepIdId");

                    b.Navigation("monHocId");

                    b.Navigation("tepId");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.LopHoc", b =>
                {
                    b.HasOne("Software_Requirement_Specification.Models.TruongHoc", "TruongID")
                        .WithMany("lopHocs")
                        .HasForeignKey("TruongIDId");

                    b.Navigation("TruongID");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.MonHoc", b =>
                {
                    b.HasOne("Software_Requirement_Specification.Models.LopHoc", "lopHocId")
                        .WithMany("monHocs")
                        .HasForeignKey("lopHocIdId");

                    b.HasOne("Software_Requirement_Specification.Models.VaiTro", "vaiTro")
                        .WithMany("monHocs")
                        .HasForeignKey("vaiTroId");

                    b.Navigation("lopHocId");

                    b.Navigation("vaiTro");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.TaiKhoan", b =>
                {
                    b.HasOne("Software_Requirement_Specification.Models.PhanQuyen", "QuyenID")
                        .WithMany()
                        .HasForeignKey("QuyenIDId");

                    b.Navigation("QuyenID");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.TaiLieu", b =>
                {
                    b.HasOne("Software_Requirement_Specification.Models.MonHoc", "MonHocID")
                        .WithMany("taiLieus")
                        .HasForeignKey("MonHocIDId");

                    b.Navigation("MonHocID");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.Tep", b =>
                {
                    b.HasOne("Software_Requirement_Specification.Models.DeThi", null)
                        .WithMany("teps")
                        .HasForeignKey("DeThiId");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.VaiTro", b =>
                {
                    b.HasOne("Software_Requirement_Specification.Models.Tep", "TepRiengTu")
                        .WithMany()
                        .HasForeignKey("TepRiengTuId");

                    b.HasOne("Software_Requirement_Specification.Models.TaiKhoan", "taikhoan")
                        .WithMany("vaiTro")
                        .HasForeignKey("taikhoanId");

                    b.Navigation("taikhoan");

                    b.Navigation("TepRiengTu");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.DeThi", b =>
                {
                    b.Navigation("teps");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.LopHoc", b =>
                {
                    b.Navigation("monHocs");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.MonHoc", b =>
                {
                    b.Navigation("deThis");

                    b.Navigation("taiLieus");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.TaiKhoan", b =>
                {
                    b.Navigation("vaiTro");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.TruongHoc", b =>
                {
                    b.Navigation("lopHocs");
                });

            modelBuilder.Entity("Software_Requirement_Specification.Models.VaiTro", b =>
                {
                    b.Navigation("De");

                    b.Navigation("monHocs");
                });
#pragma warning restore 612, 618
        }
    }
}
