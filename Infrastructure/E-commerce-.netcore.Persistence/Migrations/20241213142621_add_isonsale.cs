using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce_.netcore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_isonsale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOnSale",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOnSale",
                table: "Products");
        }
    }
}
