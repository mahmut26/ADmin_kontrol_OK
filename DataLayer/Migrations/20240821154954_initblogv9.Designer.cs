﻿// <auto-generated />
using System;
using DataLayer.Model_DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(Blog_DB))]
    [Migration("20240821154954_initblogv9")]
    partial class initblogv9
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataLayer.Model_Blog.Kategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("kategoris");
                });

            modelBuilder.Entity("DataLayer.Model_Blog.Makale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Baslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icerik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<int>("YazarId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KategoriId");

                    b.HasIndex("YazarId");

                    b.ToTable("makales");
                });

            modelBuilder.Entity("DataLayer.Model_Blog.Resim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MakaleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MakaleId");

                    b.ToTable("resims");
                });

            modelBuilder.Entity("DataLayer.Model_Blog.Yazar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("yazars");
                });

            modelBuilder.Entity("DataLayer.Model_Kullanicilar.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("kategoriId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("kullanicis");
                });

            modelBuilder.Entity("KategoriKullanici", b =>
                {
                    b.Property<int>("KategorilerId")
                        .HasColumnType("int");

                    b.Property<int>("KullanicilarId")
                        .HasColumnType("int");

                    b.HasKey("KategorilerId", "KullanicilarId");

                    b.HasIndex("KullanicilarId");

                    b.ToTable("KategoriKullanici");
                });

            modelBuilder.Entity("DataLayer.Model_Blog.Makale", b =>
                {
                    b.HasOne("DataLayer.Model_Blog.Kategori", "kategori")
                        .WithMany("makales")
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Model_Blog.Yazar", "yazar")
                        .WithMany("Makaleler")
                        .HasForeignKey("YazarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kategori");

                    b.Navigation("yazar");
                });

            modelBuilder.Entity("DataLayer.Model_Blog.Resim", b =>
                {
                    b.HasOne("DataLayer.Model_Blog.Makale", null)
                        .WithMany("resim")
                        .HasForeignKey("MakaleId");
                });

            modelBuilder.Entity("KategoriKullanici", b =>
                {
                    b.HasOne("DataLayer.Model_Blog.Kategori", null)
                        .WithMany()
                        .HasForeignKey("KategorilerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Model_Kullanicilar.Kullanici", null)
                        .WithMany()
                        .HasForeignKey("KullanicilarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Model_Blog.Kategori", b =>
                {
                    b.Navigation("makales");
                });

            modelBuilder.Entity("DataLayer.Model_Blog.Makale", b =>
                {
                    b.Navigation("resim");
                });

            modelBuilder.Entity("DataLayer.Model_Blog.Yazar", b =>
                {
                    b.Navigation("Makaleler");
                });
#pragma warning restore 612, 618
        }
    }
}
