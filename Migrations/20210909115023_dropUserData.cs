using Microsoft.EntityFrameworkCore.Migrations;

namespace homework_54.Migrations
{
    public partial class dropUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "RoleId" },
                values: new object[] { 2, "user@user.user", "321ytrewq", 2 });
        }
    }
}
