using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCoreScaffoldexample.Models;

public partial class ShopWebContext : DbContext
{
    public ShopWebContext()
    {
    }

    public ShopWebContext(DbContextOptions<ShopWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersInfo> UsersInfos { get; set; }

    public virtual DbSet<UsersTest> UsersTests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-C5VQ52MM\\SQLEXPRESS01;Initial Catalog=Shop_Web;User ID=obraz;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRoles).HasName("ID_Roles");

            entity.Property(e => e.IdRoles).HasColumnName("ID_Roles");
            entity.Property(e => e.RolesName)
                .HasMaxLength(20)
                .HasColumnName("Roles_Name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUsers).HasName("ID_Users");

            entity.Property(e => e.IdUsers).HasColumnName("ID_Users");
            entity.Property(e => e.UsersEmail)
                .HasMaxLength(20)
                .HasColumnName("Users_Email");
            entity.Property(e => e.UsersLogin)
                .HasMaxLength(20)
                .HasColumnName("Users_Login");
            entity.Property(e => e.UsersPassword).HasColumnName("Users_Password");
            entity.Property(e => e.UsersStatus)
                .HasMaxLength(20)
                .HasColumnName("Users_Status");
        });

        modelBuilder.Entity<UsersInfo>(entity =>
        {
            entity.HasKey(e => e.UsersSId);

            entity.ToTable("UsersInfo");

            entity.Property(e => e.UsersSId)
                .ValueGeneratedNever()
                .HasColumnName("Users_S_ID");
            entity.Property(e => e.RolesId).HasColumnName("Roles_ID");
            entity.Property(e => e.UsersInfoDateBirthday)
                .HasColumnType("datetime")
                .HasColumnName("UsersInfo_DateBirthday");
            entity.Property(e => e.UsersInfoDateStartWork)
                .HasColumnType("datetime")
                .HasColumnName("UsersInfo_DateStartWork");
            entity.Property(e => e.UsersInfoDateStartWorkMpt)
                .HasColumnType("datetime")
                .HasColumnName("UsersInfo_DateStartWorkMPT");
            entity.Property(e => e.UsersInfoDateStartWorkTeacher)
                .HasColumnType("datetime")
                .HasColumnName("UsersInfo_DateStartWorkTeacher");
            entity.Property(e => e.UsersInfoFio).HasColumnName("UsersInfo_FIO");
            entity.Property(e => e.UsersInfoLastName)
                .HasMaxLength(50)
                .HasColumnName("UsersInfo_Last_Name");
            entity.Property(e => e.UsersInfoMiddleName)
                .HasMaxLength(50)
                .HasColumnName("UsersInfo_Middle_Name");
            entity.Property(e => e.UsersInfoName)
                .HasMaxLength(50)
                .HasColumnName("UsersInfo_Name");

            entity.HasOne(d => d.Roles).WithMany(p => p.UsersInfos)
                .HasForeignKey(d => d.RolesId)
                .HasConstraintName("Roles_ID");

            entity.HasOne(d => d.UsersS).WithOne(p => p.UsersInfo)
                .HasForeignKey<UsersInfo>(d => d.UsersSId)
                .HasConstraintName("Users_S_ID");
        });

        modelBuilder.Entity<UsersTest>(entity =>
        {
            entity.HasKey(e => e.IdUsersTest).HasName("ID_Users_Test");

            entity.ToTable("Users_Test");

            entity.Property(e => e.IdUsersTest).HasColumnName("ID_Users_Test");
            entity.Property(e => e.UsersIdTest).HasColumnName("Users_Id_test");

            entity.HasOne(d => d.UsersIdTestNavigation).WithMany(p => p.UsersTests)
                .HasForeignKey(d => d.UsersIdTest)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Users_Id_test");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
