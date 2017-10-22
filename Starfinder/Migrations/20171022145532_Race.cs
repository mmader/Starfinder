using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Starfinder.Migrations
{
    public partial class Race : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rasse",
                table: "Characters");

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Race",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "Characters");

            migrationBuilder.AddColumn<string>(
                name: "Rasse",
                table: "Characters",
                nullable: true);
        }
    }
}
