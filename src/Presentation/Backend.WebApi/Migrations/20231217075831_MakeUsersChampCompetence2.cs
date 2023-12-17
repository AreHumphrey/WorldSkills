using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class MakeUsersChampCompetence2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersChampionships_AspNetUsers_UsersId",
                table: "UsersChampionships");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersChampionships_Championships_ChampionshipsId",
                table: "UsersChampionships");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersChampionships_Competences_CompetenceIdId",
                table: "UsersChampionships");

            migrationBuilder.DropTable(
                name: "UsersCompetences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersChampionships",
                table: "UsersChampionships");

            migrationBuilder.DropIndex(
                name: "IX_UsersChampionships_CompetenceIdId",
                table: "UsersChampionships");

            migrationBuilder.DropColumn(
                name: "CompetenceIdId",
                table: "UsersChampionships");

            migrationBuilder.RenameTable(
                name: "UsersChampionships",
                newName: "UsersChampionshipsCompetences");

            migrationBuilder.RenameIndex(
                name: "IX_UsersChampionships_UsersId",
                table: "UsersChampionshipsCompetences",
                newName: "IX_UsersChampionshipsCompetences_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersChampionships_ChampionshipsId",
                table: "UsersChampionshipsCompetences",
                newName: "IX_UsersChampionshipsCompetences_ChampionshipsId");

            migrationBuilder.AlterColumn<string>(
                name: "CompetenceId",
                table: "UsersChampionshipsCompetences",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersChampionshipsCompetences",
                table: "UsersChampionshipsCompetences",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ExpertCompetences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsersId = table.Column<string>(type: "TEXT", nullable: false),
                    CompetenceId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertCompetences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpertCompetences_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertCompetences_Competences_CompetenceId",
                        column: x => x.CompetenceId,
                        principalTable: "Competences",
                        principalColumn: "Competence_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersChampionshipsCompetences_CompetenceId",
                table: "UsersChampionshipsCompetences",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertCompetences_CompetenceId",
                table: "ExpertCompetences",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertCompetences_UsersId",
                table: "ExpertCompetences",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersChampionshipsCompetences_AspNetUsers_UsersId",
                table: "UsersChampionshipsCompetences",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersChampionshipsCompetences_Championships_ChampionshipsId",
                table: "UsersChampionshipsCompetences",
                column: "ChampionshipsId",
                principalTable: "Championships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersChampionshipsCompetences_Competences_CompetenceId",
                table: "UsersChampionshipsCompetences",
                column: "CompetenceId",
                principalTable: "Competences",
                principalColumn: "Competence_code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersChampionshipsCompetences_AspNetUsers_UsersId",
                table: "UsersChampionshipsCompetences");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersChampionshipsCompetences_Championships_ChampionshipsId",
                table: "UsersChampionshipsCompetences");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersChampionshipsCompetences_Competences_CompetenceId",
                table: "UsersChampionshipsCompetences");

            migrationBuilder.DropTable(
                name: "ExpertCompetences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersChampionshipsCompetences",
                table: "UsersChampionshipsCompetences");

            migrationBuilder.DropIndex(
                name: "IX_UsersChampionshipsCompetences_CompetenceId",
                table: "UsersChampionshipsCompetences");

            migrationBuilder.RenameTable(
                name: "UsersChampionshipsCompetences",
                newName: "UsersChampionships");

            migrationBuilder.RenameIndex(
                name: "IX_UsersChampionshipsCompetences_UsersId",
                table: "UsersChampionships",
                newName: "IX_UsersChampionships_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersChampionshipsCompetences_ChampionshipsId",
                table: "UsersChampionships",
                newName: "IX_UsersChampionships_ChampionshipsId");

            migrationBuilder.AlterColumn<int>(
                name: "CompetenceId",
                table: "UsersChampionships",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "CompetenceIdId",
                table: "UsersChampionships",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersChampionships",
                table: "UsersChampionships",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UsersCompetences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompetenceId = table.Column<string>(type: "TEXT", nullable: false),
                    UsersId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCompetences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersCompetences_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersCompetences_Competences_CompetenceId",
                        column: x => x.CompetenceId,
                        principalTable: "Competences",
                        principalColumn: "Competence_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersChampionships_CompetenceIdId",
                table: "UsersChampionships",
                column: "CompetenceIdId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCompetences_CompetenceId",
                table: "UsersCompetences",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCompetences_UsersId",
                table: "UsersCompetences",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersChampionships_AspNetUsers_UsersId",
                table: "UsersChampionships",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersChampionships_Championships_ChampionshipsId",
                table: "UsersChampionships",
                column: "ChampionshipsId",
                principalTable: "Championships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersChampionships_Competences_CompetenceIdId",
                table: "UsersChampionships",
                column: "CompetenceIdId",
                principalTable: "Competences",
                principalColumn: "Competence_code");
        }
    }
}
