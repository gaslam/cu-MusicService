﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicService.API.Data;

namespace MusicService.API.Migrations
{
    [DbContext(typeof(MusicServiceContext))]
    [Migration("20200203210350_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MusicService.Domain.Models.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Album");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000001"),
                            Name = "What Grabs Ya?",
                            ReleaseDate = new DateTime(2008, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000001"),
                            Name = "Faders Up 2 - Live in Amsterdam",
                            ReleaseDate = new DateTime(2012, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000003"),
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000001"),
                            Name = "TF20 - VAULT",
                            ReleaseDate = new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000004"),
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000002"),
                            Name = "Back In Black",
                            ReleaseDate = new DateTime(1980, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000005"),
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000002"),
                            Name = "Highway to Hell",
                            ReleaseDate = new DateTime(1979, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000006"),
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000002"),
                            Name = "High Voltage",
                            ReleaseDate = new DateTime(1976, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000007"),
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000003"),
                            Name = "Nevermind",
                            ReleaseDate = new DateTime(1991, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000008"),
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000003"),
                            Name = "MTV Unplugged In New York",
                            ReleaseDate = new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000009"),
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000003"),
                            Name = "Live at Reading",
                            ReleaseDate = new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000010"),
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000004"),
                            Name = "Ocharme Ik",
                            ReleaseDate = new DateTime(2001, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000011"),
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000004"),
                            Name = "In De Fik",
                            ReleaseDate = new DateTime(2004, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000012"),
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000004"),
                            Name = "10 Jaar Flip Kowlier",
                            ReleaseDate = new DateTime(2011, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000013"),
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000005"),
                            Name = "Master Of Puppets",
                            ReleaseDate = new DateTime(1986, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000014"),
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000005"),
                            Name = "...And Justice For All",
                            ReleaseDate = new DateTime(1988, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000015"),
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000005"),
                            Name = "Metallica",
                            ReleaseDate = new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000016"),
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000005"),
                            Name = "Garage Inc.",
                            ReleaseDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000017"),
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000005"),
                            Name = "Hardwired...To Self-Destruct",
                            ReleaseDate = new DateTime(2016, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MusicService.Domain.Models.Artist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Followers")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artist");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            Followers = 143599L,
                            Name = "Triggerfinger"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            Followers = 14124193L,
                            Name = "AC/DC"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000003"),
                            Followers = 10222671L,
                            Name = "Nirvana"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000004"),
                            Followers = 12999L,
                            Name = "Flip Kowlier"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000005"),
                            Followers = 13031380L,
                            Name = "Metallica"
                        });
                });

            modelBuilder.Entity("MusicService.Domain.Models.ArtistGenre", b =>
                {
                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ArtistId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("ArtistGenres");

                    b.HasData(
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000001"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000007")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000001"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000008")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000001"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000009")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000002"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000010")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000002"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000011")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000002"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000012")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000002"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000002"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000004")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000003"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000012")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000003"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000013")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000003"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000014")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000003"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000015")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000003"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000004")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000004"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000007")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000004"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000016")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000004"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000017")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000004"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000018")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000005"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000005"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000002")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000005"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000003")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000005"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000004")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000005"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000005")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000005"),
                            GenreId = new Guid("00000000-0000-0000-0000-000000000006")
                        });
                });

            modelBuilder.Entity("MusicService.Domain.Models.ArtistImage", b =>
                {
                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ArtistId", "ImageId");

                    b.HasIndex("ImageId");

                    b.ToTable("ArtistImages");

                    b.HasData(
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000001"),
                            ImageId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000001"),
                            ImageId = new Guid("00000000-0000-0000-0000-000000000002")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000001"),
                            ImageId = new Guid("00000000-0000-0000-0000-000000000003")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000002"),
                            ImageId = new Guid("00000000-0000-0000-0000-000000000004")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000002"),
                            ImageId = new Guid("00000000-0000-0000-0000-000000000005")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000002"),
                            ImageId = new Guid("00000000-0000-0000-0000-000000000006")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000002"),
                            ImageId = new Guid("00000000-0000-0000-0000-000000000007")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000003"),
                            ImageId = new Guid("00000000-0000-0000-0000-000000000008")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000003"),
                            ImageId = new Guid("00000000-0000-0000-0000-000000000009")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000003"),
                            ImageId = new Guid("00000000-0000-0000-0000-000000000010")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000003"),
                            ImageId = new Guid("00000000-0000-0000-0000-000000000011")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000004"),
                            ImageId = new Guid("00000000-0000-0000-0000-000000000012")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000004"),
                            ImageId = new Guid("00000000-0000-0000-0000-000000000013")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000004"),
                            ImageId = new Guid("00000000-0000-0000-0000-000000000014")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000005"),
                            ImageId = new Guid("00000000-0000-0000-0000-000000000015")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000005"),
                            ImageId = new Guid("00000000-0000-0000-0000-000000000016")
                        },
                        new
                        {
                            ArtistId = new Guid("00000000-0000-0000-0000-000000000005"),
                            ImageId = new Guid("00000000-0000-0000-0000-000000000017")
                        });
                });

            modelBuilder.Entity("MusicService.Domain.Models.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            Name = "Hard rock"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            Name = "Metal"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000003"),
                            Name = "Old school trash"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000004"),
                            Name = "Rock"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000005"),
                            Name = "Speed metal"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000006"),
                            Name = "Trash metal"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000007"),
                            Name = "Belgian rock"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000008"),
                            Name = "Dutch indie"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000009"),
                            Name = "Dutch rock"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000010"),
                            Name = "Album rock"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000011"),
                            Name = "Australian rock"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000012"),
                            Name = "Alternative rock"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000013"),
                            Name = "Grunge"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000014"),
                            Name = "Permanent wave"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000015"),
                            Name = "Post-grunge"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000016"),
                            Name = "Classic belgian pop"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000017"),
                            Name = "Kleinkunst"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000018"),
                            Name = "West-vlaamse hip hop"
                        });
                });

            modelBuilder.Entity("MusicService.Domain.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Image");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            Height = 640,
                            Url = "https://i.scdn.co/image/b59c74329496a6256355648f005cffcf1fd76dc9",
                            Width = 640
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            Height = 320,
                            Url = "https://i.scdn.co/image/8df00a835ac66507a55b6572491750bd41c7278c",
                            Width = 320
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000003"),
                            Height = 160,
                            Url = "https://i.scdn.co/image/13fd1ee7b9f8d3b1ca57d086d6ed7c171d052eb4",
                            Width = 160
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000004"),
                            Height = 1500,
                            Url = "https://i.scdn.co/image/a16c5d95ede008ec905d6ca6d1b5abbf39ad4566",
                            Width = 1000
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000005"),
                            Height = 640,
                            Url = "https://i.scdn.co/image/fb26e1c0e5779ac46b225651494ac14b6b8ebba7",
                            Width = 1000
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000006"),
                            Height = 300,
                            Url = "https://i.scdn.co/image/3d00e92fb05c62e2faf2908b34e6f24e0a4cb213",
                            Width = 200
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000007"),
                            Height = 96,
                            Url = "https://i.scdn.co/image/2940421b19c6b8a26b073ef340290516ea0399e1",
                            Width = 64
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000008"),
                            Height = 1057,
                            Url = "https://i.scdn.co/image/84282c28d851a700132356381fcfbadc67ff498b",
                            Width = 1000
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000009"),
                            Height = 677,
                            Url = "https://i.scdn.co/image/a4e10b79a642e9891383448cbf37d7266a6883d6",
                            Width = 640
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000010"),
                            Height = 211,
                            Url = "https://i.scdn.co/image/42ae0f180f16e2f21c1f2212717fc436f5b95451",
                            Width = 200
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000011"),
                            Height = 68,
                            Url = "https://i.scdn.co/image/e797ad36d56c3fc8fa06c6fe91263a15bf8391b8",
                            Width = 64
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000012"),
                            Height = 640,
                            Url = "https://i.scdn.co/image/f51258ac754739045b0956cdb1f7a3332fc46754",
                            Width = 640
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000013"),
                            Height = 320,
                            Url = "https://i.scdn.co/image/b3897cc5dac721abe76fdf7c7266b3f9b51af73f",
                            Width = 320
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000014"),
                            Height = 160,
                            Url = "https://i.scdn.co/image/5bc9e60072958ace6e07fdd0c0dbeb65bd8764f3",
                            Width = 160
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000015"),
                            Height = 640,
                            Url = "https://i.scdn.co/image/5a06711d7fc48d5e0e3f9a3274ffed3f0af1bd91",
                            Width = 640
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000016"),
                            Height = 320,
                            Url = "https://i.scdn.co/image/0c22030833eb55c14013bb36eb6a429328868c29",
                            Width = 320
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000017"),
                            Height = 160,
                            Url = "https://i.scdn.co/image/c1fb4d88de092b5617e649bd4c406b5cab7d3ddd",
                            Width = 160
                        });
                });

            modelBuilder.Entity("MusicService.Domain.Models.Track", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("DurationMs")
                        .HasColumnType("bigint");

                    b.Property<bool>("Explicit")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TrackNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Track");
                });

            modelBuilder.Entity("MusicService.Domain.Models.Album", b =>
                {
                    b.HasOne("MusicService.Domain.Models.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MusicService.Domain.Models.ArtistGenre", b =>
                {
                    b.HasOne("MusicService.Domain.Models.Artist", "Artist")
                        .WithMany("ArtistGenres")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicService.Domain.Models.Genre", "Genre")
                        .WithMany("ArtistGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MusicService.Domain.Models.ArtistImage", b =>
                {
                    b.HasOne("MusicService.Domain.Models.Artist", "Artist")
                        .WithMany("ArtistImages")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicService.Domain.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MusicService.Domain.Models.Image", b =>
                {
                    b.HasOne("MusicService.Domain.Models.Album", null)
                        .WithMany("Images")
                        .HasForeignKey("AlbumId");
                });

            modelBuilder.Entity("MusicService.Domain.Models.Track", b =>
                {
                    b.HasOne("MusicService.Domain.Models.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("AlbumId");
                });
#pragma warning restore 612, 618
        }
    }
}
