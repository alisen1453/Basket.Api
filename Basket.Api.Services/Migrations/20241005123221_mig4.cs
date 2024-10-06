using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basket.Api.Services.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BasketCartId",
                table: "BasketCarts",
                newName: "BasketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BasketId",
                table: "BasketCarts",
                newName: "BasketCartId");
        }
    }
}
