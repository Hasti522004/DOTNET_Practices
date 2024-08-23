using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_LoadingDemo.Migrations
{
    /// <inheritdoc />
    public partial class AssVillaAndVillaEminityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VillaEminity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaEminity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VillaEminity_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Name", "price" },
                values: new object[,]
                {
                    { 1, "Royal Villa", 200.0 },
                    { 2, "Premium Pool Villa", 300.0 },
                    { 3, "Luxury Pool Villa", 500.0 }
                });

            migrationBuilder.InsertData(
                table: "VillaEminity",
                columns: new[] { "Id", "VillaId", "name" },
                values: new object[,]
                {
                    { 1, 1, "private pool" },
                    { 2, 1, "microwave" },
                    { 3, 1, "private balcony" },
                    { 4, 2, "1 king size bed" },
                    { 5, 2, "pool" },
                    { 6, 3, "food + Bed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VillaEminity_VillaId",
                table: "VillaEminity",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaEminity");

            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
