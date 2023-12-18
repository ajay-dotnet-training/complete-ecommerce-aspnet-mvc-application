using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMovies.Migrations
{
    /// <inheritdoc />
    public partial class AreaModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WebSeriesId",
                table: "Actors_Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WebSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieCategory = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    ProducerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebSeries_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WebSeries_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actors_Movies_WebSeriesId",
                table: "Actors_Movies",
                column: "WebSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_WebSeries_CinemaId",
                table: "WebSeries",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_WebSeries_ProducerId",
                table: "WebSeries",
                column: "ProducerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Movies_WebSeries_WebSeriesId",
                table: "Actors_Movies",
                column: "WebSeriesId",
                principalTable: "WebSeries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Movies_WebSeries_WebSeriesId",
                table: "Actors_Movies");

            migrationBuilder.DropTable(
                name: "WebSeries");

            migrationBuilder.DropIndex(
                name: "IX_Actors_Movies_WebSeriesId",
                table: "Actors_Movies");

            migrationBuilder.DropColumn(
                name: "WebSeriesId",
                table: "Actors_Movies");
        }
    }
}
