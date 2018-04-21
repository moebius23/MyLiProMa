using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyLittleProjectManager.Data.Migrations
{
    public partial class jesaispluscequyadedans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerItem_Items_ItemId",
                table: "PlayerItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerItem_PlayerProfiles_PlayerId",
                table: "PlayerItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerProfiles_PlayerTitle_SelectedTitleTitleId_SelectedTitlePlayerId",
                table: "PlayerProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTitle_PlayerProfiles_PlayerId",
                table: "PlayerTitle");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTitle_Titles_TitleId",
                table: "PlayerTitle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerTitle",
                table: "PlayerTitle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerItem",
                table: "PlayerItem");

            migrationBuilder.RenameTable(
                name: "PlayerTitle",
                newName: "PlayerTitles");

            migrationBuilder.RenameTable(
                name: "PlayerItem",
                newName: "PlayerItems");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTitle_PlayerId",
                table: "PlayerTitles",
                newName: "IX_PlayerTitles_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerItem_PlayerId",
                table: "PlayerItems",
                newName: "IX_PlayerItems_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerTitles",
                table: "PlayerTitles",
                columns: new[] { "TitleId", "PlayerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerItems",
                table: "PlayerItems",
                columns: new[] { "ItemId", "PlayerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerItems_Items_ItemId",
                table: "PlayerItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerItems_PlayerProfiles_PlayerId",
                table: "PlayerItems",
                column: "PlayerId",
                principalTable: "PlayerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerProfiles_PlayerTitles_SelectedTitleTitleId_SelectedTitlePlayerId",
                table: "PlayerProfiles",
                columns: new[] { "SelectedTitleTitleId", "SelectedTitlePlayerId" },
                principalTable: "PlayerTitles",
                principalColumns: new[] { "TitleId", "PlayerId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTitles_PlayerProfiles_PlayerId",
                table: "PlayerTitles",
                column: "PlayerId",
                principalTable: "PlayerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTitles_Titles_TitleId",
                table: "PlayerTitles",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerItems_Items_ItemId",
                table: "PlayerItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerItems_PlayerProfiles_PlayerId",
                table: "PlayerItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerProfiles_PlayerTitles_SelectedTitleTitleId_SelectedTitlePlayerId",
                table: "PlayerProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTitles_PlayerProfiles_PlayerId",
                table: "PlayerTitles");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTitles_Titles_TitleId",
                table: "PlayerTitles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerTitles",
                table: "PlayerTitles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerItems",
                table: "PlayerItems");

            migrationBuilder.RenameTable(
                name: "PlayerTitles",
                newName: "PlayerTitle");

            migrationBuilder.RenameTable(
                name: "PlayerItems",
                newName: "PlayerItem");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTitles_PlayerId",
                table: "PlayerTitle",
                newName: "IX_PlayerTitle_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerItems_PlayerId",
                table: "PlayerItem",
                newName: "IX_PlayerItem_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerTitle",
                table: "PlayerTitle",
                columns: new[] { "TitleId", "PlayerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerItem",
                table: "PlayerItem",
                columns: new[] { "ItemId", "PlayerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerItem_Items_ItemId",
                table: "PlayerItem",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerItem_PlayerProfiles_PlayerId",
                table: "PlayerItem",
                column: "PlayerId",
                principalTable: "PlayerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerProfiles_PlayerTitle_SelectedTitleTitleId_SelectedTitlePlayerId",
                table: "PlayerProfiles",
                columns: new[] { "SelectedTitleTitleId", "SelectedTitlePlayerId" },
                principalTable: "PlayerTitle",
                principalColumns: new[] { "TitleId", "PlayerId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTitle_PlayerProfiles_PlayerId",
                table: "PlayerTitle",
                column: "PlayerId",
                principalTable: "PlayerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTitle_Titles_TitleId",
                table: "PlayerTitle",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
