using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtMovements",
                columns: table => new
                {
                    IdArtMovement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNextArtMovement = table.Column<int>(type: "int", nullable: false),
                    ArtMovementIdArtMovement = table.Column<int>(type: "int", nullable: true),
                    IdArtist = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateFounded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtMovements", x => x.IdArtMovement);
                    table.ForeignKey(
                        name: "FK_ArtMovements_ArtMovements_ArtMovementIdArtMovement",
                        column: x => x.ArtMovementIdArtMovement,
                        principalTable: "ArtMovements",
                        principalColumn: "IdArtMovement",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    IdCity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Population = table.Column<int>(type: "int", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.IdCity);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    IdArtist = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArtMovement = table.Column<int>(type: "int", nullable: false),
                    ArtMovementIdArtMovement = table.Column<int>(type: "int", nullable: true),
                    IdCityOfBirth = table.Column<int>(type: "int", nullable: false),
                    CityIdCity = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.IdArtist);
                    table.ForeignKey(
                        name: "FK_Artists_ArtMovements_ArtMovementIdArtMovement",
                        column: x => x.ArtMovementIdArtMovement,
                        principalTable: "ArtMovements",
                        principalColumn: "IdArtMovement",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Artists_Cities_CityIdCity",
                        column: x => x.CityIdCity,
                        principalTable: "Cities",
                        principalColumn: "IdCity",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paintings",
                columns: table => new
                {
                    IdPainting = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurfaceType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PaintingMedia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IdArtist = table.Column<int>(type: "int", nullable: false),
                    ArtistIdArtist = table.Column<int>(type: "int", nullable: true),
                    IdCoAuthor = table.Column<int>(type: "int", nullable: true),
                    CoArtistIdArtist = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paintings", x => x.IdPainting);
                    table.ForeignKey(
                        name: "FK_Paintings_Artists_ArtistIdArtist",
                        column: x => x.ArtistIdArtist,
                        principalTable: "Artists",
                        principalColumn: "IdArtist",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paintings_Artists_CoArtistIdArtist",
                        column: x => x.CoArtistIdArtist,
                        principalTable: "Artists",
                        principalColumn: "IdArtist",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artists_ArtMovementIdArtMovement",
                table: "Artists",
                column: "ArtMovementIdArtMovement");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_CityIdCity",
                table: "Artists",
                column: "CityIdCity");

            migrationBuilder.CreateIndex(
                name: "IX_ArtMovements_ArtMovementIdArtMovement",
                table: "ArtMovements",
                column: "ArtMovementIdArtMovement");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_ArtistIdArtist",
                table: "Paintings",
                column: "ArtistIdArtist");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_CoArtistIdArtist",
                table: "Paintings",
                column: "CoArtistIdArtist");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paintings");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "ArtMovements");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
