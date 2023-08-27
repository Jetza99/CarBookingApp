using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBookingAppData.Migrations
{
    /// <inheritdoc />
    public partial class TestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarModel_CarModelId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Color_ColorId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Make_MakeId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Make",
                table: "Make");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Color",
                table: "Color");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarModel",
                table: "CarModel");

            migrationBuilder.RenameTable(
                name: "Make",
                newName: "Makes");

            migrationBuilder.RenameTable(
                name: "Color",
                newName: "Colors");

            migrationBuilder.RenameTable(
                name: "CarModel",
                newName: "CarModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Makes",
                table: "Makes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarModels",
                table: "CarModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Colors_ColorId",
                table: "Cars",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Makes_MakeId",
                table: "Cars",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarModels_CarModelId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Colors_ColorId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Makes_MakeId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Makes",
                table: "Makes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarModels",
                table: "CarModels");

            migrationBuilder.RenameTable(
                name: "Makes",
                newName: "Make");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "Color");

            migrationBuilder.RenameTable(
                name: "CarModels",
                newName: "CarModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Make",
                table: "Make",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Color",
                table: "Color",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarModel",
                table: "CarModel",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Make_MakeId",
                table: "Cars",
                column: "MakeId",
                principalTable: "Make",
                principalColumn: "Id");
        }
    }
}
