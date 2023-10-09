using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymbex.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CustomerCollectionForTicketEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_TicketId",
                table: "Customers",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Tickets_TicketId",
                table: "Customers",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Tickets_TicketId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_TicketId",
                table: "Customers");
        }
    }
}
