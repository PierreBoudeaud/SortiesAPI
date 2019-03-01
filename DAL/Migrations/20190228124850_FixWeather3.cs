using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class FixWeather3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weathers_Excursions_ExcursionId",
                table: "Weathers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weathers",
                table: "Weathers");

            migrationBuilder.DropIndex(
                name: "IX_Weathers_ExcursionId",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "ExcursionId",
                table: "Weathers");

            migrationBuilder.RenameTable(
                name: "Weathers",
                newName: "Weather");

            migrationBuilder.AddColumn<Guid>(
                name: "WeatherId",
                table: "Excursions",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weather",
                table: "Weather",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Excursions_WeatherId",
                table: "Excursions",
                column: "WeatherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Excursions_Weather_WeatherId",
                table: "Excursions",
                column: "WeatherId",
                principalTable: "Weather",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excursions_Weather_WeatherId",
                table: "Excursions");

            migrationBuilder.DropIndex(
                name: "IX_Excursions_WeatherId",
                table: "Excursions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weather",
                table: "Weather");

            migrationBuilder.DropColumn(
                name: "WeatherId",
                table: "Excursions");

            migrationBuilder.RenameTable(
                name: "Weather",
                newName: "Weathers");

            migrationBuilder.AddColumn<Guid>(
                name: "ExcursionId",
                table: "Weathers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weathers",
                table: "Weathers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Weathers_ExcursionId",
                table: "Weathers",
                column: "ExcursionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Weathers_Excursions_ExcursionId",
                table: "Weathers",
                column: "ExcursionId",
                principalTable: "Excursions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
