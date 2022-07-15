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
    [Migration("20220713154312_ReSeedUserData")]
    partial class ReSeedUserData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Models.Entities.ClassAssignment", b =>
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
                            UserId = 1,
                            ClassId = 1,
                            SchoolId = 1
                        },
                        new
                        {
                            UserId = 1,
                            ClassId = 2,
                            SchoolId = 1
                        },
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

            modelBuilder.Entity("Models.Entities.School", b =>
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
                            Address = "TPX Road, London, TPX 123, UK",
                            Name = "TPXImpact School"
                        });
                });

            modelBuilder.Entity("Models.Entities.SchoolClass", b =>
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

            modelBuilder.Entity("Models.Entities.User", b =>
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

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("YearGroupId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("SchoolId");

                    b.HasIndex("UserTypeId");

                    b.HasIndex("YearGroupId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            FirstName = "Ben",
                            LastName = "Sztucki",
                            SchoolId = 1,
                            UserTypeId = 1
                        },
                        new
                        {
                            UserId = 2,
                            DateOfBirth = new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Madeleine",
                            LastName = "Williams",
                            SchoolId = 1,
                            UserTypeId = 2,
                            YearGroupId = 1
                        },
                        new
                        {
                            UserId = 3,
                            FirstName = "Frodo",
                            LastName = "Baggins",
                            SchoolId = 1,
                            UserTypeId = 1
                        },
                        new
                        {
                            UserId = 4,
                            DateOfBirth = new DateTime(2015, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Harry",
                            LastName = "Potter",
                            SchoolId = 1,
                            UserTypeId = 2,
                            YearGroupId = 4
                        });
                });

            modelBuilder.Entity("Models.Entities.UserType", b =>
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

            modelBuilder.Entity("Models.Entities.YearGroup", b =>
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
                        },
                        new
                        {
                            YearGroupId = 4,
                            Name = "Year 4"
                        },
                        new
                        {
                            YearGroupId = 5,
                            Name = "Year 5"
                        },
                        new
                        {
                            YearGroupId = 6,
                            Name = "Year 6"
                        },
                        new
                        {
                            YearGroupId = 7,
                            Name = "Year 7"
                        },
                        new
                        {
                            YearGroupId = 8,
                            Name = "Year 8"
                        },
                        new
                        {
                            YearGroupId = 9,
                            Name = "Year 9"
                        },
                        new
                        {
                            YearGroupId = 10,
                            Name = "Year 10"
                        },
                        new
                        {
                            YearGroupId = 11,
                            Name = "Year 11"
                        },
                        new
                        {
                            YearGroupId = 12,
                            Name = "Year 12"
                        },
                        new
                        {
                            YearGroupId = 13,
                            Name = "Year 13"
                        });
                });

            modelBuilder.Entity("Models.Entities.ClassAssignment", b =>
                {
                    b.HasOne("Models.Entities.SchoolClass", "SchoolClass")
                        .WithMany("ClassAssignments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.User", "User")
                        .WithMany("ClassAssignments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SchoolClass");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Entities.User", b =>
                {
                    b.HasOne("Models.Entities.School", "School")
                        .WithMany("Users")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.YearGroup", "YearGroup")
                        .WithMany("Users")
                        .HasForeignKey("YearGroupId");

                    b.Navigation("School");

                    b.Navigation("UserType");

                    b.Navigation("YearGroup");
                });

            modelBuilder.Entity("Models.Entities.School", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Models.Entities.SchoolClass", b =>
                {
                    b.Navigation("ClassAssignments");
                });

            modelBuilder.Entity("Models.Entities.User", b =>
                {
                    b.Navigation("ClassAssignments");
                });

            modelBuilder.Entity("Models.Entities.UserType", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Models.Entities.YearGroup", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
