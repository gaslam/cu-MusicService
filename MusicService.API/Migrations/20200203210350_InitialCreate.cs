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
                    Name = table.Column<string>(nullable: true),
                    Followers = table.Column<long>(nullable: false)
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
                    Name = table.Column<string>(nullable: true),
                    ArtistId = table.Column<Guid>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false)
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
                name: "ArtistGenres",
                columns: table => new
                {
                    ArtistId = table.Column<Guid>(nullable: false),
                    GenreId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistGenres", x => new { x.ArtistId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_ArtistGenres_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistGenres_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Width = table.Column<int>(nullable: false),
                    AlbumId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AlbumId = table.Column<Guid>(nullable: true),
                    DurationMs = table.Column<long>(nullable: false),
                    Explicit = table.Column<bool>(nullable: false),
                    TrackNumber = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Track_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArtistImages",
                columns: table => new
                {
                    ArtistId = table.Column<Guid>(nullable: false),
                    ImageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistImages", x => new { x.ArtistId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_ArtistImages_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistImages_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "Id", "Followers", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), 143599L, "Triggerfinger" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 14124193L, "AC/DC" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 10222671L, "Nirvana" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), 12999L, "Flip Kowlier" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), 13031380L, "Metallica" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000018"), "West-vlaamse hip hop" },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "Kleinkunst" },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "Classic belgian pop" },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "Permanent wave" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "Grunge" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "Alternative rock" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "Australian rock" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Album rock" },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "Post-grunge" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Dutch indie" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Belgian rock" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Trash metal" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Speed metal" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Rock" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Old school trash" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Metal" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Hard rock" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Dutch rock" }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AlbumId", "Height", "Url", "Width" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000015"), null, 640, "https://i.scdn.co/image/5a06711d7fc48d5e0e3f9a3274ffed3f0af1bd91", 640 },
                    { new Guid("00000000-0000-0000-0000-000000000014"), null, 160, "https://i.scdn.co/image/5bc9e60072958ace6e07fdd0c0dbeb65bd8764f3", 160 },
                    { new Guid("00000000-0000-0000-0000-000000000013"), null, 320, "https://i.scdn.co/image/b3897cc5dac721abe76fdf7c7266b3f9b51af73f", 320 },
                    { new Guid("00000000-0000-0000-0000-000000000012"), null, 640, "https://i.scdn.co/image/f51258ac754739045b0956cdb1f7a3332fc46754", 640 },
                    { new Guid("00000000-0000-0000-0000-000000000011"), null, 68, "https://i.scdn.co/image/e797ad36d56c3fc8fa06c6fe91263a15bf8391b8", 64 },
                    { new Guid("00000000-0000-0000-0000-000000000010"), null, 211, "https://i.scdn.co/image/42ae0f180f16e2f21c1f2212717fc436f5b95451", 200 },
                    { new Guid("00000000-0000-0000-0000-000000000009"), null, 677, "https://i.scdn.co/image/a4e10b79a642e9891383448cbf37d7266a6883d6", 640 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), null, 1500, "https://i.scdn.co/image/a16c5d95ede008ec905d6ca6d1b5abbf39ad4566", 1000 },
                    { new Guid("00000000-0000-0000-0000-000000000007"), null, 96, "https://i.scdn.co/image/2940421b19c6b8a26b073ef340290516ea0399e1", 64 },
                    { new Guid("00000000-0000-0000-0000-000000000006"), null, 300, "https://i.scdn.co/image/3d00e92fb05c62e2faf2908b34e6f24e0a4cb213", 200 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), null, 640, "https://i.scdn.co/image/fb26e1c0e5779ac46b225651494ac14b6b8ebba7", 1000 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), null, 160, "https://i.scdn.co/image/13fd1ee7b9f8d3b1ca57d086d6ed7c171d052eb4", 160 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), null, 320, "https://i.scdn.co/image/8df00a835ac66507a55b6572491750bd41c7278c", 320 },
                    { new Guid("00000000-0000-0000-0000-000000000001"), null, 640, "https://i.scdn.co/image/b59c74329496a6256355648f005cffcf1fd76dc9", 640 },
                    { new Guid("00000000-0000-0000-0000-000000000016"), null, 320, "https://i.scdn.co/image/0c22030833eb55c14013bb36eb6a429328868c29", 320 },
                    { new Guid("00000000-0000-0000-0000-000000000008"), null, 1057, "https://i.scdn.co/image/84282c28d851a700132356381fcfbadc67ff498b", 1000 },
                    { new Guid("00000000-0000-0000-0000-000000000017"), null, 160, "https://i.scdn.co/image/c1fb4d88de092b5617e649bd4c406b5cab7d3ddd", 160 }
                });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "Id", "ArtistId", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), "What Grabs Ya?", new DateTime(2008, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new Guid("00000000-0000-0000-0000-000000000005"), "Hardwired...To Self-Destruct", new DateTime(2016, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new Guid("00000000-0000-0000-0000-000000000005"), "Garage Inc.", new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000005"), "Metallica", new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000005"), "Master Of Puppets", new DateTime(1986, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000004"), "10 Jaar Flip Kowlier", new DateTime(2011, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000004"), "In De Fik", new DateTime(2004, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000004"), "Ocharme Ik", new DateTime(2001, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new Guid("00000000-0000-0000-0000-000000000005"), "...And Justice For All", new DateTime(1988, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000003"), "MTV Unplugged In New York", new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000003"), "Nevermind", new DateTime(1991, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000002"), "High Voltage", new DateTime(1976, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000002"), "Highway to Hell", new DateTime(1979, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000002"), "Back In Black", new DateTime(1980, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001"), "TF20 - VAULT", new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001"), "Faders Up 2 - Live in Amsterdam", new DateTime(2012, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000003"), "Live at Reading", new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ArtistGenres",
                columns: new[] { "ArtistId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000011") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000012") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000012") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000013") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000017") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000016") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000018") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000014") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.InsertData(
                table: "ArtistImages",
                columns: new[] { "ArtistId", "ImageId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000014") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000013") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000012") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000011") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000016") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000017") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistId",
                table: "Album",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistGenres_GenreId",
                table: "ArtistGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistImages_ImageId",
                table: "ArtistImages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_AlbumId",
                table: "Image",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_AlbumId",
                table: "Track",
                column: "AlbumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistGenres");

            migrationBuilder.DropTable(
                name: "ArtistImages");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Artist");
        }
    }
}
