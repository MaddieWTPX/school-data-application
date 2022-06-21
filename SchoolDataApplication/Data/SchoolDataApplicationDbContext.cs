using Microsoft.EntityFrameworkCore;
using SchoolDataApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;

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
            modelBuilder.Entity<User>()
                .Property(u => u.UserId).ValueGeneratedOnAdd();


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

            modelBuilder.Entity<UserType>().HasData(
            new UserType { UserTypeId = 1, Name = "Teacher" },
            new UserType { UserTypeId = 2, Name = "Student" }
            );

            modelBuilder.Entity<SchoolClass>().HasData(
                new SchoolClass { ClassId = 1, ClassName = "French", ClassDescription = "Modern Foreign Languages" },
                new SchoolClass { ClassId = 2, ClassName = "Italian", ClassDescription = "Modern Foreign Languages" },
                new SchoolClass { ClassId = 3, ClassName = "Mathematics", ClassDescription = "STEM" },
                new SchoolClass { ClassId = 4, ClassName = "Chemistry", ClassDescription = "STEM" },
                new SchoolClass { ClassId = 5, ClassName = "Physics", ClassDescription = "STEM" },
                new SchoolClass { ClassId = 6, ClassName = "Biology", ClassDescription = "STEM" },
                new SchoolClass { ClassId = 7, ClassName = "Literature", ClassDescription = "Humanities" }
                );

            modelBuilder.Entity<User>()
                .Property(s => s.School)
                .HasDefaultValue("TPXSchool");


        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<ClassAssignment> ClassAssignments { get; set; }

    }
}
