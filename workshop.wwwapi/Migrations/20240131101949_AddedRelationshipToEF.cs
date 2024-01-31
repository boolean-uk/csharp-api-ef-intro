using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationshipToEF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_bandmembers_fk_band_id",
                table: "bandmembers",
                column: "fk_band_id");

            migrationBuilder.AddForeignKey(
                name: "FK_bandmembers_bands_fk_band_id",
                table: "bandmembers",
                column: "fk_band_id",
                principalTable: "bands",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bandmembers_bands_fk_band_id",
                table: "bandmembers");

            migrationBuilder.DropIndex(
                name: "IX_bandmembers_fk_band_id",
                table: "bandmembers");
        }
    }
}
