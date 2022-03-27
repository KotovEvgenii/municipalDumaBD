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
        public virtual DbSet<FPerson> FPeople { get; set; }
        public virtual DbSet<LComissionPerson> LComissionPeople { get; set; }
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
                entity.HasKey(e => e.FComission1)
                    .HasName("pk_f_comission");

                entity.ToTable("f_comission");

                entity.Property(e => e.FComission1).HasColumnName("f_comission");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<FMeeting>(entity =>
            {
                entity.HasKey(e => e.FMeeting1)
                    .HasName("pk_f_meeting");

                entity.ToTable("f_meeting");

                entity.Property(e => e.FMeeting1).HasColumnName("f_meeting");

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
                entity.HasKey(e => e.FPeople)
                    .HasName("pk_f_people");

                entity.ToTable("f_people");

                entity.Property(e => e.FPeople).HasColumnName("f_people");

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
                entity.HasKey(e => e.LComissionPeople)
                    .HasName("pk_l_comission_people");

                entity.ToTable("l_comission_people");

                entity.Property(e => e.LComissionPeople).HasColumnName("l_comission_people");

                entity.Property(e => e.DateBegin)
                    .HasColumnType("datetime")
                    .HasColumnName("date_begin");

                entity.Property(e => e.DateEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("date_end");

                entity.Property(e => e.FComission).HasColumnName("f_comission");

                entity.Property(e => e.FPeople).HasColumnName("f_people");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StatMain)
                    .HasColumnName("stat_main")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.FComissionNavigation)
                    .WithMany(p => p.LComissionPeople)
                    .HasForeignKey(d => d.FComission)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_lcp_f_comission");

                entity.HasOne(d => d.FPeopleNavigation)
                    .WithMany(p => p.LComissionPeople)
                    .HasForeignKey(d => d.FPeople)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_lcp_f_people");
            });

            modelBuilder.Entity<LMeetingWork>(entity =>
            {
                entity.HasKey(e => e.LMeetingWork1)
                    .HasName("pk_l_meeting_work");

                entity.ToTable("l_meeting_work");

                entity.Property(e => e.LMeetingWork1).HasColumnName("l_meeting_work");

                entity.Property(e => e.FMeeting).HasColumnName("f_meeting");

                entity.Property(e => e.FPeople).HasColumnName("f_people");

                entity.Property(e => e.IsAbsent).HasColumnName("isAbsent");

                entity.HasOne(d => d.FMeetingNavigation)
                    .WithMany(p => p.LMeetingWorks)
                    .HasForeignKey(d => d.FMeeting)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_l_meet_work_f_meeting");

                entity.HasOne(d => d.FPeopleNavigation)
                    .WithMany(p => p.LMeetingWorks)
                    .HasForeignKey(d => d.FPeople)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_l_meet_work_f_people");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
