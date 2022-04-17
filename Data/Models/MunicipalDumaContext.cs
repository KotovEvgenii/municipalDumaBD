using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestEntityFramework.Models
{
    public partial class MunicipalDumaContext : DbContext
    {
        public MunicipalDumaContext()
        {
        }

        public MunicipalDumaContext(DbContextOptions<MunicipalDumaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FComission> FComissions { get; set; }
        public virtual DbSet<FMeeting> FMeetings { get; set; }
        public virtual DbSet<FPerson> FPerson { get; set; }
        public virtual DbSet<LComissionPerson> LComissionPerson { get; set; }
        public virtual DbSet<LMeetingWork> LMeetingWorks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-SN5T4D0;Database=MunicipalDuma;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<FComission>(entity =>
            {
                entity.HasKey(e => e.FComissionId)
                    .HasName("pk_f_comission");

                entity.ToTable("f_comission");

                entity.Property(e => e.FComissionId).HasColumnName("f_comission");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<FMeeting>(entity =>
            {
                entity.HasKey(e => e.FMeetingId)
                    .HasName("pk_f_meeting");

                entity.ToTable("f_meeting");

                entity.Property(e => e.FMeetingId).HasColumnName("f_meeting");

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("date_time")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FComission).HasColumnName("f_comission");

                entity.Property(e => e.Place)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("place");

                entity.HasOne(d => d.FComissionNavigation)
                    .WithMany(p => p.FMeetings)
                    .HasForeignKey(d => d.FComission)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_f_meet_f_comission");
            });

            modelBuilder.Entity<FPerson>(entity =>
            {
                entity.HasKey(e => e.FPersonId)
                    .HasName("pk_f_person");

                entity.ToTable("f_person");

                entity.Property(e => e.FPersonId).HasColumnName("f_person");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Surname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<LComissionPerson>(entity =>
            {
                entity.HasKey(e => e.LComissionPersonId)
                    .HasName("pk_l_comission_person");

                entity.ToTable("l_comission_person");

                entity.Property(e => e.LComissionPersonId).HasColumnName("l_comission_person");

                entity.Property(e => e.DateBegin)
                    .HasColumnType("datetime")
                    .HasColumnName("date_begin");

                entity.Property(e => e.DateEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("date_end");

                entity.Property(e => e.FComission).HasColumnName("f_comission");

                entity.Property(e => e.FPerson).HasColumnName("f_person");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StatMain)
                    .HasColumnName("stat_main")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.FComissionNavigation)
                    .WithMany(p => p.LComissionPerson)
                    .HasForeignKey(d => d.FComission)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_lcp_f_comission");

                entity.HasOne(d => d.FPersonNavigation)
                    .WithMany(p => p.LComissionPerson)
                    .HasForeignKey(d => d.FPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_lcp_f_person");
            });

            modelBuilder.Entity<LMeetingWork>(entity =>
            {
                entity.HasKey(e => e.LMeetingWorkId)
                    .HasName("pk_l_meeting_work");

                entity.ToTable("l_meeting_work");

                entity.Property(e => e.LMeetingWorkId).HasColumnName("l_meeting_work");

                entity.Property(e => e.FMeeting).HasColumnName("f_meeting");

                entity.Property(e => e.FPerson).HasColumnName("f_person");

                entity.Property(e => e.IsAbsent).HasColumnName("isAbsent");

                entity.HasOne(d => d.FMeetingNavigation)
                    .WithMany(p => p.LMeetingWorks)
                    .HasForeignKey(d => d.FMeeting)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_l_meet_work_f_meeting");

                entity.HasOne(d => d.FPersonNavigation)
                    .WithMany(p => p.LMeetingWorks)
                    .HasForeignKey(d => d.FPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_l_meet_work_f_person");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
