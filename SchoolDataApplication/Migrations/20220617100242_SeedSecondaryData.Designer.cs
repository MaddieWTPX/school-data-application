﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolDataApplication.Data;

#nullable disable

namespace SchoolDataApplication.Migrations
{
    [DbContext(typeof(SchoolDataApplicationDbContext))]
    [Migration("20220617100242_SeedSecondaryData")]
    partial class SeedSecondaryData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SchoolDataApplication.Models.ClassAssignment", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ClassId");

                    b.HasIndex("ClassId");

                    b.ToTable("ClassAssignments");
                });

            modelBuilder.Entity("SchoolDataApplication.Models.SchoolClass", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"), 1L, 1);

                    b.Property<string>("ClassDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassId");

                    b.ToTable("SchoolClasses");

                    b.HasData(
                        new
                        {
                            ClassId = 1,
                            ClassDescription = "Modern Foreign Languages",
                            ClassName = "French"
                        },
                        new
                        {
                            ClassId = 2,
                            ClassDescription = "Modern Foreign Languages",
                            ClassName = "Italian"
                        },
                        new
                        {
                            ClassId = 3,
                            ClassDescription = "STEM",
                            ClassName = "Mathematics"
                        },
                        new
                        {
                            ClassId = 4,
                            ClassDescription = "STEM",
                            ClassName = "Chemistry"
                        },
                        new
                        {
                            ClassId = 5,
                            ClassDescription = "STEM",
                            ClassName = "Physics"
                        },
                        new
                        {
                            ClassId = 6,
                            ClassDescription = "STEM",
                            ClassName = "Biology"
                        },
                        new
                        {
                            ClassId = 7,
                            ClassDescription = "Humanities",
                            ClassName = "Literature"
                        });
                });

            modelBuilder.Entity("SchoolDataApplication.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("YearGroup")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SchoolDataApplication.Models.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserTypeId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserTypeId");

                    b.ToTable("UserTypes");

                    b.HasData(
                        new
                        {
                            UserTypeId = 1,
                            Name = "Teacher"
                        },
                        new
                        {
                            UserTypeId = 2,
                            Name = "Student"
                        });
                });

            modelBuilder.Entity("SchoolDataApplication.Models.ClassAssignment", b =>
                {
                    b.HasOne("SchoolDataApplication.Models.SchoolClass", "SchoolClass")
                        .WithMany("ClassAssignments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolDataApplication.Models.User", "User")
                        .WithMany("ClassAssignments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SchoolClass");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SchoolDataApplication.Models.User", b =>
                {
                    b.HasOne("SchoolDataApplication.Models.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("SchoolDataApplication.Models.SchoolClass", b =>
                {
                    b.Navigation("ClassAssignments");
                });

            modelBuilder.Entity("SchoolDataApplication.Models.User", b =>
                {
                    b.Navigation("ClassAssignments");
                });

            modelBuilder.Entity("SchoolDataApplication.Models.UserType", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
