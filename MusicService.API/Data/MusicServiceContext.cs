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
                    new Artist { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Triggerfinger", Followers = 143599, ImagePath = new Uri("https://i.scdn.co/image/b59c74329496a6256355648f005cffcf1fd76dc9") },
                    new Artist { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "AC/DC", Followers = 14124193, ImagePath = new Uri("https://i.scdn.co/image/fb26e1c0e5779ac46b225651494ac14b6b8ebba7") },
                    new Artist { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Nirvana", Followers = 10222671, ImagePath = new Uri("https://i.scdn.co/image/a4e10b79a642e9891383448cbf37d7266a6883d6") },
                    new Artist { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Flip Kowlier", Followers = 12999, ImagePath = new Uri("https://i.scdn.co/image/f51258ac754739045b0956cdb1f7a3332fc46754") },
                    new Artist { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Metallica", Followers = 13031380, ImagePath = new Uri("https://i.scdn.co/image/5a06711d7fc48d5e0e3f9a3274ffed3f0af1bd91") }
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

            modelBuilder.Entity<Album>().ToTable("Album")
                .HasData(
                    // TRIGGERFINGER
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "What Grabs Ya?", ReleaseDate = new DateTime(2008, 02, 25), AlbumCover = new Uri("https://i.scdn.co/image/ab67616d0000b273c6e7315035049d4962cf9281") },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Faders Up 2 - Live in Amsterdam", ReleaseDate = new DateTime(2012, 05, 18), AlbumCover = new Uri("https://i.scdn.co/image/ab67616d0000b2735ed075defea8eb5596870f24") },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "TF20 - VAULT", ReleaseDate = new DateTime(2019, 04, 12), AlbumCover = new Uri("https://i.scdn.co/image/ab67616d0000b273e5ac4bc0576257fcd3f39b09") },

                    //  AC/DC
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Back In Black", ReleaseDate = new DateTime(1980, 07, 25), AlbumCover = new Uri("https://i.scdn.co/image/ab67616d0000b273e02589301e7f4b222312bed0") },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Highway to Hell", ReleaseDate = new DateTime(1979, 07, 27), AlbumCover = new Uri("https://i.scdn.co/image/ab67616d0000b273f0a9ea7f5b5f9a6c7bae097d") },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "High Voltage", ReleaseDate = new DateTime(1976, 05, 14), AlbumCover = new Uri("https://i.scdn.co/image/ab67616d0000b273fe88ce4e76995d0fdd92688a") },

                    // NIRVANA
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000007"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Nevermind", ReleaseDate = new DateTime(1991, 09, 26), AlbumCover = new Uri("https://i.scdn.co/image/d1e45852702e21c779fcb7fc5bc5d17552447c03") },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "MTV Unplugged In New York", ReleaseDate = new DateTime(1994, 01, 01), AlbumCover = new Uri("https://i.scdn.co/image/45904f42d84e41c55083dc970cd6b1891b8ad1ec") },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000009"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Live at Reading", ReleaseDate = new DateTime(2009, 01, 01), AlbumCover = new Uri("https://i.scdn.co/image/95e8aee222c137b297bfb69488cf6f61be59f603") },

                    // FLIP KOWLIER
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000010"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Ocharme Ik", ReleaseDate = new DateTime(2001, 09, 20), AlbumCover = new Uri("https://i.scdn.co/image/ab67616d0000b273ca024ffe93941ca7679b2eea") },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000011"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "In De Fik", ReleaseDate = new DateTime(2004, 03, 08), AlbumCover = new Uri("https://i.scdn.co/image/ab67616d0000b273d78002e84126cd6c141269f4") },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000012"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "10 Jaar Flip Kowlier", ReleaseDate = new DateTime(2011, 11, 21), AlbumCover = new Uri("https://i.scdn.co/image/ab67616d0000b273b04c7de0627120c8ebc993cd") },

                    // METALLICA
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000013"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Master Of Puppets", ReleaseDate = new DateTime(1986, 03, 03), AlbumCover = new Uri("https://i.scdn.co/image/3b6db779aa5739127acdf4eac9a7e553af647901") },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000014"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "...And Justice For All", ReleaseDate = new DateTime(1988, 08, 25), AlbumCover = new Uri("https://i.scdn.co/image/a1cc049aad5552e63277476f4dea35be7e9413d1") },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000015"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Metallica", ReleaseDate = new DateTime(1991, 01, 01), AlbumCover = new Uri("https://i.scdn.co/image/58a14f1de9f5e980e642357729602945b9388858") },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000016"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Garage Inc.", ReleaseDate = new DateTime(1998, 01, 01), AlbumCover = new Uri("https://i.scdn.co/image/39b3632645249f6a37e3cdefbc17a9278f7b134b") },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000017"), ArtistId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Hardwired...To Self-Destruct", ReleaseDate = new DateTime(2016, 11, 18), AlbumCover = new Uri("https://i.scdn.co/image/38aae3e851571d7a8a1b4c610b7523ae8c104b7b") }
                );


            modelBuilder.Entity<Track>().ToTable("Track")
                .HasData(
                    // TRIGGERFINGER WHAT GRABS YA?
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Short Term Memory Love", DurationMs = (long)258866, Explicit = false, DiscNumber = 1, TrackNumber = (long)1 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "First Taste", DurationMs = (long)203160, Explicit = false, DiscNumber = 1, TrackNumber = (long)2 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Soon", DurationMs = (long)245866, Explicit = false, DiscNumber = 1, TrackNumber = (long)3 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Halfway Town", DurationMs = (long)279760, Explicit = false, DiscNumber = 1, TrackNumber = (long)4 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Scream", DurationMs = (long)336573, Explicit = false, DiscNumber = 1, TrackNumber = (long)5 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Is It", DurationMs = (long)190693, Explicit = false, DiscNumber = 1, TrackNumber = (long)6 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000007"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "All My Floating", DurationMs = (long)214906, Explicit = false, DiscNumber = 1, TrackNumber = (long)7 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "What Grabs Ya", DurationMs = (long)205560, Explicit = false, DiscNumber = 1, TrackNumber = (long)8 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000009"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Lines", DurationMs = (long)464440, Explicit = false, DiscNumber = 1, TrackNumber = (long)9 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000010"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "No Teasin' Around", DurationMs = (long)293053, Explicit = false, DiscNumber = 1, TrackNumber = (long)10 },

                    // TRIGGERFINGER FADERS UP
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000011"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Intro - Live in Amsterdam", DurationMs = (long)105693, Explicit = false, DiscNumber = 1, TrackNumber = (long)1 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000012"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "I'm Coming for You - Live in Amsterdam", DurationMs = (long)207416, Explicit = false, DiscNumber = 1, TrackNumber = (long)2 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000013"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "On My Knees - Live in Amsterdam", DurationMs = (long)337483, Explicit = false, DiscNumber = 1, TrackNumber = (long)3 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000014"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Short Term Memory Love - Live in Amsterdam", DurationMs = (long)303904, Explicit = false, DiscNumber = 1, TrackNumber = (long)4 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000015"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Cherry - Live in Amsterdam", DurationMs = (long)206804, Explicit = false, DiscNumber = 1, TrackNumber = (long)5 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000016"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "My Baby's Got a Gun - Live in Amsterdam", DurationMs = (long)456881, Explicit = false, DiscNumber = 1, TrackNumber = (long)6 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000017"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "All This Dancin' Around - Live in Amsterdam", DurationMs = (long)349566, Explicit = false, DiscNumber = 1, TrackNumber = (long)7 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000018"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Drum Solo - Live in Amsterdam", DurationMs = (long)278602, Explicit = false, DiscNumber = 1, TrackNumber = (long)8 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000019"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "First Taste - Live in Amsterdam", DurationMs = (long)236626, Explicit = false, DiscNumber = 1, TrackNumber = (long)9 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000020"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Is It? - Live in Amsterdam", DurationMs = (long)355148, Explicit = false, DiscNumber = 1, TrackNumber = (long)10 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000021"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Feed Me - Live in Amsterdam", DurationMs = (long)337972, Explicit = false, DiscNumber = 1, TrackNumber = (long)11 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000022"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Let it Ride - Live in Amsterdam", DurationMs = (long)211599, Explicit = false, DiscNumber = 1, TrackNumber = (long)12 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000023"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "It Hasn't Gone Away - Live in Amsterdam", DurationMs = (long)359780, Explicit = false, DiscNumber = 1, TrackNumber = (long)13 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000024"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "I Follow Rivers - Bonus Track - Live @ Giel VARA/3FM", DurationMs = (long)213551, Explicit = false, DiscNumber = 1, TrackNumber = (long)14 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000025"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "It Hasn't Gone Away - Bonus Track - Live @ Nachtegiel - VARA/3FM", DurationMs = (long)390783, Explicit = false, DiscNumber = 1, TrackNumber = (long)15 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000026"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Love Lost in Love - Bonus Track - Live @ 3 On Stage - 3FM/NED3", DurationMs = (long)219357, Explicit = false, DiscNumber = 1, TrackNumber = (long)16 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000027"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Cherry - Bonus Track - Christmas Version - Live @ Nachtegiel - VARA/3FM", DurationMs = (long)182694, Explicit = false, DiscNumber = 1, TrackNumber = (long)17 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000028"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "All Night Long - Bonus Track - Live @ De Wereld Draait Door - VARA", DurationMs = (long)256133, Explicit = false, DiscNumber = 1, TrackNumber = (long)18 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000929"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Ballad of a Thin Man - Bonus Track - Live @ Vooruit, Gent for Radio 1", DurationMs = (long)367724, Explicit = false, DiscNumber = 1, TrackNumber = (long)19 },

                    // TRIGGERFINGER TF20 VAULT
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000029"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Man Down - Live recording for RedBull SoundClash 2012 - Lotto Arena Antwerp", DurationMs = (long)295480, Explicit = false, DiscNumber = 1, TrackNumber = (long)1 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000030"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "I'll Be Home", DurationMs = (long)164373, Explicit = false, DiscNumber = 1, TrackNumber = (long)2 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000031"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Ain't Nobody - Live session 3FM Radio Netherlands \"De Ochtend Bij Giel\" (BNNVARA)", DurationMs = (long)245746, Explicit = false, DiscNumber = 1, TrackNumber = (long)3 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000032"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Love Lost in Love - Live recording Koningin Elizabeth Wedstrijd Brussels", DurationMs = (long)234933, Explicit = false, DiscNumber = 1, TrackNumber = (long)4 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000033"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Mercy - Live recording for RedBull SoundClash 2008 - Minnemeers / Democrazy Ghent", DurationMs = (long)358933, Explicit = false, DiscNumber = 1, TrackNumber = (long)5 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000034"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Short Term Memory Love - Re-recorded 2019", DurationMs = (long)258333, Explicit = false, DiscNumber = 1, TrackNumber = (long)6 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000035"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Flesh Tight", DurationMs = (long)173813, Explicit = false, DiscNumber = 1, TrackNumber = (long)7 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000036"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Candy Killer", DurationMs = (long)171600, Explicit = false, DiscNumber = 1, TrackNumber = (long)8 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000037"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Colossus - slow version", DurationMs = (long)389613, Explicit = false, DiscNumber = 1, TrackNumber = (long)9 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000038"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Need You Tonight", DurationMs = (long)193680, Explicit = false, DiscNumber = 1, TrackNumber = (long)10 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000039"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Colossus - wild version", DurationMs = (long)323213, Explicit = false, DiscNumber = 1, TrackNumber = (long)11 },

                    // AC/DC BACK IN BLACK
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000040"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Hells Bells", DurationMs = (long)312293, Explicit = false, DiscNumber = 1, TrackNumber = (long)1 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000041"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Shoot to Thrill", DurationMs = (long)317426, Explicit = false, DiscNumber = 1, TrackNumber = (long)2 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000042"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "What Do You Do for Money Honey", DurationMs = (long)215533, Explicit = false, DiscNumber = 1, TrackNumber = (long)3 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000043"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Givin the Dog a Bone", DurationMs = (long)211760, Explicit = false, DiscNumber = 1, TrackNumber = (long)4 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000044"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Let Me Put My Love Into You", DurationMs = (long)255266, Explicit = false, DiscNumber = 1, TrackNumber = (long)5 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000045"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Back In Black", DurationMs = (long)255493, Explicit = false, DiscNumber = 1, TrackNumber = (long)6 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000046"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "You Shook Me All Night Long", DurationMs = (long)210173, Explicit = false, DiscNumber = 1, TrackNumber = (long)7 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000047"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Have a Drink on Me", DurationMs = (long)238466, Explicit = false, DiscNumber = 1, TrackNumber = (long)8 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000048"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Shake a Leg", DurationMs = (long)245666, Explicit = false, DiscNumber = 1, TrackNumber = (long)9 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000049"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Rock and Roll Ain't Noise Pollution", DurationMs = (long)266040, Explicit = false, DiscNumber = 1, TrackNumber = (long)10 },

                    // AC/DC HIGHWAY TO HELL
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000050"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Highway to Hell", DurationMs = (long)208400, Explicit = false, DiscNumber = 1, TrackNumber = (long)1 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000051"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Girls Got Rhythm", DurationMs = (long)203293, Explicit = false, DiscNumber = 1, TrackNumber = (long)2 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000052"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Walk All Over You", DurationMs = (long)310000, Explicit = false, DiscNumber = 1, TrackNumber = (long)3 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000053"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Touch Too Much", DurationMs = (long)266266, Explicit = false, DiscNumber = 1, TrackNumber = (long)4 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000054"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Beating Around the Bush", DurationMs = (long)235706, Explicit = false, DiscNumber = 1, TrackNumber = (long)5 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000055"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Shot Down in Flames", DurationMs = (long)202866, Explicit = false, DiscNumber = 1, TrackNumber = (long)6 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000056"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Get It Hot", DurationMs = (long)154506, Explicit = false, DiscNumber = 1, TrackNumber = (long)7 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000057"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "If You Want Blood (You've Got It)", DurationMs = (long)274226, Explicit = false, DiscNumber = 1, TrackNumber = (long)8 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000058"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Love Hungry Man", DurationMs = (long)257173, Explicit = false, DiscNumber = 1, TrackNumber = (long)9 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000059"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Night Prowler", DurationMs = (long)387960, Explicit = false, DiscNumber = 1, TrackNumber = (long)10 },

                    // AC/DC HIGH VOLTAGE
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000060"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "It's a Long Way to the Top (If You Wanna Rock 'N' Roll)", DurationMs = (long)301226, Explicit = false, DiscNumber = 1, TrackNumber = (long)1 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000061"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "Rock 'N' Roll Singer", DurationMs = (long)303666, Explicit = false, DiscNumber = 1, TrackNumber = (long)2 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000062"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "The Jack", DurationMs = (long)352040, Explicit = false, DiscNumber = 1, TrackNumber = (long)3 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000063"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "Live Wire", DurationMs = (long)348600, Explicit = false, DiscNumber = 1, TrackNumber = (long)4 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000064"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "T.N.T.", DurationMs = (long)214666, Explicit = false, DiscNumber = 1, TrackNumber = (long)5 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000065"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "Can I Sit Next to You Girl", DurationMs = (long)251373, Explicit = false, DiscNumber = 1, TrackNumber = (long)6 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000066"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "Little Lover", DurationMs = (long)338306, Explicit = false, DiscNumber = 1, TrackNumber = (long)7 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000067"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "She's Got Balls", DurationMs = (long)291306, Explicit = false, DiscNumber = 1, TrackNumber = (long)8 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000068"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "High Voltage", DurationMs = (long)254200, Explicit = false, DiscNumber = 1, TrackNumber = (long)9 },

                    // NIRVANA NEVERMIND
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000069"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "Smells Like Teen Spirit", DurationMs = (long)301920, Explicit = false, DiscNumber = 1, TrackNumber = (long)1 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000070"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "In Bloom - Nevermind Version", DurationMs = (long)255080, Explicit = false, DiscNumber = 1, TrackNumber = (long)2 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000071"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "Come As You Are", DurationMs = (long)218920, Explicit = false, DiscNumber = 1, TrackNumber = (long)3 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000072"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "Breed", DurationMs = (long)184040, Explicit = false, DiscNumber = 1, TrackNumber = (long)4 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000073"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "Lithium", DurationMs = (long)257053, Explicit = false, DiscNumber = 1, TrackNumber = (long)5 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000074"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "Polly", DurationMs = (long)173853, Explicit = false, DiscNumber = 1, TrackNumber = (long)6 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000075"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "Territorial Pissings", DurationMs = (long)142946, Explicit = false, DiscNumber = 1, TrackNumber = (long)7 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000076"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "Drain You", DurationMs = (long)223880, Explicit = false, DiscNumber = 1, TrackNumber = (long)8 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000077"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "Lounge Act", DurationMs = (long)156426, Explicit = false, DiscNumber = 1, TrackNumber = (long)9 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000078"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "Stay Away", DurationMs = (long)211440, Explicit = false, DiscNumber = 1, TrackNumber = (long)10 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000079"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "On A Plain", DurationMs = (long)194426, Explicit = false, DiscNumber = 1, TrackNumber = (long)11 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000080"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "Something In The Way", DurationMs = (long)232146, Explicit = false, DiscNumber = 1, TrackNumber = (long)12 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000081"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "Endless, Nameless", DurationMs = (long)403293, Explicit = false, DiscNumber = 1, TrackNumber = (long)13 },

                    // NIRVANA MTV UNPLUGGED
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000082"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "About A Girl", DurationMs = (long)218000, Explicit = false, DiscNumber = 1, TrackNumber = (long)1 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000083"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "Come As You Are", DurationMs = (long)253906, Explicit = false, DiscNumber = 1, TrackNumber = (long)2 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000084"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "Jesus Doesn't Want Me For A Sunbeam", DurationMs = (long)277266, Explicit = false, DiscNumber = 1, TrackNumber = (long)3 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000085"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "The Man Who Sold The World", DurationMs = (long)261093, Explicit = false, DiscNumber = 1, TrackNumber = (long)4 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000086"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "Pennyroyal Tea", DurationMs = (long)220506, Explicit = false, DiscNumber = 1, TrackNumber = (long)5 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000087"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "Dumb", DurationMs = (long)172933, Explicit = false, DiscNumber = 1, TrackNumber = (long)6 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000088"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "Polly", DurationMs = (long)196466, Explicit = false, DiscNumber = 1, TrackNumber = (long)7 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000089"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "On A Plain", DurationMs = (long)224733, Explicit = false, DiscNumber = 1, TrackNumber = (long)8 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000090"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "Something In The Way", DurationMs = (long)241533, Explicit = false, DiscNumber = 1, TrackNumber = (long)9 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000091"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "Plateau", DurationMs = (long)218133, Explicit = false, DiscNumber = 1, TrackNumber = (long)10 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000092"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "Oh Me", DurationMs = (long)206160, Explicit = false, DiscNumber = 1, TrackNumber = (long)11 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000093"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "Lake Of Fire", DurationMs = (long)175973, Explicit = false, DiscNumber = 1, TrackNumber = (long)12 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000094"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "All Apologies", DurationMs = (long)263226, Explicit = false, DiscNumber = 1, TrackNumber = (long)13 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000095"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "Where Did You Sleep Last Night", DurationMs = (long)306066, Explicit = false, DiscNumber = 1, TrackNumber = (long)14 },

                    // NIRVANA LIVE AT READING
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000096"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Breed - 1992/Live at Reading", DurationMs = (long)192080, Explicit = false, DiscNumber = 1, TrackNumber = (long)1 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000097"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Drain You - 1992/Live at Reading", DurationMs = (long)218440, Explicit = false, DiscNumber = 1, TrackNumber = (long)2 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000098"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Aneurysm - 1992/Live at Reading", DurationMs = (long)275026, Explicit = false, DiscNumber = 1, TrackNumber = (long)3 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000099"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "School - 1992/Live at Reading", DurationMs = (long)163280, Explicit = false, DiscNumber = 1, TrackNumber = (long)4 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000100"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Sliver - 1992/Live at Reading", DurationMs = (long)126120, Explicit = false, DiscNumber = 1, TrackNumber = (long)5 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000101"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "In Bloom - 1992/Live at Reading", DurationMs = (long)276160, Explicit = false, DiscNumber = 1, TrackNumber = (long)6 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000102"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Come As You Are - 1992/Live at Reading", DurationMs = (long)216333, Explicit = false, DiscNumber = 1, TrackNumber = (long)7 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000103"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Lithium - 1992/Live at Reading", DurationMs = (long)261813, Explicit = false, DiscNumber = 1, TrackNumber = (long)8 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000104"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "About A Girl - 1992/Live at Reading", DurationMs = (long)171960, Explicit = false, DiscNumber = 1, TrackNumber = (long)9 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000105"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Tourette's - 1992/Live at Reading", DurationMs = (long)110573, Explicit = false, DiscNumber = 1, TrackNumber = (long)10 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000106"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Polly - 1992/Live at Reading", DurationMs = (long)168626, Explicit = false, DiscNumber = 1, TrackNumber = (long)11 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000107"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Lounge Act - 1992/Live at Reading", DurationMs = (long)156786, Explicit = false, DiscNumber = 1, TrackNumber = (long)12 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000108"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Smells Like Teen Spirit - 1992/Live at Reading", DurationMs = (long)285186, Explicit = false, DiscNumber = 1, TrackNumber = (long)13 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000109"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "On A Plain - 1992/Live at Reading", DurationMs = (long)180293, Explicit = false, DiscNumber = 1, TrackNumber = (long)14 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000110"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Negative Creep - 1992/Live at Reading", DurationMs = (long)172440, Explicit = false, DiscNumber = 1, TrackNumber = (long)15 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000111"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Been A Son - 1992/Live at Reading", DurationMs = (long)133426, Explicit = false, DiscNumber = 1, TrackNumber = (long)16 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000112"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "All Apologies - 1992/Live at Reading", DurationMs = (long)189853, Explicit = false, DiscNumber = 1, TrackNumber = (long)17 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000113"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Blew - 1992/Live at Reading", DurationMs = (long)199720, Explicit = false, DiscNumber = 1, TrackNumber = (long)18 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000114"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Dumb - 1992/Live at Reading", DurationMs = (long)152400, Explicit = false, DiscNumber = 1, TrackNumber = (long)19 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000115"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Stay Away - 1992/Live at Reading", DurationMs = (long)212933, Explicit = false, DiscNumber = 1, TrackNumber = (long)20 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000116"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Spank Thru - 1992/Live at Reading", DurationMs = (long)186866, Explicit = false, DiscNumber = 1, TrackNumber = (long)21 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000117"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "The Money Will Roll Right In - 1992/Live at Reading", DurationMs = (long)136560, Explicit = false, DiscNumber = 1, TrackNumber = (long)22 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000118"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "D-7 - 1992/Live at Reading", DurationMs = (long)223826, Explicit = false, DiscNumber = 1, TrackNumber = (long)23 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000119"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Territorial Pissings - 1992/Live at Reading", DurationMs = (long)269826, Explicit = false, DiscNumber = 1, TrackNumber = (long)24 },

                    // FLIP KOWLIER OCHARME IK
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000120"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "Ik Ben Moe", DurationMs = (long)228733, Explicit = false, DiscNumber = 1, TrackNumber = (long)1 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000121"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "Kwestie Van Organisatie", DurationMs = (long)187106, Explicit = false, DiscNumber = 1, TrackNumber = (long)2 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000122"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "Welgemeende", DurationMs = (long)182000, Explicit = false, DiscNumber = 1, TrackNumber = (long)3 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000123"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "Ti Woa", DurationMs = (long)287466, Explicit = false, DiscNumber = 1, TrackNumber = (long)4 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000124"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "Min Moaten", DurationMs = (long)181160, Explicit = false, DiscNumber = 1, TrackNumber = (long)5 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000125"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "Moeder Lieve Moeder", DurationMs = (long)244400, Explicit = false, DiscNumber = 1, TrackNumber = (long)6 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000126"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "Ocharme Ik", DurationMs = (long)273773, Explicit = false, DiscNumber = 1, TrackNumber = (long)7 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000127"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "Slichte Mins", DurationMs = (long)72560, Explicit = false, DiscNumber = 1, TrackNumber = (long)8 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000128"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "Vredeslied", DurationMs = (long)205466, Explicit = false, DiscNumber = 1, TrackNumber = (long)9 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000129"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "Verkluot", DurationMs = (long)156800, Explicit = false, DiscNumber = 1, TrackNumber = (long)10 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000130"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "Barabas", DurationMs = (long)126866, Explicit = false, DiscNumber = 1, TrackNumber = (long)11 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000131"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "In't Park", DurationMs = (long)190240, Explicit = false, DiscNumber = 1, TrackNumber = (long)12 },

                    // FLIP KOWLIER IN DE FIK
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000132"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000011"), Name = "Vannacht", DurationMs = (long)244760, Explicit = false, DiscNumber = 1, TrackNumber = (long)1 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000133"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000011"), Name = "Bjistje In Min Uoft", DurationMs = (long)205840, Explicit = false, DiscNumber = 1, TrackNumber = (long)2 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000134"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000011"), Name = "In De Fik", DurationMs = (long)177200, Explicit = false, DiscNumber = 1, TrackNumber = (long)3 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000135"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000011"), Name = "Over Mie (Te Geroaken)", DurationMs = (long)269760, Explicit = false, DiscNumber = 1, TrackNumber = (long)4 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000136"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000011"), Name = "Angelo & Angelique", DurationMs = (long)271200, Explicit = false, DiscNumber = 1, TrackNumber = (long)5 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000137"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000011"), Name = "Nonkel Dirk", DurationMs = (long)199440, Explicit = false, DiscNumber = 1, TrackNumber = (long)6 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000138"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000011"), Name = "Bom Bin", DurationMs = (long)223493, Explicit = false, DiscNumber = 1, TrackNumber = (long)7 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000139"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000011"), Name = "Tristig Feit", DurationMs = (long)209533, Explicit = false, DiscNumber = 1, TrackNumber = (long)8 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000140"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000011"), Name = "Miss België", DurationMs = (long)210306, Explicit = false, DiscNumber = 1, TrackNumber = (long)9 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000141"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000011"), Name = "Geef Mie Een Glas", DurationMs = (long)340160, Explicit = false, DiscNumber = 1, TrackNumber = (long)10 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000142"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000011"), Name = "Smetvrjis", DurationMs = (long)145240, Explicit = false, DiscNumber = 1, TrackNumber = (long)11 },

                    // FLIP KOWLIER 10 JAAR
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000143"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Kwestie Van Organisatie", DurationMs = (long)187106, Explicit = false, DiscNumber = 1, TrackNumber = (long)1 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000144"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Welgemeende", DurationMs = (long)182000, Explicit = false, DiscNumber = 1, TrackNumber = (long)2 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000145"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Min Moaten", DurationMs = (long)181160, Explicit = false, DiscNumber = 1, TrackNumber = (long)3 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000146"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Ik Ben Moe", DurationMs = (long)228733, Explicit = false, DiscNumber = 1, TrackNumber = (long)4 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000147"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Verkluot", DurationMs = (long)156800, Explicit = false, DiscNumber = 1, TrackNumber = (long)5 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000148"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "In De Fik", DurationMs = (long)177200, Explicit = false, DiscNumber = 1, TrackNumber = (long)6 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000149"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Bjistje In Min Uoft", DurationMs = (long)205840, Explicit = false, DiscNumber = 1, TrackNumber = (long)7 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000150"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Angelo & Angelique", DurationMs = (long)271200, Explicit = false, DiscNumber = 1, TrackNumber = (long)8 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000151"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Geef Mie Een Glas", DurationMs = (long)340160, Explicit = false, DiscNumber = 1, TrackNumber = (long)9 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000152"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "De Grotste Lul Van 't Stad", DurationMs = (long)170826, Explicit = false, DiscNumber = 1, TrackNumber = (long)10 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000153"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Donderdagnacht", DurationMs = (long)191773, Explicit = false, DiscNumber = 1, TrackNumber = (long)11 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000154"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Caravan", DurationMs = (long)213080, Explicit = false, DiscNumber = 1, TrackNumber = (long)12 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000155"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Mo Ba Nin", DurationMs = (long)339600, Explicit = false, DiscNumber = 1, TrackNumber = (long)13 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000156"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Zwembad", DurationMs = (long)226293, Explicit = false, DiscNumber = 1, TrackNumber = (long)14 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000157"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Mama (Nowo Homme Hon)", DurationMs = (long)187093, Explicit = false, DiscNumber = 1, TrackNumber = (long)15 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000158"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Geboren voe te leven", DurationMs = (long)290506, Explicit = false, DiscNumber = 1, TrackNumber = (long)16 },

                    // METALLICA MASTER OF PUPPETS
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000159"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000013"), Name = "Battery", DurationMs = (long)312360, Explicit = false, DiscNumber = 1, TrackNumber = (long)1 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000160"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000013"), Name = "Master Of Puppets", DurationMs = (long)515386, Explicit = false, DiscNumber = 1, TrackNumber = (long)2 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000161"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000013"), Name = "The Thing That Should Not Be", DurationMs = (long)396106, Explicit = false, DiscNumber = 1, TrackNumber = (long)3 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000162"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000013"), Name = "Welcome Home (Sanitarium)", DurationMs = (long)387146, Explicit = false, DiscNumber = 1, TrackNumber = (long)4 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000163"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000013"), Name = "Disposable Heroes", DurationMs = (long)496626, Explicit = false, DiscNumber = 1, TrackNumber = (long)5 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000164"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000013"), Name = "Leper Messiah", DurationMs = (long)339880, Explicit = false, DiscNumber = 1, TrackNumber = (long)6 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000165"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000013"), Name = "Orion", DurationMs = (long)507226, Explicit = false, DiscNumber = 1, TrackNumber = (long)7 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000166"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000013"), Name = "Damage, Inc.", DurationMs = (long)332465, Explicit = true, DiscNumber = 1, TrackNumber = (long)8 },

                    // METALLICA AND JUSTICE FOR ALL
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000167"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000014"), Name = "Blackened", DurationMs = (long)402143, Explicit = false, DiscNumber = 1, TrackNumber = (long)1 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000168"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000014"), Name = "...And Justice for All", DurationMs = (long)585506, Explicit = false, DiscNumber = 1, TrackNumber = (long)2 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000169"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000014"), Name = "Eye of the Beholder", DurationMs = (long)385986, Explicit = false, DiscNumber = 1, TrackNumber = (long)3 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000170"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000014"), Name = "One", DurationMs = (long)446145, Explicit = false, DiscNumber = 1, TrackNumber = (long)4 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000171"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000014"), Name = "The Shortest Straw", DurationMs = (long)395101, Explicit = false, DiscNumber = 1, TrackNumber = (long)5 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000172"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000014"), Name = "Harvester of Sorrow", DurationMs = (long)345283, Explicit = false, DiscNumber = 1, TrackNumber = (long)6 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000173"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000014"), Name = "The Frayed Ends of Sanity", DurationMs = (long)463158, Explicit = false, DiscNumber = 1, TrackNumber = (long)7 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000174"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000014"), Name = "To Live is to Die", DurationMs = (long)588381, Explicit = false, DiscNumber = 1, TrackNumber = (long)8 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000175"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000014"), Name = "Dyers Eve", DurationMs = (long)313045, Explicit = true, DiscNumber = 1, TrackNumber = (long)9 },

                    // METALLICA BLACK
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000176"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000015"), Name = "Enter Sandman", DurationMs = (long)331266, Explicit = false, DiscNumber = 1, TrackNumber = (long)1 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000177"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000015"), Name = "Sad But True", DurationMs = (long)323933, Explicit = false, DiscNumber = 1, TrackNumber = (long)2 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000178"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000015"), Name = "Holier Than Thou", DurationMs = (long)227640, Explicit = false, DiscNumber = 1, TrackNumber = (long)3 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000179"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000015"), Name = "The Unforgiven", DurationMs = (long)386493, Explicit = false, DiscNumber = 1, TrackNumber = (long)4 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000180"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000015"), Name = "Wherever I May Roam", DurationMs = (long)403866, Explicit = false, DiscNumber = 1, TrackNumber = (long)5 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000181"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000015"), Name = "Don't Tread On Me", DurationMs = (long)240333, Explicit = false, DiscNumber = 1, TrackNumber = (long)6 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000182"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000015"), Name = "Through The Never", DurationMs = (long)242906, Explicit = false, DiscNumber = 1, TrackNumber = (long)7 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000183"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000015"), Name = "Nothing Else Matters", DurationMs = (long)388266, Explicit = false, DiscNumber = 1, TrackNumber = (long)8 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000184"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000015"), Name = "Of Wolf And Man", DurationMs = (long)256533, Explicit = false, DiscNumber = 1, TrackNumber = (long)9 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000185"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000015"), Name = "The God That Failed", DurationMs = (long)308533, Explicit = false, DiscNumber = 1, TrackNumber = (long)10 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000186"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000015"), Name = "My Friend Of Misery", DurationMs = (long)407773, Explicit = false, DiscNumber = 1, TrackNumber = (long)11 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000187"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000015"), Name = "The Struggle Within", DurationMs = (long)233906, Explicit = false, DiscNumber = 1, TrackNumber = (long)12 },

                    // METALLICA GARAGE INC
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000188"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Free Speech For The Dumb", DurationMs = (long)155493, Explicit = true, DiscNumber = 1, TrackNumber = (long)1 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000189"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "It's Electric", DurationMs = (long)213933, Explicit = false, DiscNumber = 1, TrackNumber = (long)2 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000190"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Sabbra Cadabra", DurationMs = (long)380240, Explicit = false, DiscNumber = 1, TrackNumber = (long)3 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000191"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Turn The Page", DurationMs = (long)366466, Explicit = false, DiscNumber = 1, TrackNumber = (long)4 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000192"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Die, Die My Darling", DurationMs = (long)146560, Explicit = false, DiscNumber = 1, TrackNumber = (long)5 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000193"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Loverman", DurationMs = (long)472826, Explicit = true, DiscNumber = 1, TrackNumber = (long)6 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000194"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Mercyful Fate", DurationMs = (long)670373, Explicit = false, DiscNumber = 1, TrackNumber = (long)7 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000195"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Astronomy", DurationMs = (long)397840, Explicit = false, DiscNumber = 1, TrackNumber = (long)8 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000196"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Whiskey In The Jar", DurationMs = (long)304693, Explicit = false, DiscNumber = 1, TrackNumber = (long)9 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000197"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Tuesday's Gone", DurationMs = (long)543866, Explicit = false, DiscNumber = 1, TrackNumber = (long)10 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000198"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "The More I See", DurationMs = (long)288666, Explicit = false, DiscNumber = 1, TrackNumber = (long)11 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000199"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Helpless", DurationMs = (long)396920, Explicit = false, DiscNumber = 2, TrackNumber = (long)1 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000200"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "The Small Hours", DurationMs = (long)400800, Explicit = false, DiscNumber = 2, TrackNumber = (long)2 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000201"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "The Wait", DurationMs = (long)292960, Explicit = false, DiscNumber = 2, TrackNumber = (long)3 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000202"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Crash Course In Brain Surgery", DurationMs = (long)188826, Explicit = false, DiscNumber = 2, TrackNumber = (long)4 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000203"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Last Caress / Green Hell", DurationMs = (long)210000, Explicit = true, DiscNumber = 2, TrackNumber = (long)5 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000204"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Am I Evil?", DurationMs = (long)470066, Explicit = true, DiscNumber = 2, TrackNumber = (long)6 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000205"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Blitzkrieg", DurationMs = (long)216960, Explicit = false, DiscNumber = 2, TrackNumber = (long)7 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000206"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Breadfan", DurationMs = (long)341066, Explicit = false, DiscNumber = 2, TrackNumber = (long)8 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000207"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "The Prince", DurationMs = (long)264800, Explicit = false, DiscNumber = 2, TrackNumber = (long)9 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000208"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Stone Cold Crazy", DurationMs = (long)137706, Explicit = true, DiscNumber = 2, TrackNumber = (long)10 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000209"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "So What", DurationMs = (long)188933, Explicit = true, DiscNumber = 2, TrackNumber = (long)11 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000210"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Killing Time", DurationMs = (long)183666, Explicit = false, DiscNumber = 2, TrackNumber = (long)12 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000211"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Overkill - Live", DurationMs = (long)245000, Explicit = true, DiscNumber = 2, TrackNumber = (long)13 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000212"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Damage Case - Live", DurationMs = (long)220333, Explicit = true, DiscNumber = 2, TrackNumber = (long)14 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000213"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Stone Dead Forever - Live", DurationMs = (long)291933, Explicit = false, DiscNumber = 2, TrackNumber = (long)15 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000214"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Too Late Too Late - Live", DurationMs = (long)192493, Explicit = true, DiscNumber = 2, TrackNumber = (long)16 },

                    // METALLICA HARDWIRED
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000215"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000017"), Name = "Hardwired", DurationMs = (long)189347, Explicit = true, DiscNumber = 1, TrackNumber = (long)1 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000216"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000017"), Name = "Atlas, Rise!", DurationMs = (long)388624, Explicit = false, DiscNumber = 1, TrackNumber = (long)2 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000217"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000017"), Name = "Now That We’re Dead", DurationMs = (long)419074, Explicit = false, DiscNumber = 1, TrackNumber = (long)3 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000218"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000017"), Name = "Moth Into Flame", DurationMs = (long)350644, Explicit = false, DiscNumber = 1, TrackNumber = (long)4 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000219"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000017"), Name = "Dream No More", DurationMs = (long)389597, Explicit = false, DiscNumber = 1, TrackNumber = (long)5 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000220"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000017"), Name = "Halo On Fire", DurationMs = (long)495016, Explicit = false, DiscNumber = 1, TrackNumber = (long)6 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000221"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000017"), Name = "Confusion", DurationMs = (long)401226, Explicit = false, DiscNumber = 2, TrackNumber = (long)1 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000222"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000017"), Name = "ManUNkind", DurationMs = (long)415599, Explicit = false, DiscNumber = 2, TrackNumber = (long)2 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000223"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000017"), Name = "Here Comes Revenge", DurationMs = (long)437625, Explicit = false, DiscNumber = 2, TrackNumber = (long)3 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000224"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000017"), Name = "Am I Savage?", DurationMs = (long)389662, Explicit = false, DiscNumber = 2, TrackNumber = (long)4 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000225"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000017"), Name = "Murder One", DurationMs = (long)345277, Explicit = false, DiscNumber = 2, TrackNumber = (long)5 },
                    new { Id = Guid.Parse("00000000-0000-0000-0000-000000000226"), AlbumId = Guid.Parse("00000000-0000-0000-0000-000000000017"), Name = "Spit Out The Bone", DurationMs = (long)429198, Explicit = false, DiscNumber = 2, TrackNumber = (long)6 }

                );
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Track> Tracks { get; set; }
    }
}
