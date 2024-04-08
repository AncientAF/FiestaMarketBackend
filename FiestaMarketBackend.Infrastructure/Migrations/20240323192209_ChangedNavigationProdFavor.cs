using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiestaMarketBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedNavigationProdFavor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Favorite_FavoriteId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FavoriteId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FavoriteId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "FavoriteProduct",
                columns: table => new
                {
                    ProductsId = table.Column<Guid>(type: "uuid", nullable: false),
                    favoritesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteProduct", x => new { x.ProductsId, x.favoritesId });
                    table.ForeignKey(
                        name: "FK_FavoriteProduct_Favorite_favoritesId",
                        column: x => x.favoritesId,
                        principalTable: "Favorite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProduct_favoritesId",
                table: "FavoriteProduct",
                column: "favoritesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteProduct");

            migrationBuilder.AddColumn<Guid>(
                name: "FavoriteId",
                table: "Products",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_FavoriteId",
                table: "Products",
                column: "FavoriteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Favorite_FavoriteId",
                table: "Products",
                column: "FavoriteId",
                principalTable: "Favorite",
                principalColumn: "Id");
        }
    }
}
