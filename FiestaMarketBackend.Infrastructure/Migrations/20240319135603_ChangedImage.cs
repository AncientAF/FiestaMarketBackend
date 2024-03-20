using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiestaMarketBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Image");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Image",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Image",
                newName: "Path");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Image",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Image",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Image",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
