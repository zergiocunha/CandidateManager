using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateManager.Migrations
{
    public partial class OneToOne3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "candidates",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_candidateexperiences_IdCandidate",
                table: "candidateexperiences",
                column: "IdCandidate");

            migrationBuilder.AddForeignKey(
                name: "FK_candidateexperiences_candidates_IdCandidate",
                table: "candidateexperiences",
                column: "IdCandidate",
                principalTable: "candidates",
                principalColumn: "IdCandidate",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidateexperiences_candidates_IdCandidate",
                table: "candidateexperiences");

            migrationBuilder.DropIndex(
                name: "IX_candidateexperiences_IdCandidate",
                table: "candidateexperiences");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertDate",
                table: "candidates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
