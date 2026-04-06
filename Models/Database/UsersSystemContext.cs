using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lesson.Models.Database;

public partial class UsersSystemContext : DbContext
{
    public UsersSystemContext()
    {
    }

    public UsersSystemContext(DbContextOptions<UsersSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=;Database=UsersSystem;TrustserverCertificate=true;Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
