using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymbex.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixedRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Activities_ActivityId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Tickets_TicketId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ActivityId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_TicketId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Customers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ActivityId",
                table: "Customers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ActivityId",
                table: "Customers",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TicketId",
                table: "Customers",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Activities_ActivityId",
                table: "Customers",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Tickets_TicketId",
                table: "Customers",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }
    }
}
