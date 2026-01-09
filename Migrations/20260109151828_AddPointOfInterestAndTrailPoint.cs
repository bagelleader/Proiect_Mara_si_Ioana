using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuntiRomania.Migrations
{
    /// <inheritdoc />
    public partial class AddPointOfInterestAndTrailPoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PointsOfInterest",
                columns: table => new
                {
                    PointOfInterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsOfInterest", x => x.PointOfInterestId);
                });

            migrationBuilder.CreateTable(
                name: "TrailPoints",
                columns: table => new
                {
                    TrailId = table.Column<int>(type: "int", nullable: false),
                    PointOfInterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrailPoints", x => new { x.TrailId, x.PointOfInterestId });
                    table.ForeignKey(
                        name: "FK_TrailPoints_PointsOfInterest_PointOfInterestId",
                        column: x => x.PointOfInterestId,
                        principalTable: "PointsOfInterest",
                        principalColumn: "PointOfInterestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrailPoints_Trails_TrailId",
                        column: x => x.TrailId,
                        principalTable: "Trails",
                        principalColumn: "TrailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrailPoints_PointOfInterestId",
                table: "TrailPoints",
                column: "PointOfInterestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrailPoints");

            migrationBuilder.DropTable(
                name: "PointsOfInterest");
        }
    }
}
