using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyLittleProjectManager.Data.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PlayerProfile_PlayerProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_PlayerProfile_PlayerProfileId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerProfile_Title_SelectedTitleId",
                table: "PlayerProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_Title_PlayerProfile_PlayerProfileId",
                table: "Title");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Title",
                table: "Title");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerProfile",
                table: "PlayerProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Title",
                newName: "Titles");

            migrationBuilder.RenameTable(
                name: "PlayerProfile",
                newName: "PlayerProfiles");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_Title_PlayerProfileId",
                table: "Titles",
                newName: "IX_Titles_PlayerProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerProfile_SelectedTitleId",
                table: "PlayerProfiles",
                newName: "IX_PlayerProfiles_SelectedTitleId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_PlayerProfileId",
                table: "Items",
                newName: "IX_Items_PlayerProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Titles",
                table: "Titles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerProfiles",
                table: "PlayerProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Columns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Columns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Columns_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColumnId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Columns_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "Columns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ColumnId",
                table: "Cards",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_Columns_ProjectId",
                table: "Columns",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PlayerProfiles_PlayerProfileId",
                table: "AspNetUsers",
                column: "PlayerProfileId",
                principalTable: "PlayerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PlayerProfiles_PlayerProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_PlayerProfiles_PlayerProfileId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerProfiles_Titles_SelectedTitleId",
                table: "PlayerProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Titles_PlayerProfiles_PlayerProfileId",
                table: "Titles");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Columns");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Titles",
                table: "Titles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerProfiles",
                table: "PlayerProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Titles",
                newName: "Title");

            migrationBuilder.RenameTable(
                name: "PlayerProfiles",
                newName: "PlayerProfile");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameIndex(
                name: "IX_Titles_PlayerProfileId",
                table: "Title",
                newName: "IX_Title_PlayerProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerProfiles_SelectedTitleId",
                table: "PlayerProfile",
                newName: "IX_PlayerProfile_SelectedTitleId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_PlayerProfileId",
                table: "Item",
                newName: "IX_Item_PlayerProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Title",
                table: "Title",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerProfile",
                table: "PlayerProfile",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PlayerProfile_PlayerProfileId",
                table: "AspNetUsers",
                column: "PlayerProfileId",
                principalTable: "PlayerProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_PlayerProfile_PlayerProfileId",
                table: "Item",
                column: "PlayerProfileId",
                principalTable: "PlayerProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerProfile_Title_SelectedTitleId",
                table: "PlayerProfile",
                column: "SelectedTitleId",
                principalTable: "Title",
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
    }
}
