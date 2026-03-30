using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexusReader.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddIsPublishedToBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
       
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Books");
        }
    }
}
