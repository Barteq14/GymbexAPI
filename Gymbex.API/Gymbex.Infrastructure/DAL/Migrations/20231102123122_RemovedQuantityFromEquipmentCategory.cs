using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymbex.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemovedQuantityFromEquipmentCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_CategoryEquipment_CategoryEquipmentId",
                table: "Equipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryEquipment",
                table: "CategoryEquipment");

            migrationBuilder.DropColumn(
                name: "TotalQuantity",
                table: "CategoryEquipment");

            migrationBuilder.RenameTable(
                name: "Equipment",
                newName: "Equipments");

            migrationBuilder.RenameTable(
                name: "CategoryEquipment",
                newName: "CategoriesEquipment");

            migrationBuilder.RenameIndex(
                name: "IX_Equipment_CategoryEquipmentId",
                table: "Equipments",
                newName: "IX_Equipments_CategoryEquipmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriesEquipment",
                table: "CategoriesEquipment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_CategoriesEquipment_CategoryEquipmentId",
                table: "Equipments",
                column: "CategoryEquipmentId",
                principalTable: "CategoriesEquipment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_CategoriesEquipment_CategoryEquipmentId",
                table: "Equipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriesEquipment",
                table: "CategoriesEquipment");

            migrationBuilder.RenameTable(
                name: "Equipments",
                newName: "Equipment");

            migrationBuilder.RenameTable(
                name: "CategoriesEquipment",
                newName: "CategoryEquipment");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_CategoryEquipmentId",
                table: "Equipment",
                newName: "IX_Equipment_CategoryEquipmentId");

            migrationBuilder.AddColumn<int>(
                name: "TotalQuantity",
                table: "CategoryEquipment",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryEquipment",
                table: "CategoryEquipment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_CategoryEquipment_CategoryEquipmentId",
                table: "Equipment",
                column: "CategoryEquipmentId",
                principalTable: "CategoryEquipment",
                principalColumn: "Id");
        }
    }
}
