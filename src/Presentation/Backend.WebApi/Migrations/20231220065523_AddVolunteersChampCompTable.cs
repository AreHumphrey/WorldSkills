using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddVolunteersChampCompTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VolunteersChampionshipsCompetences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VolunteerId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChampionshipsId = table.Column<int>(type: "INTEGER", nullable: false),
                    CompetenceId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteersChampionshipsCompetences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VolunteersChampionshipsCompetences_Championships_ChampionshipsId",
                        column: x => x.ChampionshipsId,
                        principalTable: "Championships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteersChampionshipsCompetences_Competences_CompetenceId",
                        column: x => x.CompetenceId,
                        principalTable: "Competences",
                        principalColumn: "Competence_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteersChampionshipsCompetences_Volunteers_VolunteerId",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VolunteersChampionshipsCompetences_ChampionshipsId",
                table: "VolunteersChampionshipsCompetences",
                column: "ChampionshipsId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteersChampionshipsCompetences_CompetenceId",
                table: "VolunteersChampionshipsCompetences",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteersChampionshipsCompetences_VolunteerId",
                table: "VolunteersChampionshipsCompetences",
                column: "VolunteerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VolunteersChampionshipsCompetences");
        }
    }
}
