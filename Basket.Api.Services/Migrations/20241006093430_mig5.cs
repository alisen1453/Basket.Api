using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basket.Api.Services.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_BasketCarts_BasketItemId",
                table: "BasketItems");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketId",
                table: "BasketItems",
                column: "BasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_BasketCarts_BasketId",
                table: "BasketItems",
                column: "BasketId",
                principalTable: "BasketCarts",
                principalColumn: "BasketId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_BasketCarts_BasketId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_BasketId",
                table: "BasketItems");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_BasketCarts_BasketItemId",
                table: "BasketItems",
                column: "BasketItemId",
                principalTable: "BasketCarts",
                principalColumn: "BasketId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
