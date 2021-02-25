using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningToolMVC.Migrations
{
    public partial class AddAttemptModelToDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttemptModel_Definitions_DefinitionId",
                table: "AttemptModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttemptModel",
                table: "AttemptModel");

            migrationBuilder.RenameTable(
                name: "AttemptModel",
                newName: "Attempts");

            migrationBuilder.RenameIndex(
                name: "IX_AttemptModel_DefinitionId",
                table: "Attempts",
                newName: "IX_Attempts_DefinitionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attempts",
                table: "Attempts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attempts_Definitions_DefinitionId",
                table: "Attempts",
                column: "DefinitionId",
                principalTable: "Definitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attempts_Definitions_DefinitionId",
                table: "Attempts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attempts",
                table: "Attempts");

            migrationBuilder.RenameTable(
                name: "Attempts",
                newName: "AttemptModel");

            migrationBuilder.RenameIndex(
                name: "IX_Attempts_DefinitionId",
                table: "AttemptModel",
                newName: "IX_AttemptModel_DefinitionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttemptModel",
                table: "AttemptModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttemptModel_Definitions_DefinitionId",
                table: "AttemptModel",
                column: "DefinitionId",
                principalTable: "Definitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
