using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PracticeNotebook.EF.Entity;
using PracticeNotebook.EF.Helpers;

namespace PracticeNotebook.EF.Data
{
    public partial class DemoContext : DbContext
    {
        // Define logger factory
        
        public DemoContext()
        {
        }

        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var loggerFactory = new LoggerFactory();
                loggerFactory.AddProvider(new EfLoggerProvider());
                optionsBuilder.UseLoggerFactory(loggerFactory).UseSqlServer("Server=127.0.0.1,1433;Database=Demo;User=sa;Password=MSSQLserver$666;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Dname)
                    .HasColumnName("DName")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sname)
                    .IsRequired()
                    .HasColumnName("SName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Student__Departm__4AB81AF0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
