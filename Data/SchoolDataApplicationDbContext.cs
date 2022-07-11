﻿using Microsoft.EntityFrameworkCore;
using Models;
using Models.Entities;

namespace SchoolDataApplication.Data
{
    public class SchoolDataApplicationDbContext : DbContext
    {
        public SchoolDataApplicationDbContext(DbContextOptions<SchoolDataApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<UserType>()
               .HasKey(a => a.UserTypeId);

            modelBuilder.Entity<School>()
                .HasKey(a => a.SchoolId);

            modelBuilder.Entity<YearGroup>()
                .HasKey(a => a.YearGroupId);

            modelBuilder.Entity<User>()
                .Property(u => u.UserId).ValueGeneratedOnAdd();


            modelBuilder.Entity<User>()
                .HasKey(a => a.UserId);

            modelBuilder.Entity<User>()
                .HasOne(a => a.UserType)
                .WithMany(a => a.Users)
                .HasForeignKey(a => a.UserTypeId);

            modelBuilder.Entity<User>()
                 .HasOne(a => a.YearGroup)
                 .WithMany(a => a.Users)
                 .HasForeignKey(a => a.YearGroupId);

            modelBuilder.Entity<User>()
                .HasOne(a => a.School)
                .WithMany(a => a.Users)
                .HasForeignKey(a => a.SchoolId);

            // Creates the composite primary key of Class Assignment which uses UserId and ClassId together
            modelBuilder.Entity<ClassAssignment>()
                .HasKey(a => new { a.UserId, a.ClassId });

            modelBuilder.Entity<ClassAssignment>()
                .HasOne(a => a.User)
                .WithMany(a => a.ClassAssignments)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<ClassAssignment>()
                .HasOne(a => a.SchoolClass)
                .WithMany(a => a.ClassAssignments)
                .HasForeignKey(a => a.ClassId);

            

            SeedData(modelBuilder);

        }
        private void SeedData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserType>().HasData(
                new UserType { UserTypeId = 1, Name = "Teacher" },
                new UserType { UserTypeId = 2, Name = "Student" }
            );

            modelBuilder.Entity<YearGroup>().HasData(
                new YearGroup { YearGroupId = 1, Name = "Year 1" },
                new YearGroup { YearGroupId = 2, Name = "Year 2" },
                new YearGroup { YearGroupId = 3, Name = "Year 3" },
                new YearGroup { YearGroupId = 4, Name = "Year 4" },
                new YearGroup { YearGroupId = 5, Name = "Year 5" },
                new YearGroup { YearGroupId = 6, Name = "Year 6" },
                new YearGroup { YearGroupId = 7, Name = "Year 7" },
                new YearGroup { YearGroupId = 8, Name = "Year 8" },
                new YearGroup { YearGroupId = 9, Name = "Year 9" },
                new YearGroup { YearGroupId = 10, Name = "Year 10" },
                new YearGroup { YearGroupId = 11, Name = "Year 11" },
                new YearGroup { YearGroupId = 12, Name = "Year 12" },
                new YearGroup { YearGroupId = 13, Name = "Year 13" }
                );

            modelBuilder.Entity<School>().HasData(
                new School { SchoolId = 1, Name = "TPXImpact School", Address = "TPX Road, London, TPX 123, UK" });

            modelBuilder.Entity<SchoolClass>().HasData(
                new SchoolClass { ClassId = 1, ClassName = "French", ClassDescription = "Modern Foreign Languages" },
                new SchoolClass { ClassId = 2, ClassName = "Italian", ClassDescription = "Modern Foreign Languages" },
                new SchoolClass { ClassId = 3, ClassName = "Mathematics", ClassDescription = "STEM" },
                new SchoolClass { ClassId = 4, ClassName = "Chemistry", ClassDescription = "STEM" },
                new SchoolClass { ClassId = 5, ClassName = "Physics", ClassDescription = "STEM" },
                new SchoolClass { ClassId = 6, ClassName = "Biology", ClassDescription = "STEM" },
                new SchoolClass { ClassId = 7, ClassName = "Literature", ClassDescription = "Humanities" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserTypeId = 1, YearGroupId = null, FirstName = "Ben", LastName = "Sztucki", DateOfBirth = null, SchoolId = 1 },
                new User { UserId = 2, UserTypeId = 2, YearGroupId = 1, FirstName = "Madeleine", LastName = "Williams", DateOfBirth = new DateTime(1996, 4, 11), SchoolId = 1 }
                );

            modelBuilder.Entity<ClassAssignment>().HasData(
                new ClassAssignment { UserId = 1, SchoolId = 1, ClassId = 1 },
                new ClassAssignment { UserId = 1, SchoolId = 1, ClassId = 2 },
                new ClassAssignment { UserId = 2, SchoolId = 1, ClassId = 1 },
                new ClassAssignment { UserId = 2, SchoolId = 1, ClassId = 2 }
                );

            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<ClassAssignment> ClassAssignments { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<YearGroup> YearGroups { get; set; }


    }
}
