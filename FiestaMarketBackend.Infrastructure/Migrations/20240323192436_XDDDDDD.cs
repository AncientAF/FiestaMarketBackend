using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiestaMarketBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class XDDDDDD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProduct_Favorite_favoritesId",
                table: "FavoriteProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteProduct",
                table: "FavoriteProduct");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteProduct_favoritesId",
                table: "FavoriteProduct");

            migrationBuilder.RenameColumn(
                name: "favoritesId",
                table: "FavoriteProduct",
                newName: "FavoritesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteProduct",
                table: "FavoriteProduct",
                columns: new[] { "FavoritesId", "ProductsId" });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProduct_ProductsId",
                table: "FavoriteProduct",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProduct_Favorite_FavoritesId",
                table: "FavoriteProduct",
                column: "FavoritesId",
                principalTable: "Favorite",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProduct_Favorite_FavoritesId",
                table: "FavoriteProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteProduct",
                table: "FavoriteProduct");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteProduct_ProductsId",
                table: "FavoriteProduct");

            migrationBuilder.RenameColumn(
                name: "FavoritesId",
                table: "FavoriteProduct",
                newName: "favoritesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteProduct",
                table: "FavoriteProduct",
                columns: new[] { "ProductsId", "favoritesId" });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProduct_favoritesId",
                table: "FavoriteProduct",
                column: "favoritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProduct_Favorite_favoritesId",
                table: "FavoriteProduct",
                column: "favoritesId",
                principalTable: "Favorite",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
