using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateManager.Migrations
{
    public partial class OneToOne5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_candidates_Email",
                table: "candidates",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_candidates_Email",
                table: "candidates");
        }
    }
}
