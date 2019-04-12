using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tool.Calendar.Model
{
    public partial class CalendarBaseContext : DbContext
    {
        public CalendarBaseContext()
        {
        }

        public CalendarBaseContext(DbContextOptions<CalendarBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SysUser> SysUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=192.168.10.20;User Id=root;Password=!NotFind0bj;Database=CalendarBase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("Sys_User");

                entity.Property(e => e.UserId).HasColumnType("int(6)");

                entity.Property(e => e.UserCreateDate).HasColumnType("datetime");

                entity.Property(e => e.UserGuid)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.UserKey).HasColumnType("varchar(255)");

                entity.Property(e => e.UserName).HasColumnType("varchar(20)");

                entity.Property(e => e.UserPwd).HasColumnType("varchar(255)");
            });
        }
    }
}
