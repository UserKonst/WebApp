using Microsoft.EntityFrameworkCore;

namespace WebApplicationLogin.Models;

public partial class ApplicationDbContext : DbContext
    {
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UId).HasName("PK__users__");

            entity.ToTable("users");

            entity.Property(e => e.UId).HasColumnName("u_id");
            entity.Property(e => e.UEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("u_email");
            entity.Property(e => e.UKey)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("u_key");
            entity.Property(e => e.UName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("u_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}