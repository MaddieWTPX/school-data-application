using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
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
                new User { UserId = 1, UserTypeId = 1, YearGroupId = null, FirstName = "Gandalf", LastName = "Greyhame", DateOfBirth = null, SchoolId = 1 },
                new User { UserId = 2, UserTypeId = 1, YearGroupId = null, FirstName = "Severus", LastName = "Snape", DateOfBirth = null, SchoolId = 1},
                new User { UserId = 3, UserTypeId = 2, YearGroupId = null, FirstName = "Seymour", LastName = "Skinner", DateOfBirth = null, SchoolId = 1 },
                new User { UserId = 4, UserTypeId = 2, YearGroupId = null, FirstName = "Haymitch", LastName = "Abernathy ", DateOfBirth = null, SchoolId = 1 },
                new User { UserId = 5, UserTypeId = 1, YearGroupId = null, FirstName = "Edna", LastName = "Krabapple", DateOfBirth = null, SchoolId = 1 },
                new User { UserId = 6, UserTypeId = 1, YearGroupId = null, FirstName = "Minerva", LastName = "McGonagall", DateOfBirth = null, SchoolId = 1 },
                new User { UserId = 7, UserTypeId = 1, YearGroupId = null, FirstName = "Albus", LastName = "Dumbledore", DateOfBirth = null, SchoolId = 1 },
                new User { UserId = 8, UserTypeId = 2, YearGroupId = 6, FirstName = "Frodo", LastName = "Baggins", DateOfBirth = new DateTime(2011, 3, 11), SchoolId = 1 },
                new User { UserId = 9, UserTypeId = 2, YearGroupId = 2, FirstName = "Harry", LastName = "Potter", DateOfBirth = new DateTime(2015, 7, 31), SchoolId = 1 },
                new User { UserId = 10, UserTypeId = 2, YearGroupId = 3, FirstName = "Lisa", LastName = "Simpson", DateOfBirth = new DateTime(2014, 2, 19), SchoolId = 1 },
                new User { UserId = 11, UserTypeId = 2, YearGroupId = 4, FirstName = "Katniss", LastName = "Everdeen", DateOfBirth = new DateTime(2016, 9, 9), SchoolId = 1 },
                new User { UserId = 12, UserTypeId = 2, YearGroupId = 5, FirstName = "Milhouse", LastName = "Vanhouten", DateOfBirth = new DateTime(2014, 8, 4), SchoolId = 1 },
                new User { UserId = 13, UserTypeId = 2, YearGroupId = 6, FirstName = "Samwise", LastName = "Gamgee", DateOfBirth = new DateTime(2011, 2, 19), SchoolId = 1 },
                new User { UserId = 14, UserTypeId = 2, YearGroupId = 4, FirstName = "Bart", LastName = "Simpson", DateOfBirth = new DateTime(2013, 12, 4), SchoolId = 1 }

                );

            modelBuilder.Entity<ClassAssignment>().HasData(
                new ClassAssignment { UserId = 1, SchoolId = 1, ClassId = 1 },
                new ClassAssignment { UserId = 2, SchoolId = 1, ClassId = 1 },
                new ClassAssignment { UserId = 3, SchoolId = 1, ClassId = 2 },
                new ClassAssignment { UserId = 4, SchoolId = 1, ClassId = 3 },
                new ClassAssignment { UserId = 5, SchoolId = 1, ClassId = 4 },
                new ClassAssignment { UserId = 6, SchoolId = 1, ClassId = 5 },
                new ClassAssignment { UserId = 7, SchoolId = 1, ClassId = 6 },
                new ClassAssignment { UserId = 8, SchoolId = 1, ClassId = 7 },
                new ClassAssignment { UserId = 9, SchoolId = 1, ClassId = 1 },
                new ClassAssignment { UserId = 10, SchoolId = 1, ClassId = 1 },
                new ClassAssignment { UserId = 11, SchoolId = 1, ClassId = 1 },
                new ClassAssignment { UserId = 9, SchoolId = 1, ClassId = 2 },
                new ClassAssignment { UserId = 10, SchoolId = 1, ClassId = 3 },
                new ClassAssignment { UserId = 11, SchoolId = 1, ClassId = 4 },
                new ClassAssignment { UserId = 12, SchoolId = 1, ClassId = 2 },
                new ClassAssignment { UserId = 13, SchoolId = 1, ClassId = 2 },
                new ClassAssignment { UserId = 14, SchoolId = 1, ClassId = 2 },
                new ClassAssignment { UserId = 12, SchoolId = 1, ClassId = 4 },
                new ClassAssignment { UserId = 13, SchoolId = 1, ClassId = 5 },
                new ClassAssignment { UserId = 14, SchoolId = 1, ClassId = 6 },
                new ClassAssignment { UserId = 9, SchoolId = 1, ClassId = 7 },
                new ClassAssignment { UserId = 12, SchoolId = 1, ClassId = 7 },
                new ClassAssignment { UserId = 13, SchoolId = 1, ClassId = 7 }
                );

            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<ClassAssignment> ClassAssignments { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<YearGroup> YearGroups { get; set; }


    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SchoolDataApplicationDbContext>
    {
        public SchoolDataApplicationDbContext CreateDbContext(string[] args)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../SchoolDataApplication/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<SchoolDataApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DevConnection");
            builder.UseSqlServer(connectionString);

            return new SchoolDataApplicationDbContext(builder.Options);
        }
    }
}
