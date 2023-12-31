﻿// <auto-generated />
using System;
using EDIWalks.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EDIWalks.Migrations
{
    [DbContext(typeof(EDIWalksDbContext))]
    partial class EDIWalksDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EDIWalks.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b00305b1-a91c-4b1a-ae80-da02bab22205"),
                            Code = "ESY",
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("fe95adbf-afe9-4704-ab14-a8407d70f40a"),
                            Code = "HRD",
                            Name = "Hard"
                        },
                        new
                        {
                            Id = new Guid("a40e2a92-05ae-4fc9-8382-883f12a0fe6d"),
                            Code = "NRL",
                            Name = "Normal"
                        });
                });

            modelBuilder.Entity("EDIWalks.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("06dd9b35-5b29-458d-9683-86df17ddfd42"),
                            Code = "EDI",
                            Name = "Edinburgh"
                        },
                        new
                        {
                            Id = new Guid("83841134-708a-430f-b4fa-00c1bd678773"),
                            Code = "LIV",
                            Name = "Livingston"
                        },
                        new
                        {
                            Id = new Guid("3438ff32-5b2d-4224-a3c0-a86e235bcccc"),
                            Code = "IOK",
                            Name = "Isle of Key"
                        },
                        new
                        {
                            Id = new Guid("ee0100bd-e0e4-4448-82ff-85d3042ef5d6"),
                            Code = "GLW",
                            Name = "Glasgow"
                        });
                });

            modelBuilder.Entity("EDIWalks.Models.Domain.Walks", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LongInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("EDIWalks.Models.Domain.Walks", b =>
                {
                    b.HasOne("EDIWalks.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDIWalks.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
