using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddChampToresults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Results_Competitionship_code",
                table: "Results",
                column: "Competitionship_code");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Championships_Competitionship_code",
                table: "Results",
                column: "Competitionship_code",
                principalTable: "Championships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Championships_Competitionship_code",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_Competitionship_code",
                table: "Results");
        }
    }
}
