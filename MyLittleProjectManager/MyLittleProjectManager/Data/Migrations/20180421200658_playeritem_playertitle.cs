using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyLittleProjectManager.Data.Migrations
{
    public partial class playeritem_playertitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_PlayerProfiles_PlayerProfileId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerProfiles_Titles_SelectedTitleId",
                table: "PlayerProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Titles_PlayerProfiles_PlayerProfileId",
                table: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_Titles_PlayerProfileId",
                table: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_PlayerProfiles_SelectedTitleId",
                table: "PlayerProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Items_PlayerProfileId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PlayerProfileId",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "PlayerProfileId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "SelectedTitleId",
                table: "PlayerProfiles",
                newName: "SelectedTitleTitleId");

            migrationBuilder.AddColumn<int>(
                name: "SelectedTitlePlayerId",
                table: "PlayerProfiles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlayerItem",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerItem", x => new { x.ItemId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_PlayerItem_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerItem_PlayerProfiles_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "PlayerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTitle",
                columns: table => new
                {
                    TitleId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTitle", x => new { x.TitleId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_PlayerTitle_PlayerProfiles_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "PlayerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTitle_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerProfiles_SelectedTitleTitleId_SelectedTitlePlayerId",
                table: "PlayerProfiles",
                columns: new[] { "SelectedTitleTitleId", "SelectedTitlePlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerItem_PlayerId",
                table: "PlayerItem",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTitle_PlayerId",
                table: "PlayerTitle",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerProfiles_PlayerTitle_SelectedTitleTitleId_SelectedTitlePlayerId",
                table: "PlayerProfiles",
                columns: new[] { "SelectedTitleTitleId", "SelectedTitlePlayerId" },
                principalTable: "PlayerTitle",
                principalColumns: new[] { "TitleId", "PlayerId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerProfiles_PlayerTitle_SelectedTitleTitleId_SelectedTitlePlayerId",
                table: "PlayerProfiles");

            migrationBuilder.DropTable(
                name: "PlayerItem");

            migrationBuilder.DropTable(
                name: "PlayerTitle");

            migrationBuilder.DropIndex(
                name: "IX_PlayerProfiles_SelectedTitleTitleId_SelectedTitlePlayerId",
                table: "PlayerProfiles");

            migrationBuilder.DropColumn(
                name: "SelectedTitlePlayerId",
                table: "PlayerProfiles");

            migrationBuilder.RenameColumn(
                name: "SelectedTitleTitleId",
                table: "PlayerProfiles",
                newName: "SelectedTitleId");

            migrationBuilder.AddColumn<int>(
                name: "PlayerProfileId",
                table: "Titles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerProfileId",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Titles_PlayerProfileId",
                table: "Titles",
                column: "PlayerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerProfiles_SelectedTitleId",
                table: "PlayerProfiles",
                column: "SelectedTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PlayerProfileId",
                table: "Items",
                column: "PlayerProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_PlayerProfiles_PlayerProfileId",
                table: "Items",
                column: "PlayerProfileId",
                principalTable: "PlayerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerProfiles_Titles_SelectedTitleId",
                table: "PlayerProfiles",
                column: "SelectedTitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_PlayerProfiles_PlayerProfileId",
                table: "Titles",
                column: "PlayerProfileId",
                principalTable: "PlayerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
