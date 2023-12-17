using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class MakeUsersChampCompetence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompetenceId",
                table: "UsersChampionships",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CompetenceIdId",
                table: "UsersChampionships",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersChampionships_CompetenceIdId",
                table: "UsersChampionships",
                column: "CompetenceIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersChampionships_Competences_CompetenceIdId",
                table: "UsersChampionships",
                column: "CompetenceIdId",
                principalTable: "Competences",
                principalColumn: "Competence_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersChampionships_Competences_CompetenceIdId",
                table: "UsersChampionships");

            migrationBuilder.DropIndex(
                name: "IX_UsersChampionships_CompetenceIdId",
                table: "UsersChampionships");

            migrationBuilder.DropColumn(
                name: "CompetenceId",
                table: "UsersChampionships");

            migrationBuilder.DropColumn(
                name: "CompetenceIdId",
                table: "UsersChampionships");
        }
    }
}
