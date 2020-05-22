using Antlr.Runtime.Misc;

namespace NewStudentManagementApp2WebAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudentManagementaApp2Model : DbContext
    {
        public StudentManagementaApp2Model()
            : base("name=StudentManagementaApp2Model")
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Campu> Campus { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Programme> Programmes { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Student_Programme> Student_Programme { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.School_Email)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Campu>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Campu>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Campu>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Campu>()
                .HasMany(e => e.Programmes)
                .WithMany(e => e.Campus)
                .Map(m => m.ToTable("Campus-Programme").MapLeftKey("Campus_Id").MapRightKey("Programme_Id"));

            modelBuilder.Entity<Exam>()
                .HasMany(e => e.Grades)
                .WithRequired(e => e.Exam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Programme>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Programme>()
                .HasMany(e => e.Exams)
                .WithRequired(e => e.Programme)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Background)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Grades)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.School_Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
