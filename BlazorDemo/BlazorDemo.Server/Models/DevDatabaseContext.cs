using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Shared
{
    public partial class DevDatabaseContext : DbContext
    {
        public virtual DbSet<VisitorLogTable> VisitorLogTable { get; set; }

        public DevDatabaseContext(DbContextOptions<DevDatabaseContext> options)
         : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VisitorLogTable>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Company)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameofVisitor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeIn).HasColumnType("datetime");

                entity.Property(e => e.TimeOut).HasColumnType("datetime");

            });
        }
    }
}
