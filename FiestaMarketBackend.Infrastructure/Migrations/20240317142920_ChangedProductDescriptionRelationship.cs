using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiestaMarketBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedProductDescriptionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductDescription_DescriptionId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductDescription");

            migrationBuilder.DropIndex(
                name: "IX_Products_DescriptionId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "DescriptionId",
                table: "Products",
                newName: "Description_Id");

            migrationBuilder.AddColumn<string>(
                name: "Description_Games",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_Material",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_Size",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_Text",
                table: "Products",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description_Games",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description_Material",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description_Size",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description_Text",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Description_Id",
                table: "Products",
                newName: "DescriptionId");

            migrationBuilder.CreateTable(
                name: "ProductDescription",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Games = table.Column<string>(type: "text", nullable: false),
                    Material = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDescription", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_DescriptionId",
                table: "Products",
                column: "DescriptionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductDescription_DescriptionId",
                table: "Products",
                column: "DescriptionId",
                principalTable: "ProductDescription",
                principalColumn: "Id");
        }
    }
}
