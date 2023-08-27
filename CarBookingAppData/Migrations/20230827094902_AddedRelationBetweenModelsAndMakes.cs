using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBookingAppData.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationBetweenModelsAndMakes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                table: "CarModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_MakeId",
                table: "CarModels",
                column: "MakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Makes_MakeId",
                table: "CarModels",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Makes_MakeId",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_MakeId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "CarModels");
        }
    }
}
