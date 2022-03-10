using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.ProfileService.Infrastructure.Persistence.Migrations
{
    public partial class RefactoredProfileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Profiles_ProfileId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Profiles_ProfileId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Skills",
                newName: "MyProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_ProfileId",
                table: "Skills",
                newName: "IX_Skills_MyProfileId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Experiences",
                newName: "MyProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_ProfileId",
                table: "Experiences",
                newName: "IX_Experiences_MyProfileId");

            migrationBuilder.CreateTable(
                name: "MyProfiles",
                columns: table => new
                {
                    MyProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    SkillId = table.Column<int>(type: "int", nullable: true),
                    ExperienceId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyProfiles", x => x.MyProfileId);
                    table.ForeignKey(
                        name: "FK_MyProfiles_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyProfiles_ContactId",
                table: "MyProfiles",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_MyProfiles_MyProfileId",
                table: "Experiences",
                column: "MyProfileId",
                principalTable: "MyProfiles",
                principalColumn: "MyProfileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_MyProfiles_MyProfileId",
                table: "Skills",
                column: "MyProfileId",
                principalTable: "MyProfiles",
                principalColumn: "MyProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_MyProfiles_MyProfileId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_MyProfiles_MyProfileId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "MyProfiles");

            migrationBuilder.RenameColumn(
                name: "MyProfileId",
                table: "Skills",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_MyProfileId",
                table: "Skills",
                newName: "IX_Skills_ProfileId");

            migrationBuilder.RenameColumn(
                name: "MyProfileId",
                table: "Experiences",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_MyProfileId",
                table: "Experiences",
                newName: "IX_Experiences_ProfileId");

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_Profiles_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ContactId",
                table: "Profiles",
                column: "ContactId");

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
    }
}
