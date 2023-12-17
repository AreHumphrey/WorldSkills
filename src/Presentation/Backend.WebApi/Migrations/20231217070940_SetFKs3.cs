using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SetFKs3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetencesChampionships_Championships_Id",
                table: "CompetencesChampionships");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetencesChampionships_Competences_Competence_code",
                table: "CompetencesChampionships");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersChampionships_Championships_Id",
                table: "UsersChampionships");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersCompetences_Competences_Competence_code",
                table: "UsersCompetences");

            migrationBuilder.DropIndex(
                name: "IX_UsersCompetences_Competence_code",
                table: "UsersCompetences");

            migrationBuilder.DropIndex(
                name: "IX_CompetencesChampionships_Competence_code",
                table: "CompetencesChampionships");

            migrationBuilder.DropColumn(
                name: "Competence_code",
                table: "UsersCompetences");

            migrationBuilder.DropColumn(
                name: "Competence_code",
                table: "CompetencesChampionships");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UsersChampionships",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CompetencesChampionships",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersCompetences_CompetenceId",
                table: "UsersCompetences",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersChampionships_ChampionshipsId",
                table: "UsersChampionships",
                column: "ChampionshipsId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetencesChampionships_ChampionshipsId",
                table: "CompetencesChampionships",
                column: "ChampionshipsId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetencesChampionships_CompetenceId",
                table: "CompetencesChampionships",
                column: "CompetenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetencesChampionships_Championships_ChampionshipsId",
                table: "CompetencesChampionships",
                column: "ChampionshipsId",
                principalTable: "Championships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetencesChampionships_Competences_CompetenceId",
                table: "CompetencesChampionships",
                column: "CompetenceId",
                principalTable: "Competences",
                principalColumn: "Competence_code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersChampionships_Championships_ChampionshipsId",
                table: "UsersChampionships",
                column: "ChampionshipsId",
                principalTable: "Championships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCompetences_Competences_CompetenceId",
                table: "UsersCompetences",
                column: "CompetenceId",
                principalTable: "Competences",
                principalColumn: "Competence_code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetencesChampionships_Championships_ChampionshipsId",
                table: "CompetencesChampionships");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetencesChampionships_Competences_CompetenceId",
                table: "CompetencesChampionships");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersChampionships_Championships_ChampionshipsId",
                table: "UsersChampionships");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersCompetences_Competences_CompetenceId",
                table: "UsersCompetences");

            migrationBuilder.DropIndex(
                name: "IX_UsersCompetences_CompetenceId",
                table: "UsersCompetences");

            migrationBuilder.DropIndex(
                name: "IX_UsersChampionships_ChampionshipsId",
                table: "UsersChampionships");

            migrationBuilder.DropIndex(
                name: "IX_CompetencesChampionships_ChampionshipsId",
                table: "CompetencesChampionships");

            migrationBuilder.DropIndex(
                name: "IX_CompetencesChampionships_CompetenceId",
                table: "CompetencesChampionships");

            migrationBuilder.AddColumn<string>(
                name: "Competence_code",
                table: "UsersCompetences",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UsersChampionships",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CompetencesChampionships",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Competence_code",
                table: "CompetencesChampionships",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersCompetences_Competence_code",
                table: "UsersCompetences",
                column: "Competence_code");

            migrationBuilder.CreateIndex(
                name: "IX_CompetencesChampionships_Competence_code",
                table: "CompetencesChampionships",
                column: "Competence_code");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetencesChampionships_Championships_Id",
                table: "CompetencesChampionships",
                column: "Id",
                principalTable: "Championships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetencesChampionships_Competences_Competence_code",
                table: "CompetencesChampionships",
                column: "Competence_code",
                principalTable: "Competences",
                principalColumn: "Competence_code");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersChampionships_Championships_Id",
                table: "UsersChampionships",
                column: "Id",
                principalTable: "Championships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCompetences_Competences_Competence_code",
                table: "UsersCompetences",
                column: "Competence_code",
                principalTable: "Competences",
                principalColumn: "Competence_code");
        }
    }
}
