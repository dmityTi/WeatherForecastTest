﻿// <auto-generated />
using System;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(WeatherContext))]
    [Migration("20190902184235_InitTestForecasrDB")]
    partial class InitTestForecasrDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Infrastructure.Data.Entities.CityEntity", b =>
                {
                    b.Property<long>("Id");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<decimal>("Latitude");

                    b.Property<decimal>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.DailyWeatherForecastEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CityId");

                    b.Property<DateTime>("DateTime");

                    b.Property<Guid>("PrecipitationSpanId");

                    b.Property<decimal>("Pressure");

                    b.Property<decimal>("Temperature");

                    b.HasKey("Id");

                    b.HasIndex("CityId")
                        .IsUnique();

                    b.HasIndex("PrecipitationSpanId")
                        .IsUnique();

                    b.ToTable("WeatherForecasts");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.PrecipitationSpanEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndPrecip");

                    b.Property<int>("PrecipType");

                    b.Property<DateTime>("StartPrecip");

                    b.HasKey("Id");

                    b.ToTable("PrecipitationSpans");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.DailyWeatherForecastEntity", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.CityEntity", "City")
                        .WithOne()
                        .HasForeignKey("Infrastructure.Data.Entities.DailyWeatherForecastEntity", "CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Infrastructure.Data.Entities.PrecipitationSpanEntity", "PrecipitationSpan")
                        .WithOne()
                        .HasForeignKey("Infrastructure.Data.Entities.DailyWeatherForecastEntity", "PrecipitationSpanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}