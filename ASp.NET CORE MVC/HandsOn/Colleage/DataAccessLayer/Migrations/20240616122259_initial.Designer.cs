﻿// <auto-generated />
using DataAccessLayer.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20240616122259_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ModelLayer.Department", b =>
                {
                    b.Property<int>("DepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepId"));

                    b.Property<string>("DepName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DepId");

                    b.ToTable("departments");

                    b.HasData(
                        new
                        {
                            DepId = 1,
                            DepName = "SocialWork"
                        },
                        new
                        {
                            DepId = 2,
                            DepName = "Information Technology"
                        },
                        new
                        {
                            DepId = 3,
                            DepName = "Computer Science"
                        });
                });

            modelBuilder.Entity("ModelLayer.Student", b =>
                {
                    b.Property<int>("StuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StuId"));

                    b.Property<string>("StuCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StuDepID")
                        .HasColumnType("int");

                    b.Property<string>("StuName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("StuId");

                    b.HasIndex("StuDepID");

                    b.ToTable("students");

                    b.HasData(
                        new
                        {
                            StuId = 1,
                            StuCity = "Liverpool",
                            StuDepID = 1,
                            StuName = "Lisa"
                        },
                        new
                        {
                            StuId = 2,
                            StuCity = "Widnes",
                            StuDepID = 2,
                            StuName = "Siva"
                        },
                        new
                        {
                            StuId = 3,
                            StuCity = "Birmingham",
                            StuDepID = 3,
                            StuName = "Nagu"
                        });
                });

            modelBuilder.Entity("ModelLayer.Student", b =>
                {
                    b.HasOne("ModelLayer.Department", "Department")
                        .WithMany()
                        .HasForeignKey("StuDepID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}