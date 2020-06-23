using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiTeszt2.Models
{
    public partial class IoTServerDBContext : DbContext
    {
        public IoTServerDBContext()
        {
        }

        public IoTServerDBContext(DbContextOptions<IoTServerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DataMs> DataMs { get; set; }
        public virtual DbSet<DataSs> DataSs { get; set; }
        public virtual DbSet<Sensors> Sensors { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;database=IoTServerDB;Trusted_Connection=True;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataMs>(entity =>
            {
                entity.HasKey(e => e.DataId);

                entity.HasIndex(e => e.SensorId)
                    .HasName("IX_FK_SensorDataM");

                entity.Property(e => e.CoordX).IsRequired();

                entity.Property(e => e.CoordY).IsRequired();

                entity.Property(e => e.Date).IsRequired();

                entity.Property(e => e.Pm10).HasColumnName("PM10");

                entity.HasOne(d => d.Sensor)
                    .WithMany(p => p.DataMs)
                    .HasForeignKey(d => d.SensorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SensorDataM");
            });

            modelBuilder.Entity<DataSs>(entity =>
            {
                entity.HasKey(e => e.DataId);

                entity.HasIndex(e => e.SensorId)
                    .HasName("IX_FK_SensorData");

                entity.Property(e => e.Date).IsRequired();

                entity.Property(e => e.Pm10).HasColumnName("PM10");

                entity.HasOne(d => d.Sensor)
                    .WithMany(p => p.DataSs)
                    .HasForeignKey(d => d.SensorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SensorData");
            });

            modelBuilder.Entity<Sensors>(entity =>
            {
                entity.HasKey(e => e.SensorId);

                entity.Property(e => e.CoordX).IsRequired();

                entity.Property(e => e.CoordY).IsRequired();

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("IP");

                entity.Property(e => e.Name).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
