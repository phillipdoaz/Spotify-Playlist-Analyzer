﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlaylistApi.Backend.Models;

namespace PlaylistApi.Backend.Migrations
{
    [DbContext(typeof(PlaylistDataContext))]
    [Migration("20190924210633_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PlaylistApi.Backend.Models.PlaylistModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("DanceabilityMax");

                    b.Property<double>("DanceabilityMin");

                    b.Property<double>("EnergyMax");

                    b.Property<double>("EnergyMin");

                    b.Property<string>("ExternalId");

                    b.Property<string>("HighestRatedTrackId");

                    b.Property<string>("LowestRatedTrackId");

                    b.Property<double>("Overall");

                    b.Property<double>("ValenceMax");

                    b.Property<double>("ValenceMin");

                    b.HasKey("Id");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("PlaylistApi.Backend.Models.TrackModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Artists");

                    b.Property<double>("Danceability");

                    b.Property<double>("Energy");

                    b.Property<string>("ExternalId");

                    b.Property<string>("Name");

                    b.Property<long?>("PlaylistModelId");

                    b.Property<int>("Popularity");

                    b.Property<string>("PreviewUrl");

                    b.Property<double>("Valence");

                    b.HasKey("Id");

                    b.HasIndex("PlaylistModelId");

                    b.ToTable("PlaylistTracks");
                });

            modelBuilder.Entity("PlaylistApi.Backend.Models.TrackModel", b =>
                {
                    b.HasOne("PlaylistApi.Backend.Models.PlaylistModel")
                        .WithMany("Tracks")
                        .HasForeignKey("PlaylistModelId");
                });
#pragma warning restore 612, 618
        }
    }
}
