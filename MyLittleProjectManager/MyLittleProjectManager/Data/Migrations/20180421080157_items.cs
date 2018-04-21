using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyLittleProjectManager.Data.Migrations
{
    public partial class items : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<int>(
                name: "PlayerProfileId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageLink = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PlayerProfileId = table.Column<int>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerProfileId = table.Column<int>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerProfile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MICoins = table.Column<int>(nullable: false),
                    Pseudo = table.Column<string>(nullable: true),
                    SelectedItemsJson = table.Column<string>(nullable: true),
                    SelectedTitleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerProfile_Title_SelectedTitleId",
                        column: x => x.SelectedTitleId,
                        principalTable: "Title",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PlayerProfileId",
                table: "AspNetUsers",
                column: "PlayerProfileId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Item_PlayerProfileId",
                table: "Item",
                column: "PlayerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerProfile_SelectedTitleId",
                table: "PlayerProfile",
                column: "SelectedTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Title_PlayerProfileId",
                table: "Title",
                column: "PlayerProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PlayerProfile_PlayerProfileId",
                table: "AspNetUsers",
                column: "PlayerProfileId",
                principalTable: "PlayerProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_PlayerProfile_PlayerProfileId",
                table: "Item",
                column: "PlayerProfileId",
                principalTable: "PlayerProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Title_PlayerProfile_PlayerProfileId",
                table: "Title",
                column: "PlayerProfileId",
                principalTable: "PlayerProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PlayerProfile_PlayerProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Title_PlayerProfile_PlayerProfileId",
                table: "Title");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "PlayerProfile");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PlayerProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "PlayerProfileId",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
