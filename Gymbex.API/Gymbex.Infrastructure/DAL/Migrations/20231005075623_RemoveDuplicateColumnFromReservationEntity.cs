using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymbex.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDuplicateColumnFromReservationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Reservations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId1",
                table: "Reservations");
        }
    }
}
