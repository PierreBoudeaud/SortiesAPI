﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190228125455_FixWeather4")]
    partial class FixWeather4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BO.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<float>("Latitude");

                    b.Property<float>("Longitude");

                    b.Property<string>("Name");

                    b.Property<string>("PostalCode");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("BO.Excursion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ActivityId");

                    b.Property<Guid?>("CreatorId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Name");

                    b.Property<int>("NbPlaces");

                    b.Property<Guid?>("WeatherId");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("WeatherId");

                    b.ToTable("Excursions");
                });

            modelBuilder.Entity("BO.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("BO.PersonsExcursions", b =>
                {
                    b.Property<Guid>("ExcursionId");

                    b.Property<Guid>("PersonId");

                    b.HasKey("ExcursionId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonsExcursions");
                });

            modelBuilder.Entity("BO.Weather", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Humidity");

                    b.Property<string>("Icon");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<int>("Pression");

                    b.Property<DateTime>("Sunrise");

                    b.Property<DateTime>("Sunset");

                    b.Property<double>("Temperature");

                    b.Property<double>("WindSpeed");

                    b.HasKey("Id");

                    b.ToTable("Weather");
                });

            modelBuilder.Entity("BO.Excursion", b =>
                {
                    b.HasOne("BO.Activity", "Activity")
                        .WithMany("Excursions")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BO.Person", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("BO.Weather", "Weather")
                        .WithMany()
                        .HasForeignKey("WeatherId");
                });

            modelBuilder.Entity("BO.PersonsExcursions", b =>
                {
                    b.HasOne("BO.Excursion", "Excursion")
                        .WithMany("SubscribePeople")
                        .HasForeignKey("ExcursionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BO.Person", "Person")
                        .WithMany("SubExcursions")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
