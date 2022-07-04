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
    [Migration("20220701170555_AddDBSetsForAdditionalProperties")]
    partial class AddDBSetsForAdditionalProperties
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

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ClassId");

                    b.HasIndex("ClassId");

                    b.ToTable("ClassAssignments");

                    b.HasData(
                        new
                        {
                            UserId = 2,
                            ClassId = 1,
                            SchoolId = 1
                        },
                        new
                        {
                            UserId = 2,
                            ClassId = 2,
                            SchoolId = 1
                        });
                });

            modelBuilder.Entity("SchoolDataApplication.Models.School", b =>
                {
                    b.Property<int>("SchoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SchoolId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolId");

                    b.ToTable("Schools");

                    b.HasData(
                        new
                        {
                            SchoolId = 1,
                            Address = "TPX, London, UK",
                            Name = "TPXImpact School"
                        });
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

                    b.Property<int?>("UserTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("YearGroupId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UserTypeId");

                    b.HasIndex("YearGroupId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            FirstName = "Ben",
                            LastName = "Sztucki",
                            UserTypeId = 1
                        },
                        new
                        {
                            UserId = 2,
                            FirstName = "Madeleine",
                            LastName = "Williams",
                            UserTypeId = 2,
                            YearGroupId = 1
                        });
                });

            modelBuilder.Entity("SchoolDataApplication.Models.UserSchool", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "SchoolId");

                    b.HasIndex("SchoolId");

                    b.ToTable("UserSchools");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            SchoolId = 1
                        });
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

            modelBuilder.Entity("SchoolDataApplication.Models.YearGroup", b =>
                {
                    b.Property<int>("YearGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("YearGroupId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("YearGroupId");

                    b.ToTable("YearGroups");

                    b.HasData(
                        new
                        {
                            YearGroupId = 1,
                            Name = "Year 1"
                        },
                        new
                        {
                            YearGroupId = 2,
                            Name = "Year 2"
                        },
                        new
                        {
                            YearGroupId = 3,
                            Name = "Year 3"
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
                        .HasForeignKey("UserTypeId");

                    b.HasOne("SchoolDataApplication.Models.YearGroup", "YearGroup")
                        .WithMany("Users")
                        .HasForeignKey("YearGroupId");

                    b.Navigation("UserType");

                    b.Navigation("YearGroup");
                });

            modelBuilder.Entity("SchoolDataApplication.Models.UserSchool", b =>
                {
                    b.HasOne("SchoolDataApplication.Models.School", "School")
                        .WithMany("UserSchools")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolDataApplication.Models.User", "User")
                        .WithMany("UserSchools")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SchoolDataApplication.Models.School", b =>
                {
                    b.Navigation("UserSchools");
                });

            modelBuilder.Entity("SchoolDataApplication.Models.SchoolClass", b =>
                {
                    b.Navigation("ClassAssignments");
                });

            modelBuilder.Entity("SchoolDataApplication.Models.User", b =>
                {
                    b.Navigation("ClassAssignments");

                    b.Navigation("UserSchools");
                });

            modelBuilder.Entity("SchoolDataApplication.Models.UserType", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SchoolDataApplication.Models.YearGroup", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}