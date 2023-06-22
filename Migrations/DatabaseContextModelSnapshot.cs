﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace oopkr.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Models.Boller", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("consumptionPower")
                        .HasColumnType("int");

                    b.Property<int>("currentPower")
                        .HasColumnType("int");

                    b.Property<int>("generatePower")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Boller");
                });

            modelBuilder.Entity("Models.Day", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Day");
                });

            modelBuilder.Entity("Models.Hour", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Hour");
                });

            modelBuilder.Entity("Models.Log", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("Models.Month", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Month");
                });

            modelBuilder.Entity("Models.Plant", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("boillersCount")
                        .HasColumnType("int");

                    b.Property<int>("maxConsumptionPower")
                        .HasColumnType("int");

                    b.Property<int>("maxGeneratePower")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Plant");
                });

            modelBuilder.Entity("Models.PlantBoller", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("bollerId")
                        .HasColumnType("int");

                    b.Property<int>("currentPower")
                        .HasColumnType("int");

                    b.Property<int>("plantId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("bollerId");

                    b.HasIndex("plantId");

                    b.ToTable("PlantBoller");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Models.PlantBoller", b =>
                {
                    b.HasOne("Models.Boller", "boller")
                        .WithMany("plantBollers")
                        .HasForeignKey("bollerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Plant", "plant")
                        .WithMany("plantBollers")
                        .HasForeignKey("plantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("boller");

                    b.Navigation("plant");
                });

            modelBuilder.Entity("Models.Boller", b =>
                {
                    b.Navigation("plantBollers");
                });

            modelBuilder.Entity("Models.Plant", b =>
                {
                    b.Navigation("plantBollers");
                });
#pragma warning restore 612, 618
        }
    }
}
