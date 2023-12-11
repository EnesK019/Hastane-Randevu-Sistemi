﻿// <auto-generated />
using System;
using Hastane_Randevu_Sistemi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hastane_Randevu_Sistemi.Migrations
{
    [DbContext(typeof(HastaneContext))]
    partial class HastaneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hastane_Randevu_Sistemi.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"));

                    b.Property<string>("KullaniciAd")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SifreKontrol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminID");

                    b.ToTable("Adminler");
                });

            modelBuilder.Entity("Hastane_Randevu_Sistemi.Models.CalismaGunu", b =>
                {
                    b.Property<int>("CalismaGunID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CalismaGunID"));

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<string>("Gunler")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("Saatler")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CalismaGunID");

                    b.ToTable("CalismaGunleri");
                });

            modelBuilder.Entity("Hastane_Randevu_Sistemi.Models.Doktor", b =>
                {
                    b.Property<int>("DoktorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoktorID"));

                    b.Property<string>("DoktorAd")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DoktorSoyad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("PoliklinikId")
                        .HasColumnType("int");

                    b.HasKey("DoktorID");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("Hastane_Randevu_Sistemi.Models.Hastane", b =>
                {
                    b.Property<int>("HastaneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HastaneID"));

                    b.Property<string>("HastaneAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("HastaneID");

                    b.ToTable("Hastaneler");
                });

            modelBuilder.Entity("Hastane_Randevu_Sistemi.Models.Kullanici", b =>
                {
                    b.Property<int>("KullaniciID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KullaniciID"));

                    b.Property<int>("DogumYil")
                        .HasColumnType("int");

                    b.Property<string>("KullaniciAd")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KullaniciSoyad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SifreKontrol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TcNo")
                        .HasColumnType("bigint");

                    b.HasKey("KullaniciID");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("Hastane_Randevu_Sistemi.Models.Poliklinik", b =>
                {
                    b.Property<int>("PoliklinikID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PoliklinikID"));

                    b.Property<int>("HastaneId")
                        .HasColumnType("int");

                    b.Property<int>("PoliklinikAdi")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.HasKey("PoliklinikID");

                    b.ToTable("Poliklinikler");
                });

            modelBuilder.Entity("Hastane_Randevu_Sistemi.Models.Randevu", b =>
                {
                    b.Property<int>("RandevuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RandevuID"));

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RandevuTarih")
                        .HasColumnType("datetime2");

                    b.HasKey("RandevuID");

                    b.ToTable("Randevular");
                });
#pragma warning restore 612, 618
        }
    }
}
