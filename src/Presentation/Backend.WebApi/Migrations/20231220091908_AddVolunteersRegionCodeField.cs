using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddVolunteersRegionCodeField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Volunteers_Regions_RegionCode",
                table: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_Volunteers_RegionCode",
                table: "Volunteers");

            migrationBuilder.AddColumn<int>(
                name: "RegionsId",
                table: "Volunteers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_RegionsId",
                table: "Volunteers",
                column: "RegionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteers_Regions_RegionsId",
                table: "Volunteers",
                column: "RegionsId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Volunteers_Regions_RegionsId",
                table: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_Volunteers_RegionsId",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "RegionsId",
                table: "Volunteers");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_RegionCode",
                table: "Volunteers",
                column: "RegionCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteers_Regions_RegionCode",
                table: "Volunteers",
                column: "RegionCode",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
