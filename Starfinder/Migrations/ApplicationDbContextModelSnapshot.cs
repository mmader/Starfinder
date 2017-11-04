﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Starfinder.Controllers;
using System;

namespace Starfinder.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Starfinder.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AvatarPath");

                    b.Property<int?>("ClassId");

                    b.Property<int>("Constitution");

                    b.Property<int>("Dexterity");

                    b.Property<int>("Intelligence");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<int?>("RaceId");

                    b.Property<int>("Strength");

                    b.Property<int>("Wisdom");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("RaceId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Starfinder.Models.CharacterClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Starfinder.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("Starfinder.Models.Character", b =>
                {
                    b.HasOne("Starfinder.Models.CharacterClass", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("Starfinder.Models.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId");
                });
#pragma warning restore 612, 618
        }
    }
}
