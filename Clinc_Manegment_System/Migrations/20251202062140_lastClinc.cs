using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinc_Manegment_System.Migrations
{
    /// <inheritdoc />
    public partial class lastClinc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dosage",
                table: "Medications");

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "Medications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Medications_PatientId",
                table: "Medications",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Pationts_PatientId",
                table: "Medications",
                column: "PatientId",
                principalTable: "Pationts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Pationts_PatientId",
                table: "Medications");

            migrationBuilder.DropIndex(
                name: "IX_Medications_PatientId",
                table: "Medications");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Medications");

            migrationBuilder.AddColumn<string>(
                name: "Dosage",
                table: "Medications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
