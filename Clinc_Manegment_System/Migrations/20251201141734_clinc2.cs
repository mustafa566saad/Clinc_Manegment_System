using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinc_Manegment_System.Migrations
{
    /// <inheritdoc />
    public partial class clinc2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Diagnoses_PationtId",
                table: "Diagnoses");

            migrationBuilder.AddColumn<string>(
                name: "DiagnosisId",
                table: "Pationts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pationts_DiagnosisId",
                table: "Pationts",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_PationtId",
                table: "Diagnoses",
                column: "PationtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pationts_Diagnoses_DiagnosisId",
                table: "Pationts",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pationts_Diagnoses_DiagnosisId",
                table: "Pationts");

            migrationBuilder.DropIndex(
                name: "IX_Pationts_DiagnosisId",
                table: "Pationts");

            migrationBuilder.DropIndex(
                name: "IX_Diagnoses_PationtId",
                table: "Diagnoses");

            migrationBuilder.DropColumn(
                name: "DiagnosisId",
                table: "Pationts");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_PationtId",
                table: "Diagnoses",
                column: "PationtId",
                unique: true);
        }
    }
}
