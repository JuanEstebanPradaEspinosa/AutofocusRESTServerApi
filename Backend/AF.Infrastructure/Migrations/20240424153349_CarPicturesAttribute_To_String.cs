using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AF.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CarPicturesAttribute_To_String : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarPicture",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "CarPictures",
                table: "Cars",
                newName: "ImageUrls");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "ImageUrls",
                table: "Cars",
                newName: "CarPictures");

            migrationBuilder.AddColumn<byte[]>(
                name: "CarPicture",
                table: "Cars",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
