using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyLittleProjectManager.Data.Migrations
{
    public partial class blaaahhhh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerProfiles_PlayerTitles_SelectedTitleTitleId_SelectedTitlePlayerId",
                table: "PlayerProfiles");

            migrationBuilder.DropIndex(
                name: "IX_PlayerProfiles_SelectedTitleTitleId_SelectedTitlePlayerId",
                table: "PlayerProfiles");

            migrationBuilder.DropColumn(
                name: "SelectedTitlePlayerId",
                table: "PlayerProfiles");

            migrationBuilder.DropColumn(
                name: "SelectedTitleTitleId",
                table: "PlayerProfiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SelectedTitlePlayerId",
                table: "PlayerProfiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SelectedTitleTitleId",
                table: "PlayerProfiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerProfiles_SelectedTitleTitleId_SelectedTitlePlayerId",
                table: "PlayerProfiles",
                columns: new[] { "SelectedTitleTitleId", "SelectedTitlePlayerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerProfiles_PlayerTitles_SelectedTitleTitleId_SelectedTitlePlayerId",
                table: "PlayerProfiles",
                columns: new[] { "SelectedTitleTitleId", "SelectedTitlePlayerId" },
                principalTable: "PlayerTitles",
                principalColumns: new[] { "TitleId", "PlayerId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
