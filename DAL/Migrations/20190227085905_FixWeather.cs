using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class FixWeather : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weathers_Excursions_ExcursionId1",
                table: "Weathers");

            migrationBuilder.DropIndex(
                name: "IX_Weathers_ExcursionId1",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "ExcursionId1",
                table: "Weathers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExcursionId1",
                table: "Weathers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weathers_ExcursionId1",
                table: "Weathers",
                column: "ExcursionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Weathers_Excursions_ExcursionId1",
                table: "Weathers",
                column: "ExcursionId1",
                principalTable: "Excursions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
