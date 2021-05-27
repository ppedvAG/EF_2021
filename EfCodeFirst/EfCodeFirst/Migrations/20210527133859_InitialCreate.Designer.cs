﻿// <auto-generated />
using System;
using EfCodeFirst.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfCodeFirst.Migrations
{
    [DbContext(typeof(EfContext))]
    [Migration("20210527133859_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AbteilungMitarbeiter", b =>
                {
                    b.Property<int>("AbteilungenId")
                        .HasColumnType("int");

                    b.Property<int>("MitarbeiterId")
                        .HasColumnType("int");

                    b.HasKey("AbteilungenId", "MitarbeiterId");

                    b.HasIndex("MitarbeiterId");

                    b.ToTable("AbteilungMitarbeiter");
                });

            modelBuilder.Entity("EfCodeFirst.Model.Abteilung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bezeichnung")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)")
                        .HasColumnName("DepName");

                    b.HasKey("Id");

                    b.ToTable("Abteilungen");
                });

            modelBuilder.Entity("EfCodeFirst.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("GebDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("EfCodeFirst.Model.Kunde", b =>
                {
                    b.HasBaseType("EfCodeFirst.Model.Person");

                    b.Property<string>("Kundennummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MitarbeiterId")
                        .HasColumnType("int");

                    b.HasIndex("MitarbeiterId");

                    b.ToTable("Kunde");
                });

            modelBuilder.Entity("EfCodeFirst.Model.Mitarbeiter", b =>
                {
                    b.HasBaseType("EfCodeFirst.Model.Person");

                    b.Property<string>("Beruf")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Mitarbeiter");
                });

            modelBuilder.Entity("AbteilungMitarbeiter", b =>
                {
                    b.HasOne("EfCodeFirst.Model.Abteilung", null)
                        .WithMany()
                        .HasForeignKey("AbteilungenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCodeFirst.Model.Mitarbeiter", null)
                        .WithMany()
                        .HasForeignKey("MitarbeiterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfCodeFirst.Model.Kunde", b =>
                {
                    b.HasOne("EfCodeFirst.Model.Person", null)
                        .WithOne()
                        .HasForeignKey("EfCodeFirst.Model.Kunde", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("EfCodeFirst.Model.Mitarbeiter", "Mitarbeiter")
                        .WithMany("Kunden")
                        .HasForeignKey("MitarbeiterId");

                    b.Navigation("Mitarbeiter");
                });

            modelBuilder.Entity("EfCodeFirst.Model.Mitarbeiter", b =>
                {
                    b.HasOne("EfCodeFirst.Model.Person", null)
                        .WithOne()
                        .HasForeignKey("EfCodeFirst.Model.Mitarbeiter", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfCodeFirst.Model.Mitarbeiter", b =>
                {
                    b.Navigation("Kunden");
                });
#pragma warning restore 612, 618
        }
    }
}
