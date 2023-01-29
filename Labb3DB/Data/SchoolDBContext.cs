using System;
using System.Collections.Generic;
using Labb3DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Labb3DB.Data
{
    public partial class SchoolDBContext : DbContext
    {
        public SchoolDBContext()
        {
        }

        public SchoolDBContext(DbContextOptions<SchoolDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<ClassStudent> ClassStudents { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Faculty> Faculties { get; set; } = null!;
        public virtual DbSet<GetAverageGrade> GetAverageGrades { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<LastMonthGrade> LastMonthGrades { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentGrade> StudentGrades { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MIDGAR ;Initial Catalog=SchoolDB; Integrated Security = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.KlassId)
                    .HasName("PK__Classes__CF47A60DC72EA6C5");

                entity.Property(e => e.KlassId).HasColumnName("KlassID");

                entity.Property(e => e.KlassInriktning).HasMaxLength(50);

                entity.Property(e => e.KlassNamn).HasMaxLength(50);
            });

            modelBuilder.Entity<ClassStudent>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KlassId).HasColumnName("KlassID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Klass)
                    .WithMany(p => p.ClassStudents)
                    .HasForeignKey(d => d.KlassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClassStud__Klass__46E78A0C");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ClassStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClassStud__Stude__47DBAE45");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.KursId)
                    .HasName("PK__Courses__BCCFFF3B94116CE4");

                entity.Property(e => e.KursId).HasColumnName("KursID");

                entity.Property(e => e.KursBeskrivning).HasMaxLength(100);

                entity.Property(e => e.KursNamn).HasMaxLength(50);
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.ToTable("Faculty");

                entity.Property(e => e.FacultyId).HasColumnName("FacultyID");

                entity.Property(e => e.Adress).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fnamn)
                    .HasMaxLength(50)
                    .HasColumnName("FNamn");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.Lnamn)
                    .HasMaxLength(50)
                    .HasColumnName("LNamn");

                entity.Property(e => e.Telefonnummer).HasMaxLength(50);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Faculties)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK__Faculty__JobID__3B75D760");
            });

            modelBuilder.Entity<GetAverageGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetAverageGrades");

                entity.Property(e => e.KursBeskrivning).HasMaxLength(100);

                entity.Property(e => e.KursNamn).HasMaxLength(50);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.JobBeskrivning).HasMaxLength(100);

                entity.Property(e => e.JobNamn).HasMaxLength(50);
            });

            modelBuilder.Entity<LastMonthGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LastMonthGrades");

                entity.Property(e => e.Betyg).HasMaxLength(3);

                entity.Property(e => e.Fnamn)
                    .HasMaxLength(50)
                    .HasColumnName("FNamn");

                entity.Property(e => e.KursNamn).HasMaxLength(50);

                entity.Property(e => e.Lnamn)
                    .HasMaxLength(50)
                    .HasColumnName("LNamn");

                entity.Property(e => e.SattPåDatum).HasColumnType("date");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Adress).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fnamn)
                    .HasMaxLength(50)
                    .HasColumnName("FNamn");

                entity.Property(e => e.Lnamn)
                    .HasMaxLength(50)
                    .HasColumnName("LNamn");

                entity.Property(e => e.Telefonnummer).HasMaxLength(50);
            });

            modelBuilder.Entity<StudentGrade>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Betyg).HasMaxLength(3);

                entity.Property(e => e.FacultyId).HasColumnName("FacultyID");

                entity.Property(e => e.KursId).HasColumnName("KursID");

                entity.Property(e => e.SattPåDatum).HasColumnType("date");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.StudentGrades)
                    .HasForeignKey(d => d.FacultyId)
                    .HasConstraintName("FK__StudentGr__Facul__4222D4EF");

                entity.HasOne(d => d.Kurs)
                    .WithMany(p => p.StudentGrades)
                    .HasForeignKey(d => d.KursId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentGr__KursI__412EB0B6");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentGrades)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentGr__Stude__403A8C7D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
