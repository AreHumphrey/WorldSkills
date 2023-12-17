using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SetFKs2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersChampionships_AspNetUsers_UsersId1",
                table: "UsersChampionships");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersCompetences_AspNetUsers_UsersId1",
                table: "UsersCompetences");

            migrationBuilder.DropIndex(
                name: "IX_UsersCompetences_UsersId1",
                table: "UsersCompetences");

            migrationBuilder.DropIndex(
                name: "IX_UsersChampionships_UsersId1",
                table: "UsersChampionships");

            migrationBuilder.DropColumn(
                name: "UsersId1",
                table: "UsersCompetences");

            migrationBuilder.DropColumn(
                name: "UsersId1",
                table: "UsersChampionships");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsersId1",
                table: "UsersCompetences",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsersId1",
                table: "UsersChampionships",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCompetences_UsersId1",
                table: "UsersCompetences",
                column: "UsersId1");

            migrationBuilder.CreateIndex(
                name: "IX_UsersChampionships_UsersId1",
                table: "UsersChampionships",
                column: "UsersId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersChampionships_AspNetUsers_UsersId1",
                table: "UsersChampionships",
                column: "UsersId1",
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
        }
    }
}
