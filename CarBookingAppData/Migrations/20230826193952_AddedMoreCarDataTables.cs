using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBookingAppData.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreCarDataTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "Cars");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Makes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CarModelId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "CarModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelId",
                table: "Cars",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ColorId",
                table: "Cars",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarModel_CarModelId",
                table: "Cars",
                column: "CarModelId",
                principalTable: "CarModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Color_ColorId",
                table: "Cars",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarModel_CarModelId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Color_ColorId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "CarModel");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarModelId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ColorId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Makes");

            migrationBuilder.DropColumn(
                name: "CarModelId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Cars",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
