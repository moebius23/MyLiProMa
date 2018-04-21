using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyLittleProjectManager.Data.Migrations
{
    public partial class seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Columns_ColumnId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Columns_Projects_ProjectId",
                table: "Columns");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Columns",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ColumnId",
                table: "Cards",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Columns_ColumnId",
                table: "Cards",
                column: "ColumnId",
                principalTable: "Columns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Columns_Projects_ProjectId",
                table: "Columns",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Columns_ColumnId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Columns_Projects_ProjectId",
                table: "Columns");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Columns",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ColumnId",
                table: "Cards",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Columns_ColumnId",
                table: "Cards",
                column: "ColumnId",
                principalTable: "Columns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Columns_Projects_ProjectId",
                table: "Columns",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
