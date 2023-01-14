﻿// <auto-generated />
using System;
using Assignment04_ProSE;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment04ProSE.Migrations
{
    [DbContext(typeof(KittyContext))]
    [Migration("20230114215358_ReviseParticipantMark")]
    partial class ReviseParticipantMark
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Assignment04_ProSE.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Assignment04_ProSE.Kitty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("GroupCost")
                        .HasColumnType("REAL");

                    b.Property<string>("HomeCurrency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Kitties");
                });

            modelBuilder.Entity("Assignment04_ProSE.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("KittyId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Mark")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Seen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<double>("Total")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("KittyId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("Assignment04_ProSE.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Purpose")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Assignment04_ProSE.Comment", b =>
                {
                    b.HasOne("Assignment04_ProSE.Participant", "Participant")
                        .WithMany("Comments")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("Assignment04_ProSE.Participant", b =>
                {
                    b.HasOne("Assignment04_ProSE.Kitty", "Kitty")
                        .WithMany("Pariticipants")
                        .HasForeignKey("KittyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kitty");
                });

            modelBuilder.Entity("Assignment04_ProSE.Payment", b =>
                {
                    b.HasOne("Assignment04_ProSE.Participant", "Participant")
                        .WithMany("Payments")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("Assignment04_ProSE.Kitty", b =>
                {
                    b.Navigation("Pariticipants");
                });

            modelBuilder.Entity("Assignment04_ProSE.Participant", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
