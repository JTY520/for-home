using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ForHouseEntity.Models
{
    public partial class ForHouseContext : DbContext
    {
        public ForHouseContext()
        {
        }

        public ForHouseContext(DbContextOptions<ForHouseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CharacteristicTable> CharacteristicTable { get; set; }
        public virtual DbSet<CommentTable> CommentTable { get; set; }
        public virtual DbSet<ComplainTable> ComplainTable { get; set; }
        public virtual DbSet<FeelOfHouse> FeelOfHouse { get; set; }
        public virtual DbSet<HouseTable> HouseTable { get; set; }
        public virtual DbSet<OrderTable> OrderTable { get; set; }
        public virtual DbSet<UserTable> UserTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-T08U97P;Initial Catalog=ForHouse;User ID=sa;Password=jtyjty520");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacteristicTable>(entity =>
            {
                entity.HasKey(e => e.CharacteristicId);

                entity.Property(e => e.CharacteristicName)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<CommentTable>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.Property(e => e.CommentContent)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CommentTime).HasColumnType("date");

                entity.Property(e => e.DeleteReason)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ComplainTable>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.HouseId });

                entity.Property(e => e.ComplainReason)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FeelOfHouse>(entity =>
            {
                entity.HasKey(e => new { e.HouseId, e.UserId });
            });

            modelBuilder.Entity<HouseTable>(entity =>
            {
                entity.HasKey(e => e.HouseId);

                entity.Property(e => e.HouseId).ValueGeneratedNever();

                entity.Property(e => e.HouseMoney).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.HousePlace).HasMaxLength(50);

                entity.Property(e => e.HouseSummary).HasMaxLength(100);

                entity.Property(e => e.PublicTime).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<OrderTable>(entity =>
            {
                entity.HasKey(e => new { e.HouseId, e.UserId });

                entity.Property(e => e.ContactWay)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderCreateTime).HasColumnType("date");

                entity.Property(e => e.OrderPlace)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OrderTime).HasColumnType("date");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserAccount)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserMail).HasMaxLength(20);

                entity.Property(e => e.UserNickName).HasMaxLength(10);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.UserPhone).HasMaxLength(11);
            });
        }
    }
}
