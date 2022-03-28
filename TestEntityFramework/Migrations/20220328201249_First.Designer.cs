﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestEntityFramework.Models;

namespace TestEntityFramework.Migrations
{
    [DbContext(typeof(MunicipalDumaContext))]
    [Migration("20220328201249_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestEntityFramework.Models.FComission", b =>
                {
                    b.Property<int>("FComissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("f_comission")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(512)
                        .IsUnicode(false)
                        .HasColumnType("varchar(512)")
                        .HasColumnName("name");

                    b.HasKey("FComissionId")
                        .HasName("pk_f_comission");

                    b.ToTable("f_comission");
                });

            modelBuilder.Entity("TestEntityFramework.Models.FMeeting", b =>
                {
                    b.Property<int>("FMeetingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("f_meeting")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("date_time")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("FComission")
                        .HasColumnType("int")
                        .HasColumnName("f_comission");

                    b.Property<string>("Place")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("place");

                    b.HasKey("FMeetingId")
                        .HasName("pk_f_meeting");

                    b.HasIndex("FComission");

                    b.ToTable("f_meeting");
                });

            modelBuilder.Entity("TestEntityFramework.Models.FPerson", b =>
                {
                    b.Property<int>("FPersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("f_person")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone_number");

                    b.Property<string>("Surname")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("surname");

                    b.HasKey("FPersonId")
                        .HasName("pk_f_person");

                    b.ToTable("f_person");
                });

            modelBuilder.Entity("TestEntityFramework.Models.LComissionPerson", b =>
                {
                    b.Property<int>("LComissionPersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("l_comission_person")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateBegin")
                        .HasColumnType("datetime")
                        .HasColumnName("date_begin");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("datetime")
                        .HasColumnName("date_end");

                    b.Property<int>("FComission")
                        .HasColumnType("int")
                        .HasColumnName("f_comission");

                    b.Property<int>("FPerson")
                        .HasColumnType("int")
                        .HasColumnName("f_person");

                    b.Property<int?>("Stat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("stat")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("StatMain")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("stat_main")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("LComissionPersonId")
                        .HasName("pk_l_comission_person");

                    b.HasIndex("FComission");

                    b.HasIndex("FPerson");

                    b.ToTable("l_comission_person");
                });

            modelBuilder.Entity("TestEntityFramework.Models.LMeetingWork", b =>
                {
                    b.Property<int>("LMeetingWorkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("l_meeting_work")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FMeeting")
                        .HasColumnType("int")
                        .HasColumnName("f_meeting");

                    b.Property<int>("FPerson")
                        .HasColumnType("int")
                        .HasColumnName("f_person");

                    b.Property<bool>("IsAbsent")
                        .HasColumnType("bit")
                        .HasColumnName("isAbsent");

                    b.HasKey("LMeetingWorkId")
                        .HasName("pk_l_meeting_work");

                    b.HasIndex("FMeeting");

                    b.HasIndex("FPerson");

                    b.ToTable("l_meeting_work");
                });

            modelBuilder.Entity("TestEntityFramework.Models.FMeeting", b =>
                {
                    b.HasOne("TestEntityFramework.Models.FComission", "FComissionNavigation")
                        .WithMany("FMeetings")
                        .HasForeignKey("FComission")
                        .HasConstraintName("fk_f_meet_f_comission")
                        .IsRequired();

                    b.Navigation("FComissionNavigation");
                });

            modelBuilder.Entity("TestEntityFramework.Models.LComissionPerson", b =>
                {
                    b.HasOne("TestEntityFramework.Models.FComission", "FComissionNavigation")
                        .WithMany("LComissionPerson")
                        .HasForeignKey("FComission")
                        .HasConstraintName("fk_lcp_f_comission")
                        .IsRequired();

                    b.HasOne("TestEntityFramework.Models.FPerson", "FPersonNavigation")
                        .WithMany("LComissionPerson")
                        .HasForeignKey("FPerson")
                        .HasConstraintName("fk_lcp_f_person")
                        .IsRequired();

                    b.Navigation("FComissionNavigation");

                    b.Navigation("FPersonNavigation");
                });

            modelBuilder.Entity("TestEntityFramework.Models.LMeetingWork", b =>
                {
                    b.HasOne("TestEntityFramework.Models.FMeeting", "FMeetingNavigation")
                        .WithMany("LMeetingWorks")
                        .HasForeignKey("FMeeting")
                        .HasConstraintName("fk_l_meet_work_f_meeting")
                        .IsRequired();

                    b.HasOne("TestEntityFramework.Models.FPerson", "FPersonNavigation")
                        .WithMany("LMeetingWorks")
                        .HasForeignKey("FPerson")
                        .HasConstraintName("fk_l_meet_work_f_person")
                        .IsRequired();

                    b.Navigation("FMeetingNavigation");

                    b.Navigation("FPersonNavigation");
                });

            modelBuilder.Entity("TestEntityFramework.Models.FComission", b =>
                {
                    b.Navigation("FMeetings");

                    b.Navigation("LComissionPerson");
                });

            modelBuilder.Entity("TestEntityFramework.Models.FMeeting", b =>
                {
                    b.Navigation("LMeetingWorks");
                });

            modelBuilder.Entity("TestEntityFramework.Models.FPerson", b =>
                {
                    b.Navigation("LComissionPerson");

                    b.Navigation("LMeetingWorks");
                });
#pragma warning restore 612, 618
        }
    }
}
