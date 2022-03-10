using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.ProfileService.Infrastructure.Persistence.Migrations
{
    public partial class RemovedUnecessaryForeignKeysInProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExperienceId",
                table: "MyProfiles");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "MyProfiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExperienceId",
                table: "MyProfiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "MyProfiles",
                type: "int",
                nullable: true);
        }
    }
}
