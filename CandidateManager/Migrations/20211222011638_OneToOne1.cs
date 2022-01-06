using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateManager.Migrations
{
    public partial class OneToOne1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CandidateIdCandidate",
                table: "candidateexperiences",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_candidateexperiences_CandidateIdCandidate",
                table: "candidateexperiences",
                column: "CandidateIdCandidate");

            migrationBuilder.AddForeignKey(
                name: "FK_candidateexperiences_candidates_CandidateIdCandidate",
                table: "candidateexperiences",
                column: "CandidateIdCandidate",
                principalTable: "candidates",
                principalColumn: "IdCandidate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidateexperiences_candidates_CandidateIdCandidate",
                table: "candidateexperiences");

            migrationBuilder.DropIndex(
                name: "IX_candidateexperiences_CandidateIdCandidate",
                table: "candidateexperiences");

            migrationBuilder.DropColumn(
                name: "CandidateIdCandidate",
                table: "candidateexperiences");
        }
    }
}
