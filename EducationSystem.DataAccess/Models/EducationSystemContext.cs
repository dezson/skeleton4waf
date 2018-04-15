using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EducationSystem.DataAccess.Models
{
    public partial class EducationSystemContext : DbContext
    {
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseRecord> CourseRecord { get; set; }
        public virtual DbSet<Program> Program { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        public EducationSystemContext(DbContextOptions<EducationSystemContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.HasIndex(e => e.CourseCode)
                    .HasName("UQ__course__AB6B45F194F1FD28")
                    .IsUnique();

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.CourseCode)
                    .IsRequired()
                    .HasColumnName("course_code")
                    .HasMaxLength(30);

                entity.Property(e => e.Seats).HasColumnName("seats");

                entity.Property(e => e.StartDay).HasColumnName("start_day");

                entity.Property(e => e.StartTime).HasColumnName("start_time");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_course_subject");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_course_teacher");
            });

            modelBuilder.Entity<CourseRecord>(entity =>
            {
                entity.ToTable("course_record");

                entity.Property(e => e.CourseRecordId).HasColumnName("course_record_id");

                entity.Property(e => e.ApplyTime)
                    .HasColumnName("apply_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseRecord)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_course_record_course");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.CourseRecord)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_course_record_student");
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.ToTable("program");

                entity.Property(e => e.ProgramId).HasColumnName("program_id");

                entity.Property(e => e.ProgramName)
                    .IsRequired()
                    .HasColumnName("program_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(128);

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasColumnName("student_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("subject");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.ProgramId).HasColumnName("program_id");

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasColumnName("subject_name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.ProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_subject_program");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teacher");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(128);

                entity.Property(e => e.TeacherName)
                    .IsRequired()
                    .HasColumnName("teacher_name")
                    .HasMaxLength(50);
            });
        }
    }
}
