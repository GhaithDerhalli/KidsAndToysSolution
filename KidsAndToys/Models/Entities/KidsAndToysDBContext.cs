﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KidsAndToys.Models.Entities
{
    public partial class KidsAndToysDBContext : DbContext
    {
        public KidsAndToysDBContext()
        {
        }

        public KidsAndToysDBContext(DbContextOptions<KidsAndToysDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Age> Ages { get; set; } = null!;
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Condition> Conditions { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Age>(entity =>
            {
                entity.HasIndex(e => e.Title, "UQ__tmp_ms_x__2CB664DC14476476")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.Title, "UQ__Categori__2CB664DC6EED2C6D")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasIndex(e => e.Title, "UQ__Cities__2CB664DC4A1BB6F2")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Condition>(entity =>
            {
                entity.HasIndex(e => e.Title, "UQ__Conditio__2CB664DCB8893EBA")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.AdsPic).IsUnicode(false);

                entity.Property(e => e.ConditionDescription).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.Age)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.AgeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__AgeId__74AE54BC");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__Catego__75A278F5");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__CityId__7E37BEF6");

                entity.HasOne(d => d.Condition)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ConditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__Condit__7D439ABD");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__UserId__73BA3083");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePic).IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__Id__76969D2E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
