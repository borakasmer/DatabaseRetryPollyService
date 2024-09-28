using System;
using System.Collections.Generic;
using LinqToDBBlog.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinqToDBBlog.Entities.DbContexts;

//dotnet ef dbcontext scaffold "Data Source=192.168.50.173;Initial Catalog=ABYS_PROD;Persist Security Info=True;User ID=sa;Password=AspNet55;pooling=True;min pool size=0;max pool size=100;MultipleActiveResultSets=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Entities --context-dir "Entities\DbContexts" --no-pluralize -c DashboardContext -f --no-build

public partial class DashboardContext : DbContext
{
    public DashboardContext()
    {
    }

    public DashboardContext(DbContextOptions<DashboardContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DbSecurityRole> DbSecurityRole { get; set; }

    public virtual DbSet<DbSecurityUserAction> DbSecurityUserAction { get; set; }

    public virtual DbSet<DbSecurityUserRole> DbSecurityUserRole { get; set; }

    public virtual DbSet<DbUser> DbUser { get; set; }

    public virtual DbSet<DbUser2> DbUser2 { get; set; }

    public virtual DbSet<DbUser2017> DbUser2017 { get; set; }

    public virtual DbSet<DbUser2018> DbUser2018 { get; set; }

    public virtual DbSet<DbUser2019> DbUser2019 { get; set; }


    public virtual DbSet<UserSwagger> UserSwagger { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=192.168.50.173;Initial Catalog=ABYS_PROD;Persist Security Info=True;User ID=sa;Password=AspNet55;pooling=True;min pool size=0;max pool size=100;MultipleActiveResultSets=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbSecurityRole>(entity =>
        {
            entity.HasKey(e => e.IdSecurityRole);

            entity.ToTable("DB_SECURITY_ROLE");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModDate).HasColumnType("datetime");
            entity.Property(e => e.SecurityRoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<DbSecurityUserAction>(entity =>
        {
            entity.HasKey(e => e.IdSecurityUserAction);

            entity.ToTable("DB_SECURITY_USER_ACTION");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Deleted).HasDefaultValue(false);
            entity.Property(e => e.ModDate).HasColumnType("datetime");          

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.DbSecurityUserAction)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_DB_SECURITY_USER_ACTION_DB_USER");
        });

        modelBuilder.Entity<DbSecurityUserRole>(entity =>
        {
            entity.HasKey(e => e.IdSecurityUserRole);

            entity.ToTable("DB_SECURITY_USER_ROLE");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Deleted).HasDefaultValue(false);
            entity.Property(e => e.ModDate).HasColumnType("datetime");           

            entity.HasOne(d => d.IdSecurityRoleNavigation).WithMany(p => p.DbSecurityUserRole)
                .HasForeignKey(d => d.IdSecurityRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DB_SECURITY_USER_ROLE_DB_SECURITY_ROLE");
        });

        modelBuilder.Entity<DbUser>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("DB_USER");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gsm)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin).HasDefaultValue(false);
            entity.Property(e => e.IsRoleLock).HasDefaultValue(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSecurityRoleNavigation).WithMany(p => p.DbUser)
                .HasForeignKey(d => d.IdSecurityRole)
                .HasConstraintName("FK_DB_USER_DB_SECURITY_ROLE");
        });

        modelBuilder.Entity<DbUser2>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("DB_USER2");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gsm)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin).HasDefaultValue(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSecurityRoleNavigation).WithMany(p => p.DbUser2)
                .HasForeignKey(d => d.IdSecurityRole)
                .HasConstraintName("FK_DB_USER2_DB_SECURITY_ROLE");
        });

        modelBuilder.Entity<DbUser2017>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("DB_USER2017");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gsm)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin).HasDefaultValue(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSecurityRoleNavigation).WithMany(p => p.DbUser2017)
                .HasForeignKey(d => d.IdSecurityRole)
                .HasConstraintName("FK_DB_USER2017_DB_SECURITY_ROLE");
        });

        modelBuilder.Entity<DbUser2018>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("DB_USER2018");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gsm)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin).HasDefaultValue(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSecurityRoleNavigation).WithMany(p => p.DbUser2018)
                .HasForeignKey(d => d.IdSecurityRole)
                .HasConstraintName("FK_DB_USER2018_DB_SECURITY_ROLE");
        });

        modelBuilder.Entity<DbUser2019>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("DB_USER2019");

            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.ClientIp).HasMaxLength(50);
            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gsm)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin).HasDefaultValue(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSecurityRoleNavigation).WithMany(p => p.DbUser2019)
                .HasForeignKey(d => d.IdSecurityRole)
                .HasConstraintName("FK_DB_USER2019_DB_SECURITY_ROLE");
        });

        modelBuilder.Entity<UserSwagger>(entity =>
        {
            entity.ToTable("USER_SWAGGER");

            entity.Property(e => e.CreDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");           

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserSwagger)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER_SWAGGER_DB_USER");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
