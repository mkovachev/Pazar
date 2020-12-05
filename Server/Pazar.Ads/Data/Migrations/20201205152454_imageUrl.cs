using Microsoft.EntityFrameworkCore.Migrations;

namespace Pazar.Ads.Data.Migrations
{
    public partial class imageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Categories",
                newName: "ImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Categories",
                newName: "Image");
        }
    }
}
