using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlaylistApi.Backend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExternalId = table.Column<string>(nullable: true),
                    DanceabilityMin = table.Column<double>(nullable: false),
                    DanceabilityMax = table.Column<double>(nullable: false),
                    EnergyMin = table.Column<double>(nullable: false),
                    EnergyMax = table.Column<double>(nullable: false),
                    ValenceMin = table.Column<double>(nullable: false),
                    ValenceMax = table.Column<double>(nullable: false),
                    Overall = table.Column<double>(nullable: false),
                    HighestRatedTrackId = table.Column<string>(nullable: true),
                    LowestRatedTrackId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistTracks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExternalId = table.Column<string>(nullable: true),
                    Danceability = table.Column<double>(nullable: false),
                    Energy = table.Column<double>(nullable: false),
                    Valence = table.Column<double>(nullable: false),
                    Popularity = table.Column<int>(nullable: false),
                    Artists = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PreviewUrl = table.Column<string>(nullable: true),
                    PlaylistModelId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistTracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaylistTracks_Playlists_PlaylistModelId",
                        column: x => x.PlaylistModelId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistTracks_PlaylistModelId",
                table: "PlaylistTracks",
                column: "PlaylistModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistTracks");

            migrationBuilder.DropTable(
                name: "Playlists");
        }
    }
}
