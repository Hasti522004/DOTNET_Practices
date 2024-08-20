using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Framework_Demo.Migrations
{
    /// <inheritdoc />
    public partial class adddatainlanguage2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 5, "Iran", "Urdu" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
