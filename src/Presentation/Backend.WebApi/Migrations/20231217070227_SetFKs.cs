using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SetFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Competence_code",
                table: "UsersCompetences",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId1",
                table: "UsersCompetences",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UsersChampionships",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId1",
                table: "UsersChampionships",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

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
                name: "IX_UsersCompetences_UsersId",
                table: "UsersCompetences",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCompetences_UsersId1",
                table: "UsersCompetences",
                column: "UsersId1");

            migrationBuilder.CreateIndex(
                name: "IX_UsersChampionships_UsersId",
                table: "UsersChampionships",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersChampionships_UsersId1",
                table: "UsersChampionships",
                column: "UsersId1");

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
                name: "FK_UsersChampionships_AspNetUsers_UsersId",
                table: "UsersChampionships",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersChampionships_AspNetUsers_UsersId1",
                table: "UsersChampionships",
                column: "UsersId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersChampionships_Championships_Id",
                table: "UsersChampionships",
                column: "Id",
                principalTable: "Championships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCompetences_AspNetUsers_UsersId",
                table: "UsersCompetences",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCompetences_AspNetUsers_UsersId1",
                table: "UsersCompetences",
                column: "UsersId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCompetences_Competences_Competence_code",
                table: "UsersCompetences",
                column: "Competence_code",
                principalTable: "Competences",
                principalColumn: "Competence_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetencesChampionships_Championships_Id",
                table: "CompetencesChampionships");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetencesChampionships_Competences_Competence_code",
                table: "CompetencesChampionships");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersChampionships_AspNetUsers_UsersId",
                table: "UsersChampionships");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersChampionships_AspNetUsers_UsersId1",
                table: "UsersChampionships");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersChampionships_Championships_Id",
                table: "UsersChampionships");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersCompetences_AspNetUsers_UsersId",
                table: "UsersCompetences");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersCompetences_AspNetUsers_UsersId1",
                table: "UsersCompetences");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersCompetences_Competences_Competence_code",
                table: "UsersCompetences");

            migrationBuilder.DropIndex(
                name: "IX_UsersCompetences_Competence_code",
                table: "UsersCompetences");

            migrationBuilder.DropIndex(
                name: "IX_UsersCompetences_UsersId",
                table: "UsersCompetences");

            migrationBuilder.DropIndex(
                name: "IX_UsersCompetences_UsersId1",
                table: "UsersCompetences");

            migrationBuilder.DropIndex(
                name: "IX_UsersChampionships_UsersId",
                table: "UsersChampionships");

            migrationBuilder.DropIndex(
                name: "IX_UsersChampionships_UsersId1",
                table: "UsersChampionships");

            migrationBuilder.DropIndex(
                name: "IX_CompetencesChampionships_Competence_code",
                table: "CompetencesChampionships");

            migrationBuilder.DropColumn(
                name: "Competence_code",
                table: "UsersCompetences");

            migrationBuilder.DropColumn(
                name: "UsersId1",
                table: "UsersCompetences");

            migrationBuilder.DropColumn(
                name: "UsersId1",
                table: "UsersChampionships");

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
        }
    }
}
