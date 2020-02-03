using Microsoft.EntityFrameworkCore;
using MusicService.Domain.Models;
using System;

namespace MusicService.API.Data
{
    public class MusicServiceContext : DbContext
    {
        public MusicServiceContext(DbContextOptions<MusicServiceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //configure a composite PK in ArtistGenre, consisting of both FK's
            modelBuilder.Entity<ArtistGenre>()
                .ToTable("ArtistGenres").HasKey(ag => new { ag.ArtistId, ag.GenreId });

            modelBuilder.Entity<ArtistGenre>()
                .HasOne(ag => ag.Artist)
                .WithMany(g => g.ArtistGenres)
                .HasForeignKey(ag => ag.ArtistId);

            modelBuilder.Entity<ArtistGenre>()
                .HasOne(ag => ag.Genre)
                .WithMany(a => a.ArtistGenres)
                .HasForeignKey(ag => ag.GenreId);


            //configure a composite PK in ArtistImage, consisting of both FK's
            modelBuilder.Entity<ArtistImage>()
                .ToTable("ArtistImages").HasKey(ai => new { ai.ArtistId, ai.ImageId });

            modelBuilder.Entity<ArtistImage>()
                .HasOne(ag => ag.Artist)
                .WithMany(g => g.ArtistImages)
                .HasForeignKey(ag => ag.ArtistId);

            modelBuilder.Entity<Genre>().ToTable("Genre")
                .HasData(
                    new Genre { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Hard rock" },
                    new Genre { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Metal" },
                    new Genre { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Old school trash" },
                    new Genre { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Rock" },
                    new Genre { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Speed metal" },
                    new Genre { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "Trash metal" },
                    new Genre { Id = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "Belgian rock" },
                    new Genre { Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "Dutch indie" },
                    new Genre { Id = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Dutch rock" },
                    new Genre { Id = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "Album rock" },
                    new Genre { Id = Guid.Parse("00000000-0000-0000-0000-000000000011"), Name = "Australian rock" },
                    new Genre { Id = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Alternative rock" },
                    new Genre { Id = Guid.Parse("00000000-0000-0000-0000-000000000013"), Name = "Grunge" },
                    new Genre { Id = Guid.Parse("00000000-0000-0000-0000-000000000014"), Name = "Permanent wave" },
                    new Genre { Id = Guid.Parse("00000000-0000-0000-0000-000000000015"), Name = "Post-grunge" },
                    new Genre { Id = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Classic belgian pop" },
                    new Genre { Id = Guid.Parse("00000000-0000-0000-0000-000000000017"), Name = "Kleinkunst" },
                    new Genre { Id = Guid.Parse("00000000-0000-0000-0000-000000000018"), Name = "West-vlaamse hip hop" }
                );


            modelBuilder.Entity<Artist>().ToTable("Artist")
                .HasData(
                    new Artist { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Triggerfinger", Followers = 143599 },
                    new Artist { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "AC/DC", Followers = 14124193 },
                    new Artist { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Nirvana", Followers = 10222671 },
                    new Artist { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Flip Kowlier", Followers = 12999 },
                    new Artist { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Metallica", Followers = 13031380 }
                );

            modelBuilder.Entity<ArtistGenre>()
                .HasData(
                    // TRIGGERFINGER
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000001"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000007") },
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000001"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000008") },
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000001"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000009") },

                    // AC/DC
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000002"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000010") },
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000002"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000011") },
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000002"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000012") },
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000002"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000001") },
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000002"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000004") },

                    // NIRVANA
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000003"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000012") },
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000003"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000013") },
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000003"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000014") },
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000003"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000015") },
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000003"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000004") },

                    // FLIP KOWLIER
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000004"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000007") },
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000004"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000016") },
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000004"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000017") },
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000004"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000018") },

                    // METALLICA
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000005"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000001") },
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000005"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000002") },
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000005"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000003") },
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000005"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000004") },
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000005"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000005") },
                    new ArtistGenre { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000005"), GenreId = Guid.Parse("00000000-0000-0000-0000-000000000006") }

                );

            modelBuilder.Entity<Image>().ToTable("Image")
                .HasData(
                    // TRIGGERFINGER
                    new Image { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Url = new Uri("https://i.scdn.co/image/b59c74329496a6256355648f005cffcf1fd76dc9"), Height = 640, Width = 640 },
                    new Image { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Url = new Uri("https://i.scdn.co/image/8df00a835ac66507a55b6572491750bd41c7278c"), Height = 320, Width = 320 },
                    new Image { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Url = new Uri("https://i.scdn.co/image/13fd1ee7b9f8d3b1ca57d086d6ed7c171d052eb4"), Height = 160, Width = 160 },

                    // AC/DC
                    new Image { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Url = new Uri("https://i.scdn.co/image/a16c5d95ede008ec905d6ca6d1b5abbf39ad4566"), Height = 1500, Width = 1000 },
                    new Image { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Url = new Uri("https://i.scdn.co/image/fb26e1c0e5779ac46b225651494ac14b6b8ebba7"), Height = 640, Width = 1000 },
                    new Image { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), Url = new Uri("https://i.scdn.co/image/3d00e92fb05c62e2faf2908b34e6f24e0a4cb213"), Height = 300, Width = 200 },
                    new Image { Id = Guid.Parse("00000000-0000-0000-0000-000000000007"), Url = new Uri("https://i.scdn.co/image/2940421b19c6b8a26b073ef340290516ea0399e1"), Height = 96, Width = 64 },

                    // NIRVANA
                    new Image { Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), Url = new Uri("https://i.scdn.co/image/84282c28d851a700132356381fcfbadc67ff498b"), Height = 1057, Width = 1000 },
                    new Image { Id = Guid.Parse("00000000-0000-0000-0000-000000000009"), Url = new Uri("https://i.scdn.co/image/a4e10b79a642e9891383448cbf37d7266a6883d6"), Height = 677, Width = 640 },
                    new Image { Id = Guid.Parse("00000000-0000-0000-0000-000000000010"), Url = new Uri("https://i.scdn.co/image/42ae0f180f16e2f21c1f2212717fc436f5b95451"), Height = 211, Width = 200 },
                    new Image { Id = Guid.Parse("00000000-0000-0000-0000-000000000011"), Url = new Uri("https://i.scdn.co/image/e797ad36d56c3fc8fa06c6fe91263a15bf8391b8"), Height = 68, Width = 64 },


                    // FLIP KOWLIER
                    new Image { Id = Guid.Parse("00000000-0000-0000-0000-000000000012"), Url = new Uri("https://i.scdn.co/image/f51258ac754739045b0956cdb1f7a3332fc46754"), Height = 640, Width = 640 },
                    new Image { Id = Guid.Parse("00000000-0000-0000-0000-000000000013"), Url = new Uri("https://i.scdn.co/image/b3897cc5dac721abe76fdf7c7266b3f9b51af73f"), Height = 320, Width = 320 },
                    new Image { Id = Guid.Parse("00000000-0000-0000-0000-000000000014"), Url = new Uri("https://i.scdn.co/image/5bc9e60072958ace6e07fdd0c0dbeb65bd8764f3"), Height = 160, Width = 160 },


                    // METALLICA
                    new Image { Id = Guid.Parse("00000000-0000-0000-0000-000000000015"), Url = new Uri("https://i.scdn.co/image/5a06711d7fc48d5e0e3f9a3274ffed3f0af1bd91"), Height = 640, Width = 640 },
                    new Image { Id = Guid.Parse("00000000-0000-0000-0000-000000000016"), Url = new Uri("https://i.scdn.co/image/0c22030833eb55c14013bb36eb6a429328868c29"), Height = 320, Width = 320 },
                    new Image { Id = Guid.Parse("00000000-0000-0000-0000-000000000017"), Url = new Uri("https://i.scdn.co/image/c1fb4d88de092b5617e649bd4c406b5cab7d3ddd"), Height = 160, Width = 160 }
                );

            modelBuilder.Entity<ArtistImage>()
                .HasData(
                    // TRIGGERFINGER
                    new ArtistImage { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000001"), ImageId = Guid.Parse("00000000-0000-0000-0000-000000000001") },
                    new ArtistImage { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000001"), ImageId = Guid.Parse("00000000-0000-0000-0000-000000000002") },
                    new ArtistImage { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000001"), ImageId = Guid.Parse("00000000-0000-0000-0000-000000000003") },

                    // AC/DC
                    new ArtistImage { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000002"), ImageId = Guid.Parse("00000000-0000-0000-0000-000000000004") },
                    new ArtistImage { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000002"), ImageId = Guid.Parse("00000000-0000-0000-0000-000000000005") },
                    new ArtistImage { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000002"), ImageId = Guid.Parse("00000000-0000-0000-0000-000000000006") },
                    new ArtistImage { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000002"), ImageId = Guid.Parse("00000000-0000-0000-0000-000000000007") },

                    // NIRVANA
                    new ArtistImage { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000003"), ImageId = Guid.Parse("00000000-0000-0000-0000-000000000008") },
                    new ArtistImage { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000003"), ImageId = Guid.Parse("00000000-0000-0000-0000-000000000009") },
                    new ArtistImage { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000003"), ImageId = Guid.Parse("00000000-0000-0000-0000-000000000010") },
                    new ArtistImage { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000003"), ImageId = Guid.Parse("00000000-0000-0000-0000-000000000011") },

                    // FLIP KOWLIER
                    new ArtistImage { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000004"), ImageId = Guid.Parse("00000000-0000-0000-0000-000000000012") },
                    new ArtistImage { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000004"), ImageId = Guid.Parse("00000000-0000-0000-0000-000000000013") },
                    new ArtistImage { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000004"), ImageId = Guid.Parse("00000000-0000-0000-0000-000000000014") },

                    // METALLICA
                    new ArtistImage { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000005"), ImageId = Guid.Parse("00000000-0000-0000-0000-000000000015") },
                    new ArtistImage { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000005"), ImageId = Guid.Parse("00000000-0000-0000-0000-000000000016") },
                    new ArtistImage { ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000005"), ImageId = Guid.Parse("00000000-0000-0000-0000-000000000017") }
                );

            modelBuilder.Entity<Album>().ToTable("Album")
                .HasData(
                    // TRIGGERFINGER
                    new Album { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "What Grabs Ya?", ReleaseDate = new DateTime(2008, 02, 25) },
                    new Album { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Faders Up 2 - Live in Amsterdam", ReleaseDate = new DateTime(2012, 05, 18) },
                    new Album { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "TF20 - VAULT", ReleaseDate = new DateTime(2019, 04, 12) },

                    //  AC/DC
                    new Album { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Back In Black", ReleaseDate = new DateTime(1980, 07, 25) },
                    new Album { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Highway to Hell", ReleaseDate = new DateTime(1979, 07, 27) },
                    new Album { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "High Voltage", ReleaseDate = new DateTime(1976, 05, 14) },

                    // NIRVANA
                    new Album { Id = Guid.Parse("00000000-0000-0000-0000-000000000007"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Nevermind", ReleaseDate = new DateTime(1991, 09, 26) },
                    new Album { Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "MTV Unplugged In New York", ReleaseDate = new DateTime(1994, 01, 01) },
                    new Album { Id = Guid.Parse("00000000-0000-0000-0000-000000000009"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Live at Reading", ReleaseDate = new DateTime(2009, 01, 01) },

                    // FLIP KOWLIER
                    new Album { Id = Guid.Parse("00000000-0000-0000-0000-000000000010"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Ocharme Ik", ReleaseDate = new DateTime(2001, 09, 20) },
                    new Album { Id = Guid.Parse("00000000-0000-0000-0000-000000000011"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "In De Fik", ReleaseDate = new DateTime(2004, 03, 08) },
                    new Album { Id = Guid.Parse("00000000-0000-0000-0000-000000000012"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "10 Jaar Flip Kowlier", ReleaseDate = new DateTime(2011, 11, 21) },

                    // METALLICA
                    new Album { Id = Guid.Parse("00000000-0000-0000-0000-000000000013"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Master Of Puppets", ReleaseDate = new DateTime(1986, 03, 03) },
                    new Album { Id = Guid.Parse("00000000-0000-0000-0000-000000000014"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "...And Justice For All", ReleaseDate = new DateTime(1988, 08, 25) },
                    new Album { Id = Guid.Parse("00000000-0000-0000-0000-000000000015"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Metallica", ReleaseDate = new DateTime(1991, 01, 01) },
                    new Album { Id = Guid.Parse("00000000-0000-0000-0000-000000000016"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Garage Inc.", ReleaseDate = new DateTime(1998, 01, 01) },
                    new Album { Id = Guid.Parse("00000000-0000-0000-0000-000000000017"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Hardwired...To Self-Destruct", ReleaseDate = new DateTime(2016, 11, 18) }
                );


            modelBuilder.Entity<Track>().ToTable("Track");
            modelBuilder.Entity<Image>().ToTable("Image");
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
