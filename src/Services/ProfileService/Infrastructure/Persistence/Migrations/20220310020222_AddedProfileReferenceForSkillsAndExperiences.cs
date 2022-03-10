using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.ProfileService.Infrastructure.Persistence.Migrations
{
    public partial class AddedProfileReferenceForSkillsAndExperiences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExperienceId",
                table: "Profiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "Profiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Experiences",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ProfileId",
                table: "Skills",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ProfileId",
                table: "Experiences",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Profiles_ProfileId",
                table: "Experiences",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Profiles_ProfileId",
                table: "Skills",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Profiles_ProfileId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Profiles_ProfileId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_ProfileId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_ProfileId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ExperienceId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Experiences");
        }
    }
}
