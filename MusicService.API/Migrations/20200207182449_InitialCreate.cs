using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicService.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    Name = table.Column<string>(nullable: true),
                    Followers = table.Column<long>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    Name = table.Column<string>(nullable: true),
                    ArtistId = table.Column<Guid>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    AlbumCover = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Album_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistGenre",
                columns: table => new
                {
                    ArtistId = table.Column<Guid>(nullable: false),
                    GenreId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistGenre", x => new { x.ArtistId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_ArtistGenre_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistGenre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    Name = table.Column<string>(nullable: true),
                    AlbumId = table.Column<Guid>(nullable: false),
                    DurationMs = table.Column<long>(nullable: false),
                    Explicit = table.Column<bool>(nullable: false),
                    TrackNumber = table.Column<int>(nullable: false),
                    DiscNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Track_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "Id", "Followers", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), 143599L, "https://i.scdn.co/image/b59c74329496a6256355648f005cffcf1fd76dc9", "Triggerfinger" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 14124193L, "https://i.scdn.co/image/fb26e1c0e5779ac46b225651494ac14b6b8ebba7", "AC/DC" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 10222671L, "https://i.scdn.co/image/a4e10b79a642e9891383448cbf37d7266a6883d6", "Nirvana" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), 12999L, "https://i.scdn.co/image/f51258ac754739045b0956cdb1f7a3332fc46754", "Flip Kowlier" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), 13031380L, "https://i.scdn.co/image/5a06711d7fc48d5e0e3f9a3274ffed3f0af1bd91", "Metallica" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000016"), "Classic belgian pop" },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "Post-grunge" },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "Permanent wave" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "Grunge" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "Alternative rock" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "Australian rock" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Album rock" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Dutch rock" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Belgian rock" },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "Kleinkunst" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Trash metal" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Speed metal" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Rock" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Old school trash" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Metal" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Hard rock" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Dutch indie" },
                    { new Guid("00000000-0000-0000-0000-000000000018"), "West-vlaamse hip hop" }
                });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "Id", "AlbumCover", "ArtistId", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "https://i.scdn.co/image/ab67616d0000b273c6e7315035049d4962cf9281", new Guid("00000000-0000-0000-0000-000000000001"), "What Grabs Ya?", new DateTime(2008, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "https://i.scdn.co/image/38aae3e851571d7a8a1b4c610b7523ae8c104b7b", new Guid("00000000-0000-0000-0000-000000000005"), "Hardwired...To Self-Destruct", new DateTime(2016, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "https://i.scdn.co/image/39b3632645249f6a37e3cdefbc17a9278f7b134b", new Guid("00000000-0000-0000-0000-000000000005"), "Garage Inc.", new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "https://i.scdn.co/image/58a14f1de9f5e980e642357729602945b9388858", new Guid("00000000-0000-0000-0000-000000000005"), "Metallica", new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "https://i.scdn.co/image/3b6db779aa5739127acdf4eac9a7e553af647901", new Guid("00000000-0000-0000-0000-000000000005"), "Master Of Puppets", new DateTime(1986, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "https://i.scdn.co/image/ab67616d0000b273b04c7de0627120c8ebc993cd", new Guid("00000000-0000-0000-0000-000000000004"), "10 Jaar Flip Kowlier", new DateTime(2011, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "https://i.scdn.co/image/ab67616d0000b273d78002e84126cd6c141269f4", new Guid("00000000-0000-0000-0000-000000000004"), "In De Fik", new DateTime(2004, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "https://i.scdn.co/image/ab67616d0000b273ca024ffe93941ca7679b2eea", new Guid("00000000-0000-0000-0000-000000000004"), "Ocharme Ik", new DateTime(2001, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "https://i.scdn.co/image/a1cc049aad5552e63277476f4dea35be7e9413d1", new Guid("00000000-0000-0000-0000-000000000005"), "...And Justice For All", new DateTime(1988, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "https://i.scdn.co/image/45904f42d84e41c55083dc970cd6b1891b8ad1ec", new Guid("00000000-0000-0000-0000-000000000003"), "MTV Unplugged In New York", new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "https://i.scdn.co/image/d1e45852702e21c779fcb7fc5bc5d17552447c03", new Guid("00000000-0000-0000-0000-000000000003"), "Nevermind", new DateTime(1991, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "https://i.scdn.co/image/ab67616d0000b273fe88ce4e76995d0fdd92688a", new Guid("00000000-0000-0000-0000-000000000002"), "High Voltage", new DateTime(1976, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "https://i.scdn.co/image/ab67616d0000b273f0a9ea7f5b5f9a6c7bae097d", new Guid("00000000-0000-0000-0000-000000000002"), "Highway to Hell", new DateTime(1979, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "https://i.scdn.co/image/ab67616d0000b273e02589301e7f4b222312bed0", new Guid("00000000-0000-0000-0000-000000000002"), "Back In Black", new DateTime(1980, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "https://i.scdn.co/image/ab67616d0000b273e5ac4bc0576257fcd3f39b09", new Guid("00000000-0000-0000-0000-000000000001"), "TF20 - VAULT", new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "https://i.scdn.co/image/ab67616d0000b2735ed075defea8eb5596870f24", new Guid("00000000-0000-0000-0000-000000000001"), "Faders Up 2 - Live in Amsterdam", new DateTime(2012, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "https://i.scdn.co/image/95e8aee222c137b297bfb69488cf6f61be59f603", new Guid("00000000-0000-0000-0000-000000000003"), "Live at Reading", new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ArtistGenre",
                columns: new[] { "ArtistId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000011") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000012") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000012") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000016") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000014") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000013") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000017") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000018") }
                });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "Id", "AlbumId", "DiscNumber", "DurationMs", "Explicit", "Name", "TrackNumber" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), 1, 258866L, false, "Short Term Memory Love", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000144"), new Guid("00000000-0000-0000-0000-000000000012"), 1, 182000L, false, "Welgemeende", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000145"), new Guid("00000000-0000-0000-0000-000000000012"), 1, 181160L, false, "Min Moaten", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000146"), new Guid("00000000-0000-0000-0000-000000000012"), 1, 228733L, false, "Ik Ben Moe", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000147"), new Guid("00000000-0000-0000-0000-000000000012"), 1, 156800L, false, "Verkluot", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000148"), new Guid("00000000-0000-0000-0000-000000000012"), 1, 177200L, false, "In De Fik", 6 },
                    { new Guid("00000000-0000-0000-0000-000000000149"), new Guid("00000000-0000-0000-0000-000000000012"), 1, 205840L, false, "Bjistje In Min Uoft", 7 },
                    { new Guid("00000000-0000-0000-0000-000000000150"), new Guid("00000000-0000-0000-0000-000000000012"), 1, 271200L, false, "Angelo & Angelique", 8 },
                    { new Guid("00000000-0000-0000-0000-000000000151"), new Guid("00000000-0000-0000-0000-000000000012"), 1, 340160L, false, "Geef Mie Een Glas", 9 },
                    { new Guid("00000000-0000-0000-0000-000000000152"), new Guid("00000000-0000-0000-0000-000000000012"), 1, 170826L, false, "De Grotste Lul Van 't Stad", 10 },
                    { new Guid("00000000-0000-0000-0000-000000000153"), new Guid("00000000-0000-0000-0000-000000000012"), 1, 191773L, false, "Donderdagnacht", 11 },
                    { new Guid("00000000-0000-0000-0000-000000000154"), new Guid("00000000-0000-0000-0000-000000000012"), 1, 213080L, false, "Caravan", 12 },
                    { new Guid("00000000-0000-0000-0000-000000000143"), new Guid("00000000-0000-0000-0000-000000000012"), 1, 187106L, false, "Kwestie Van Organisatie", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000155"), new Guid("00000000-0000-0000-0000-000000000012"), 1, 339600L, false, "Mo Ba Nin", 13 },
                    { new Guid("00000000-0000-0000-0000-000000000157"), new Guid("00000000-0000-0000-0000-000000000012"), 1, 187093L, false, "Mama (Nowo Homme Hon)", 15 },
                    { new Guid("00000000-0000-0000-0000-000000000158"), new Guid("00000000-0000-0000-0000-000000000012"), 1, 290506L, false, "Geboren voe te leven", 16 },
                    { new Guid("00000000-0000-0000-0000-000000000159"), new Guid("00000000-0000-0000-0000-000000000013"), 1, 312360L, false, "Battery", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000160"), new Guid("00000000-0000-0000-0000-000000000013"), 1, 515386L, false, "Master Of Puppets", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000161"), new Guid("00000000-0000-0000-0000-000000000013"), 1, 396106L, false, "The Thing That Should Not Be", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000162"), new Guid("00000000-0000-0000-0000-000000000013"), 1, 387146L, false, "Welcome Home (Sanitarium)", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000163"), new Guid("00000000-0000-0000-0000-000000000013"), 1, 496626L, false, "Disposable Heroes", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000164"), new Guid("00000000-0000-0000-0000-000000000013"), 1, 339880L, false, "Leper Messiah", 6 },
                    { new Guid("00000000-0000-0000-0000-000000000165"), new Guid("00000000-0000-0000-0000-000000000013"), 1, 507226L, false, "Orion", 7 },
                    { new Guid("00000000-0000-0000-0000-000000000166"), new Guid("00000000-0000-0000-0000-000000000013"), 1, 332465L, true, "Damage, Inc.", 8 },
                    { new Guid("00000000-0000-0000-0000-000000000167"), new Guid("00000000-0000-0000-0000-000000000014"), 1, 402143L, false, "Blackened", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000156"), new Guid("00000000-0000-0000-0000-000000000012"), 1, 226293L, false, "Zwembad", 14 },
                    { new Guid("00000000-0000-0000-0000-000000000142"), new Guid("00000000-0000-0000-0000-000000000011"), 1, 145240L, false, "Smetvrjis", 11 },
                    { new Guid("00000000-0000-0000-0000-000000000141"), new Guid("00000000-0000-0000-0000-000000000011"), 1, 340160L, false, "Geef Mie Een Glas", 10 },
                    { new Guid("00000000-0000-0000-0000-000000000140"), new Guid("00000000-0000-0000-0000-000000000011"), 1, 210306L, false, "Miss België", 9 },
                    { new Guid("00000000-0000-0000-0000-000000000115"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 212933L, false, "Stay Away - 1992/Live at Reading", 20 },
                    { new Guid("00000000-0000-0000-0000-000000000116"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 186866L, false, "Spank Thru - 1992/Live at Reading", 21 },
                    { new Guid("00000000-0000-0000-0000-000000000117"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 136560L, false, "The Money Will Roll Right In - 1992/Live at Reading", 22 },
                    { new Guid("00000000-0000-0000-0000-000000000118"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 223826L, false, "D-7 - 1992/Live at Reading", 23 },
                    { new Guid("00000000-0000-0000-0000-000000000119"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 269826L, false, "Territorial Pissings - 1992/Live at Reading", 24 },
                    { new Guid("00000000-0000-0000-0000-000000000120"), new Guid("00000000-0000-0000-0000-000000000010"), 1, 228733L, false, "Ik Ben Moe", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000121"), new Guid("00000000-0000-0000-0000-000000000010"), 1, 187106L, false, "Kwestie Van Organisatie", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000122"), new Guid("00000000-0000-0000-0000-000000000010"), 1, 182000L, false, "Welgemeende", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000123"), new Guid("00000000-0000-0000-0000-000000000010"), 1, 287466L, false, "Ti Woa", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000124"), new Guid("00000000-0000-0000-0000-000000000010"), 1, 181160L, false, "Min Moaten", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000125"), new Guid("00000000-0000-0000-0000-000000000010"), 1, 244400L, false, "Moeder Lieve Moeder", 6 },
                    { new Guid("00000000-0000-0000-0000-000000000126"), new Guid("00000000-0000-0000-0000-000000000010"), 1, 273773L, false, "Ocharme Ik", 7 },
                    { new Guid("00000000-0000-0000-0000-000000000127"), new Guid("00000000-0000-0000-0000-000000000010"), 1, 72560L, false, "Slichte Mins", 8 },
                    { new Guid("00000000-0000-0000-0000-000000000128"), new Guid("00000000-0000-0000-0000-000000000010"), 1, 205466L, false, "Vredeslied", 9 },
                    { new Guid("00000000-0000-0000-0000-000000000129"), new Guid("00000000-0000-0000-0000-000000000010"), 1, 156800L, false, "Verkluot", 10 },
                    { new Guid("00000000-0000-0000-0000-000000000130"), new Guid("00000000-0000-0000-0000-000000000010"), 1, 126866L, false, "Barabas", 11 },
                    { new Guid("00000000-0000-0000-0000-000000000131"), new Guid("00000000-0000-0000-0000-000000000010"), 1, 190240L, false, "In't Park", 12 },
                    { new Guid("00000000-0000-0000-0000-000000000132"), new Guid("00000000-0000-0000-0000-000000000011"), 1, 244760L, false, "Vannacht", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000133"), new Guid("00000000-0000-0000-0000-000000000011"), 1, 205840L, false, "Bjistje In Min Uoft", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000134"), new Guid("00000000-0000-0000-0000-000000000011"), 1, 177200L, false, "In De Fik", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000135"), new Guid("00000000-0000-0000-0000-000000000011"), 1, 269760L, false, "Over Mie (Te Geroaken)", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000136"), new Guid("00000000-0000-0000-0000-000000000011"), 1, 271200L, false, "Angelo & Angelique", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000137"), new Guid("00000000-0000-0000-0000-000000000011"), 1, 199440L, false, "Nonkel Dirk", 6 },
                    { new Guid("00000000-0000-0000-0000-000000000138"), new Guid("00000000-0000-0000-0000-000000000011"), 1, 223493L, false, "Bom Bin", 7 },
                    { new Guid("00000000-0000-0000-0000-000000000139"), new Guid("00000000-0000-0000-0000-000000000011"), 1, 209533L, false, "Tristig Feit", 8 },
                    { new Guid("00000000-0000-0000-0000-000000000168"), new Guid("00000000-0000-0000-0000-000000000014"), 1, 585506L, false, "...And Justice for All", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000114"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 152400L, false, "Dumb - 1992/Live at Reading", 19 },
                    { new Guid("00000000-0000-0000-0000-000000000169"), new Guid("00000000-0000-0000-0000-000000000014"), 1, 385986L, false, "Eye of the Beholder", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000171"), new Guid("00000000-0000-0000-0000-000000000014"), 1, 395101L, false, "The Shortest Straw", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000201"), new Guid("00000000-0000-0000-0000-000000000016"), 2, 292960L, false, "The Wait", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000202"), new Guid("00000000-0000-0000-0000-000000000016"), 2, 188826L, false, "Crash Course In Brain Surgery", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000203"), new Guid("00000000-0000-0000-0000-000000000016"), 2, 210000L, true, "Last Caress / Green Hell", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000204"), new Guid("00000000-0000-0000-0000-000000000016"), 2, 470066L, true, "Am I Evil?", 6 },
                    { new Guid("00000000-0000-0000-0000-000000000205"), new Guid("00000000-0000-0000-0000-000000000016"), 2, 216960L, false, "Blitzkrieg", 7 },
                    { new Guid("00000000-0000-0000-0000-000000000206"), new Guid("00000000-0000-0000-0000-000000000016"), 2, 341066L, false, "Breadfan", 8 },
                    { new Guid("00000000-0000-0000-0000-000000000207"), new Guid("00000000-0000-0000-0000-000000000016"), 2, 264800L, false, "The Prince", 9 },
                    { new Guid("00000000-0000-0000-0000-000000000208"), new Guid("00000000-0000-0000-0000-000000000016"), 2, 137706L, true, "Stone Cold Crazy", 10 },
                    { new Guid("00000000-0000-0000-0000-000000000209"), new Guid("00000000-0000-0000-0000-000000000016"), 2, 188933L, true, "So What", 11 },
                    { new Guid("00000000-0000-0000-0000-000000000210"), new Guid("00000000-0000-0000-0000-000000000016"), 2, 183666L, false, "Killing Time", 12 },
                    { new Guid("00000000-0000-0000-0000-000000000211"), new Guid("00000000-0000-0000-0000-000000000016"), 2, 245000L, true, "Overkill - Live", 13 },
                    { new Guid("00000000-0000-0000-0000-000000000200"), new Guid("00000000-0000-0000-0000-000000000016"), 2, 400800L, false, "The Small Hours", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000212"), new Guid("00000000-0000-0000-0000-000000000016"), 2, 220333L, true, "Damage Case - Live", 14 },
                    { new Guid("00000000-0000-0000-0000-000000000214"), new Guid("00000000-0000-0000-0000-000000000016"), 2, 192493L, true, "Too Late Too Late - Live", 16 },
                    { new Guid("00000000-0000-0000-0000-000000000215"), new Guid("00000000-0000-0000-0000-000000000017"), 1, 189347L, true, "Hardwired", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000216"), new Guid("00000000-0000-0000-0000-000000000017"), 1, 388624L, false, "Atlas, Rise!", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000217"), new Guid("00000000-0000-0000-0000-000000000017"), 1, 419074L, false, "Now That We’re Dead", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000218"), new Guid("00000000-0000-0000-0000-000000000017"), 1, 350644L, false, "Moth Into Flame", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000219"), new Guid("00000000-0000-0000-0000-000000000017"), 1, 389597L, false, "Dream No More", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000220"), new Guid("00000000-0000-0000-0000-000000000017"), 1, 495016L, false, "Halo On Fire", 6 },
                    { new Guid("00000000-0000-0000-0000-000000000221"), new Guid("00000000-0000-0000-0000-000000000017"), 2, 401226L, false, "Confusion", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000222"), new Guid("00000000-0000-0000-0000-000000000017"), 2, 415599L, false, "ManUNkind", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000223"), new Guid("00000000-0000-0000-0000-000000000017"), 2, 437625L, false, "Here Comes Revenge", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000224"), new Guid("00000000-0000-0000-0000-000000000017"), 2, 389662L, false, "Am I Savage?", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000213"), new Guid("00000000-0000-0000-0000-000000000016"), 2, 291933L, false, "Stone Dead Forever - Live", 15 },
                    { new Guid("00000000-0000-0000-0000-000000000199"), new Guid("00000000-0000-0000-0000-000000000016"), 2, 396920L, false, "Helpless", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000198"), new Guid("00000000-0000-0000-0000-000000000016"), 1, 288666L, false, "The More I See", 11 },
                    { new Guid("00000000-0000-0000-0000-000000000197"), new Guid("00000000-0000-0000-0000-000000000016"), 1, 543866L, false, "Tuesday's Gone", 10 },
                    { new Guid("00000000-0000-0000-0000-000000000172"), new Guid("00000000-0000-0000-0000-000000000014"), 1, 345283L, false, "Harvester of Sorrow", 6 },
                    { new Guid("00000000-0000-0000-0000-000000000173"), new Guid("00000000-0000-0000-0000-000000000014"), 1, 463158L, false, "The Frayed Ends of Sanity", 7 },
                    { new Guid("00000000-0000-0000-0000-000000000174"), new Guid("00000000-0000-0000-0000-000000000014"), 1, 588381L, false, "To Live is to Die", 8 },
                    { new Guid("00000000-0000-0000-0000-000000000175"), new Guid("00000000-0000-0000-0000-000000000014"), 1, 313045L, true, "Dyers Eve", 9 },
                    { new Guid("00000000-0000-0000-0000-000000000176"), new Guid("00000000-0000-0000-0000-000000000015"), 1, 331266L, false, "Enter Sandman", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000177"), new Guid("00000000-0000-0000-0000-000000000015"), 1, 323933L, false, "Sad But True", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000178"), new Guid("00000000-0000-0000-0000-000000000015"), 1, 227640L, false, "Holier Than Thou", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000179"), new Guid("00000000-0000-0000-0000-000000000015"), 1, 386493L, false, "The Unforgiven", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000180"), new Guid("00000000-0000-0000-0000-000000000015"), 1, 403866L, false, "Wherever I May Roam", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000181"), new Guid("00000000-0000-0000-0000-000000000015"), 1, 240333L, false, "Don't Tread On Me", 6 },
                    { new Guid("00000000-0000-0000-0000-000000000182"), new Guid("00000000-0000-0000-0000-000000000015"), 1, 242906L, false, "Through The Never", 7 },
                    { new Guid("00000000-0000-0000-0000-000000000183"), new Guid("00000000-0000-0000-0000-000000000015"), 1, 388266L, false, "Nothing Else Matters", 8 },
                    { new Guid("00000000-0000-0000-0000-000000000184"), new Guid("00000000-0000-0000-0000-000000000015"), 1, 256533L, false, "Of Wolf And Man", 9 },
                    { new Guid("00000000-0000-0000-0000-000000000185"), new Guid("00000000-0000-0000-0000-000000000015"), 1, 308533L, false, "The God That Failed", 10 },
                    { new Guid("00000000-0000-0000-0000-000000000186"), new Guid("00000000-0000-0000-0000-000000000015"), 1, 407773L, false, "My Friend Of Misery", 11 },
                    { new Guid("00000000-0000-0000-0000-000000000187"), new Guid("00000000-0000-0000-0000-000000000015"), 1, 233906L, false, "The Struggle Within", 12 },
                    { new Guid("00000000-0000-0000-0000-000000000188"), new Guid("00000000-0000-0000-0000-000000000016"), 1, 155493L, true, "Free Speech For The Dumb", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000189"), new Guid("00000000-0000-0000-0000-000000000016"), 1, 213933L, false, "It's Electric", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000190"), new Guid("00000000-0000-0000-0000-000000000016"), 1, 380240L, false, "Sabbra Cadabra", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000191"), new Guid("00000000-0000-0000-0000-000000000016"), 1, 366466L, false, "Turn The Page", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000192"), new Guid("00000000-0000-0000-0000-000000000016"), 1, 146560L, false, "Die, Die My Darling", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000193"), new Guid("00000000-0000-0000-0000-000000000016"), 1, 472826L, true, "Loverman", 6 },
                    { new Guid("00000000-0000-0000-0000-000000000194"), new Guid("00000000-0000-0000-0000-000000000016"), 1, 670373L, false, "Mercyful Fate", 7 },
                    { new Guid("00000000-0000-0000-0000-000000000195"), new Guid("00000000-0000-0000-0000-000000000016"), 1, 397840L, false, "Astronomy", 8 },
                    { new Guid("00000000-0000-0000-0000-000000000196"), new Guid("00000000-0000-0000-0000-000000000016"), 1, 304693L, false, "Whiskey In The Jar", 9 },
                    { new Guid("00000000-0000-0000-0000-000000000170"), new Guid("00000000-0000-0000-0000-000000000014"), 1, 446145L, false, "One", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000225"), new Guid("00000000-0000-0000-0000-000000000017"), 2, 345277L, false, "Murder One", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000113"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 199720L, false, "Blew - 1992/Live at Reading", 18 },
                    { new Guid("00000000-0000-0000-0000-000000000111"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 133426L, false, "Been A Son - 1992/Live at Reading", 16 },
                    { new Guid("00000000-0000-0000-0000-000000000030"), new Guid("00000000-0000-0000-0000-000000000003"), 1, 164373L, false, "I'll Be Home", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000031"), new Guid("00000000-0000-0000-0000-000000000003"), 1, 245746L, false, "Ain't Nobody - Live session 3FM Radio Netherlands \"De Ochtend Bij Giel\" (BNNVARA)", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000032"), new Guid("00000000-0000-0000-0000-000000000003"), 1, 234933L, false, "Love Lost in Love - Live recording Koningin Elizabeth Wedstrijd Brussels", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000033"), new Guid("00000000-0000-0000-0000-000000000003"), 1, 358933L, false, "Mercy - Live recording for RedBull SoundClash 2008 - Minnemeers / Democrazy Ghent", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000034"), new Guid("00000000-0000-0000-0000-000000000003"), 1, 258333L, false, "Short Term Memory Love - Re-recorded 2019", 6 },
                    { new Guid("00000000-0000-0000-0000-000000000035"), new Guid("00000000-0000-0000-0000-000000000003"), 1, 173813L, false, "Flesh Tight", 7 },
                    { new Guid("00000000-0000-0000-0000-000000000036"), new Guid("00000000-0000-0000-0000-000000000003"), 1, 171600L, false, "Candy Killer", 8 },
                    { new Guid("00000000-0000-0000-0000-000000000037"), new Guid("00000000-0000-0000-0000-000000000003"), 1, 389613L, false, "Colossus - slow version", 9 },
                    { new Guid("00000000-0000-0000-0000-000000000038"), new Guid("00000000-0000-0000-0000-000000000003"), 1, 193680L, false, "Need You Tonight", 10 },
                    { new Guid("00000000-0000-0000-0000-000000000039"), new Guid("00000000-0000-0000-0000-000000000003"), 1, 323213L, false, "Colossus - wild version", 11 },
                    { new Guid("00000000-0000-0000-0000-000000000040"), new Guid("00000000-0000-0000-0000-000000000004"), 1, 312293L, false, "Hells Bells", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000029"), new Guid("00000000-0000-0000-0000-000000000003"), 1, 295480L, false, "Man Down - Live recording for RedBull SoundClash 2012 - Lotto Arena Antwerp", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000041"), new Guid("00000000-0000-0000-0000-000000000004"), 1, 317426L, false, "Shoot to Thrill", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000043"), new Guid("00000000-0000-0000-0000-000000000004"), 1, 211760L, false, "Givin the Dog a Bone", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000044"), new Guid("00000000-0000-0000-0000-000000000004"), 1, 255266L, false, "Let Me Put My Love Into You", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000045"), new Guid("00000000-0000-0000-0000-000000000004"), 1, 255493L, false, "Back In Black", 6 },
                    { new Guid("00000000-0000-0000-0000-000000000046"), new Guid("00000000-0000-0000-0000-000000000004"), 1, 210173L, false, "You Shook Me All Night Long", 7 },
                    { new Guid("00000000-0000-0000-0000-000000000047"), new Guid("00000000-0000-0000-0000-000000000004"), 1, 238466L, false, "Have a Drink on Me", 8 },
                    { new Guid("00000000-0000-0000-0000-000000000048"), new Guid("00000000-0000-0000-0000-000000000004"), 1, 245666L, false, "Shake a Leg", 9 },
                    { new Guid("00000000-0000-0000-0000-000000000049"), new Guid("00000000-0000-0000-0000-000000000004"), 1, 266040L, false, "Rock and Roll Ain't Noise Pollution", 10 },
                    { new Guid("00000000-0000-0000-0000-000000000050"), new Guid("00000000-0000-0000-0000-000000000005"), 1, 208400L, false, "Highway to Hell", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000051"), new Guid("00000000-0000-0000-0000-000000000005"), 1, 203293L, false, "Girls Got Rhythm", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000052"), new Guid("00000000-0000-0000-0000-000000000005"), 1, 310000L, false, "Walk All Over You", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000053"), new Guid("00000000-0000-0000-0000-000000000005"), 1, 266266L, false, "Touch Too Much", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000042"), new Guid("00000000-0000-0000-0000-000000000004"), 1, 215533L, false, "What Do You Do for Money Honey", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000929"), new Guid("00000000-0000-0000-0000-000000000002"), 1, 367724L, false, "Ballad of a Thin Man - Bonus Track - Live @ Vooruit, Gent for Radio 1", 19 },
                    { new Guid("00000000-0000-0000-0000-000000000028"), new Guid("00000000-0000-0000-0000-000000000002"), 1, 256133L, false, "All Night Long - Bonus Track - Live @ De Wereld Draait Door - VARA", 18 },
                    { new Guid("00000000-0000-0000-0000-000000000027"), new Guid("00000000-0000-0000-0000-000000000002"), 1, 182694L, false, "Cherry - Bonus Track - Christmas Version - Live @ Nachtegiel - VARA/3FM", 17 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001"), 1, 203160L, false, "First Taste", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001"), 1, 245866L, false, "Soon", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001"), 1, 279760L, false, "Halfway Town", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001"), 1, 336573L, false, "Scream", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001"), 1, 190693L, false, "Is It", 6 },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001"), 1, 214906L, false, "All My Floating", 7 },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001"), 1, 205560L, false, "What Grabs Ya", 8 },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001"), 1, 464440L, false, "Lines", 9 },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001"), 1, 293053L, false, "No Teasin' Around", 10 },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000002"), 1, 105693L, false, "Intro - Live in Amsterdam", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000002"), 1, 207416L, false, "I'm Coming for You - Live in Amsterdam", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000002"), 1, 337483L, false, "On My Knees - Live in Amsterdam", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000002"), 1, 303904L, false, "Short Term Memory Love - Live in Amsterdam", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000002"), 1, 206804L, false, "Cherry - Live in Amsterdam", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000002"), 1, 456881L, false, "My Baby's Got a Gun - Live in Amsterdam", 6 },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000002"), 1, 349566L, false, "All This Dancin' Around - Live in Amsterdam", 7 },
                    { new Guid("00000000-0000-0000-0000-000000000018"), new Guid("00000000-0000-0000-0000-000000000002"), 1, 278602L, false, "Drum Solo - Live in Amsterdam", 8 },
                    { new Guid("00000000-0000-0000-0000-000000000019"), new Guid("00000000-0000-0000-0000-000000000002"), 1, 236626L, false, "First Taste - Live in Amsterdam", 9 },
                    { new Guid("00000000-0000-0000-0000-000000000020"), new Guid("00000000-0000-0000-0000-000000000002"), 1, 355148L, false, "Is It? - Live in Amsterdam", 10 },
                    { new Guid("00000000-0000-0000-0000-000000000021"), new Guid("00000000-0000-0000-0000-000000000002"), 1, 337972L, false, "Feed Me - Live in Amsterdam", 11 },
                    { new Guid("00000000-0000-0000-0000-000000000022"), new Guid("00000000-0000-0000-0000-000000000002"), 1, 211599L, false, "Let it Ride - Live in Amsterdam", 12 },
                    { new Guid("00000000-0000-0000-0000-000000000023"), new Guid("00000000-0000-0000-0000-000000000002"), 1, 359780L, false, "It Hasn't Gone Away - Live in Amsterdam", 13 },
                    { new Guid("00000000-0000-0000-0000-000000000024"), new Guid("00000000-0000-0000-0000-000000000002"), 1, 213551L, false, "I Follow Rivers - Bonus Track - Live @ Giel VARA/3FM", 14 },
                    { new Guid("00000000-0000-0000-0000-000000000025"), new Guid("00000000-0000-0000-0000-000000000002"), 1, 390783L, false, "It Hasn't Gone Away - Bonus Track - Live @ Nachtegiel - VARA/3FM", 15 },
                    { new Guid("00000000-0000-0000-0000-000000000026"), new Guid("00000000-0000-0000-0000-000000000002"), 1, 219357L, false, "Love Lost in Love - Bonus Track - Live @ 3 On Stage - 3FM/NED3", 16 },
                    { new Guid("00000000-0000-0000-0000-000000000054"), new Guid("00000000-0000-0000-0000-000000000005"), 1, 235706L, false, "Beating Around the Bush", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000112"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 189853L, false, "All Apologies - 1992/Live at Reading", 17 },
                    { new Guid("00000000-0000-0000-0000-000000000055"), new Guid("00000000-0000-0000-0000-000000000005"), 1, 202866L, false, "Shot Down in Flames", 6 },
                    { new Guid("00000000-0000-0000-0000-000000000057"), new Guid("00000000-0000-0000-0000-000000000005"), 1, 274226L, false, "If You Want Blood (You've Got It)", 8 },
                    { new Guid("00000000-0000-0000-0000-000000000087"), new Guid("00000000-0000-0000-0000-000000000008"), 1, 172933L, false, "Dumb", 6 },
                    { new Guid("00000000-0000-0000-0000-000000000088"), new Guid("00000000-0000-0000-0000-000000000008"), 1, 196466L, false, "Polly", 7 },
                    { new Guid("00000000-0000-0000-0000-000000000089"), new Guid("00000000-0000-0000-0000-000000000008"), 1, 224733L, false, "On A Plain", 8 },
                    { new Guid("00000000-0000-0000-0000-000000000090"), new Guid("00000000-0000-0000-0000-000000000008"), 1, 241533L, false, "Something In The Way", 9 },
                    { new Guid("00000000-0000-0000-0000-000000000091"), new Guid("00000000-0000-0000-0000-000000000008"), 1, 218133L, false, "Plateau", 10 },
                    { new Guid("00000000-0000-0000-0000-000000000092"), new Guid("00000000-0000-0000-0000-000000000008"), 1, 206160L, false, "Oh Me", 11 },
                    { new Guid("00000000-0000-0000-0000-000000000093"), new Guid("00000000-0000-0000-0000-000000000008"), 1, 175973L, false, "Lake Of Fire", 12 },
                    { new Guid("00000000-0000-0000-0000-000000000094"), new Guid("00000000-0000-0000-0000-000000000008"), 1, 263226L, false, "All Apologies", 13 },
                    { new Guid("00000000-0000-0000-0000-000000000095"), new Guid("00000000-0000-0000-0000-000000000008"), 1, 306066L, false, "Where Did You Sleep Last Night", 14 },
                    { new Guid("00000000-0000-0000-0000-000000000096"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 192080L, false, "Breed - 1992/Live at Reading", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000097"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 218440L, false, "Drain You - 1992/Live at Reading", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000086"), new Guid("00000000-0000-0000-0000-000000000008"), 1, 220506L, false, "Pennyroyal Tea", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000098"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 275026L, false, "Aneurysm - 1992/Live at Reading", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000100"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 126120L, false, "Sliver - 1992/Live at Reading", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000101"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 276160L, false, "In Bloom - 1992/Live at Reading", 6 },
                    { new Guid("00000000-0000-0000-0000-000000000102"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 216333L, false, "Come As You Are - 1992/Live at Reading", 7 },
                    { new Guid("00000000-0000-0000-0000-000000000103"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 261813L, false, "Lithium - 1992/Live at Reading", 8 },
                    { new Guid("00000000-0000-0000-0000-000000000104"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 171960L, false, "About A Girl - 1992/Live at Reading", 9 },
                    { new Guid("00000000-0000-0000-0000-000000000105"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 110573L, false, "Tourette's - 1992/Live at Reading", 10 },
                    { new Guid("00000000-0000-0000-0000-000000000106"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 168626L, false, "Polly - 1992/Live at Reading", 11 },
                    { new Guid("00000000-0000-0000-0000-000000000107"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 156786L, false, "Lounge Act - 1992/Live at Reading", 12 },
                    { new Guid("00000000-0000-0000-0000-000000000108"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 285186L, false, "Smells Like Teen Spirit - 1992/Live at Reading", 13 },
                    { new Guid("00000000-0000-0000-0000-000000000109"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 180293L, false, "On A Plain - 1992/Live at Reading", 14 },
                    { new Guid("00000000-0000-0000-0000-000000000110"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 172440L, false, "Negative Creep - 1992/Live at Reading", 15 },
                    { new Guid("00000000-0000-0000-0000-000000000099"), new Guid("00000000-0000-0000-0000-000000000009"), 1, 163280L, false, "School - 1992/Live at Reading", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000085"), new Guid("00000000-0000-0000-0000-000000000008"), 1, 261093L, false, "The Man Who Sold The World", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000084"), new Guid("00000000-0000-0000-0000-000000000008"), 1, 277266L, false, "Jesus Doesn't Want Me For A Sunbeam", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000083"), new Guid("00000000-0000-0000-0000-000000000008"), 1, 253906L, false, "Come As You Are", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000058"), new Guid("00000000-0000-0000-0000-000000000005"), 1, 257173L, false, "Love Hungry Man", 9 },
                    { new Guid("00000000-0000-0000-0000-000000000059"), new Guid("00000000-0000-0000-0000-000000000005"), 1, 387960L, false, "Night Prowler", 10 },
                    { new Guid("00000000-0000-0000-0000-000000000060"), new Guid("00000000-0000-0000-0000-000000000006"), 1, 301226L, false, "It's a Long Way to the Top (If You Wanna Rock 'N' Roll)", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000061"), new Guid("00000000-0000-0000-0000-000000000006"), 1, 303666L, false, "Rock 'N' Roll Singer", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000062"), new Guid("00000000-0000-0000-0000-000000000006"), 1, 352040L, false, "The Jack", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000063"), new Guid("00000000-0000-0000-0000-000000000006"), 1, 348600L, false, "Live Wire", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000064"), new Guid("00000000-0000-0000-0000-000000000006"), 1, 214666L, false, "T.N.T.", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000065"), new Guid("00000000-0000-0000-0000-000000000006"), 1, 251373L, false, "Can I Sit Next to You Girl", 6 },
                    { new Guid("00000000-0000-0000-0000-000000000066"), new Guid("00000000-0000-0000-0000-000000000006"), 1, 338306L, false, "Little Lover", 7 },
                    { new Guid("00000000-0000-0000-0000-000000000067"), new Guid("00000000-0000-0000-0000-000000000006"), 1, 291306L, false, "She's Got Balls", 8 },
                    { new Guid("00000000-0000-0000-0000-000000000068"), new Guid("00000000-0000-0000-0000-000000000006"), 1, 254200L, false, "High Voltage", 9 },
                    { new Guid("00000000-0000-0000-0000-000000000069"), new Guid("00000000-0000-0000-0000-000000000007"), 1, 301920L, false, "Smells Like Teen Spirit", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000070"), new Guid("00000000-0000-0000-0000-000000000007"), 1, 255080L, false, "In Bloom - Nevermind Version", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000071"), new Guid("00000000-0000-0000-0000-000000000007"), 1, 218920L, false, "Come As You Are", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000072"), new Guid("00000000-0000-0000-0000-000000000007"), 1, 184040L, false, "Breed", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000073"), new Guid("00000000-0000-0000-0000-000000000007"), 1, 257053L, false, "Lithium", 5 },
                    { new Guid("00000000-0000-0000-0000-000000000074"), new Guid("00000000-0000-0000-0000-000000000007"), 1, 173853L, false, "Polly", 6 },
                    { new Guid("00000000-0000-0000-0000-000000000075"), new Guid("00000000-0000-0000-0000-000000000007"), 1, 142946L, false, "Territorial Pissings", 7 },
                    { new Guid("00000000-0000-0000-0000-000000000076"), new Guid("00000000-0000-0000-0000-000000000007"), 1, 223880L, false, "Drain You", 8 },
                    { new Guid("00000000-0000-0000-0000-000000000077"), new Guid("00000000-0000-0000-0000-000000000007"), 1, 156426L, false, "Lounge Act", 9 },
                    { new Guid("00000000-0000-0000-0000-000000000078"), new Guid("00000000-0000-0000-0000-000000000007"), 1, 211440L, false, "Stay Away", 10 },
                    { new Guid("00000000-0000-0000-0000-000000000079"), new Guid("00000000-0000-0000-0000-000000000007"), 1, 194426L, false, "On A Plain", 11 },
                    { new Guid("00000000-0000-0000-0000-000000000080"), new Guid("00000000-0000-0000-0000-000000000007"), 1, 232146L, false, "Something In The Way", 12 },
                    { new Guid("00000000-0000-0000-0000-000000000081"), new Guid("00000000-0000-0000-0000-000000000007"), 1, 403293L, false, "Endless, Nameless", 13 },
                    { new Guid("00000000-0000-0000-0000-000000000082"), new Guid("00000000-0000-0000-0000-000000000008"), 1, 218000L, false, "About A Girl", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000056"), new Guid("00000000-0000-0000-0000-000000000005"), 1, 154506L, false, "Get It Hot", 7 },
                    { new Guid("00000000-0000-0000-0000-000000000226"), new Guid("00000000-0000-0000-0000-000000000017"), 2, 429198L, false, "Spit Out The Bone", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistId",
                table: "Album",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistGenre_GenreId",
                table: "ArtistGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_AlbumId",
                table: "Track",
                column: "AlbumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistGenre");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Artist");
        }
    }
}
