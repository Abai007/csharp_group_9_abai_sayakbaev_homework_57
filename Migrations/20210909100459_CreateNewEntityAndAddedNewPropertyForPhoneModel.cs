using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace homework_54.Migrations
{
    public partial class CreateNewEntityAndAddedNewPropertyForPhoneModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageModelId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ImageModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Path = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImageModelId",
                table: "Products",
                column: "ImageModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ImageModel_ImageModelId",
                table: "Products",
                column: "ImageModelId",
                principalTable: "ImageModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ImageModel_ImageModelId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ImageModel");

            migrationBuilder.DropIndex(
                name: "IX_Products_ImageModelId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageModelId",
                table: "Products");
        }
    }
}
