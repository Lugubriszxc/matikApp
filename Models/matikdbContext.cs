using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace matikApp.Models
{
    public partial class matikdbContext : DbContext
    {
        public matikdbContext()
        {
        }

        public matikdbContext(DbContextOptions<matikdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignsubject> Assignsubjects { get; set; }
        public virtual DbSet<Authorization> Authorizations { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Dean> Deans { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=matikdb;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.24-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Assignsubject>(entity =>
            {
                entity.HasKey(e => e.AId)
                    .HasName("PRIMARY");

                entity.ToTable("assignsubject");

                entity.Property(e => e.AId)
                    .HasColumnType("int(11)")
                    .HasColumnName("a_id");

                entity.Property(e => e.AClassId)
                    .HasColumnType("int(11)")
                    .HasColumnName("a_classID");

                entity.Property(e => e.AInstructorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("a_instructorID");

                entity.Property(e => e.ASemester)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("a_semester");

                entity.Property(e => e.ASubjectId)
                    .HasColumnType("int(11)")
                    .HasColumnName("a_subjectID");
            });

            modelBuilder.Entity<Authorization>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("authorization");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("userID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("password");

                entity.Property(e => e.UserType)
                    .HasColumnType("int(11)")
                    .HasColumnName("userType");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("building");

                entity.Property(e => e.BuildingId)
                    .HasColumnType("int(11)")
                    .HasColumnName("buildingID");

                entity.Property(e => e.BuildingName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("buildingName");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.CourseId)
                    .HasColumnType("int(11)")
                    .HasColumnName("courseID");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("courseName");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("departmentID");
            });

            modelBuilder.Entity<Dean>(entity =>
            {
                entity.ToTable("dean");

                entity.Property(e => e.DeanId)
                    .HasColumnType("int(11)")
                    .HasColumnName("deanID");

                entity.Property(e => e.DeanFname)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("dean_fname");

                entity.Property(e => e.DeanLname)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("dean_lname");

                entity.Property(e => e.DeanMname)
                    .HasMaxLength(250)
                    .HasColumnName("dean_mname");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("departmentID");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("departmentID");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("departmentName");
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.ToTable("instructor");

                entity.Property(e => e.InstructorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("instructorID");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("departmentID");

                entity.Property(e => e.InstructorFname)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("instructor_fname");

                entity.Property(e => e.InstructorLname)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("instructor_lname");

                entity.Property(e => e.InstructorMname)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("instructor_mname");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("room");

                entity.Property(e => e.RoomId)
                    .HasColumnType("int(11)")
                    .HasColumnName("roomID");

                entity.Property(e => e.BuildingId)
                    .HasColumnType("int(11)")
                    .HasColumnName("buildingID");

                entity.Property(e => e.RoomCapacity)
                    .HasColumnType("int(11)")
                    .HasColumnName("roomCapacity");

                entity.Property(e => e.RoomName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("roomName");

                entity.Property(e => e.RoomType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("roomType");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("section");

                entity.Property(e => e.SectionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("sectionID");

                entity.Property(e => e.CourseId)
                    .HasColumnType("int(11)")
                    .HasColumnName("courseID");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("departmentID");

                entity.Property(e => e.SectionName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("sectionName");

                entity.Property(e => e.YearLevel)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("yearLevel");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("subject");

                entity.Property(e => e.SubjectId)
                    .HasColumnType("int(11)")
                    .HasColumnName("subjectID");

                entity.Property(e => e.SubjectCode)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("subjectCode");

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("subjectName");

                entity.Property(e => e.SubjectUnit)
                    .HasColumnType("int(11)")
                    .HasColumnName("subjectUnit");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
