using DemoAttendenceFeature.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolApp.API.Entities;

namespace DemoAttendenceFeature.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Student> students { get; set; }
        public DbSet<Guardian> guardians { get; set; }
        public DbSet<Attendence> attendences { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<StudentAdmissionStatus> studentAdmissionStatus { get; set; }
        public DbSet<ClassesSections> ClassesSections { get; set; } // Add this DbSet


        public DbSet<Sections> sections { get; set; }
        public DbSet<Classes> classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //many to many relation between Student and Guardians
            modelBuilder.Entity<Student>()
             .HasMany(s => s.Guardians)
             .WithMany(c => c.Students)
             .UsingEntity<Dictionary<string, object>>(
                 "StudentCourse",
                 j => j
                     .HasOne<Guardian>()
                     .WithMany()
                     .HasForeignKey("GuardianId"),
                 j => j
                     .HasOne<Student>()
                     .WithMany()
                     .HasForeignKey("StudentId").OnDelete(DeleteBehavior.Cascade),
                 j =>
                 {
                     j.HasKey("StudentId", "GuardianId");
                     j.ToTable("StudentGurdians");
                 });

            modelBuilder.Entity<Classes>()
            .HasMany(c => c.Sections)
            .WithMany(s => s.Classes)
            .UsingEntity<ClassesSections>(
                j => j
                    .HasOne(cs => cs.Section)
                    .WithMany()
                    .HasForeignKey(cs => cs.SectionId),
                j => j
                    .HasOne(cs => cs.Class)
                    .WithMany()
                    .HasForeignKey(cs => cs.ClassId)
                    .OnDelete(DeleteBehavior.Restrict),
                j =>
                {
                    j.HasKey(cs => new { cs.ClassId, cs.SectionId });
                    j.Property(cs => cs.Capacity);
                });

            modelBuilder.Entity<Classes>()
                .HasOne(x => x.Department)
                .WithMany(x => x.classes)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
            

            modelBuilder.Entity<Attendence>()
                .HasOne(x => x.Student)
                .WithMany(x => x.Attendences)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentAdmissionStatus>()
                .HasOne(x => x.Student)
                .WithOne(x => x.AdmissionStatus)
                .HasForeignKey<StudentAdmissionStatus>(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentEmergencyContactInfo>()
                .HasOne(x => x.Student)
                .WithOne(x => x.StudentEmergencyContactInfo)
                .HasForeignKey<StudentEmergencyContactInfo>(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentEducationInfo>()
                .HasOne(x => x.Student)
                .WithOne(x => x.StudentEducationInfo)
                .HasForeignKey<StudentEducationInfo>(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentMedicalInfo>()
               .HasOne(x => x.Student)
               .WithOne(x => x.StudentMedicalInfo)
               .HasForeignKey<StudentMedicalInfo>(x => x.StudentId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "PrePrimary" },
            new Department { Id = 2, Name = "Primary" },
            new Department { Id = 3, Name = "Secondary" }
        );
            base.OnModelCreating(modelBuilder);

            var adminRoleid = "bf0acce0 - d5be - 42cc - a5eb - 71dec7688180";
            var roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id = adminRoleid,
                    Name = "Admin",
                    ConcurrencyStamp = adminRoleid,
                    NormalizedName = "Admin".ToUpper()
                }

            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);


        }
    }
}
