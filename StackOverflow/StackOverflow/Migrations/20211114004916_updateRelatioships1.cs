using Microsoft.EntityFrameworkCore.Migrations;

namespace StackOverflow.Migrations
{
    public partial class updateRelatioships1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_User_UserID",
                table: "Answer");

            migrationBuilder.DropIndex(
                name: "IX_Answer_UserID",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Answer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Answer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Answer_UserID",
                table: "Answer",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_User_UserID",
                table: "Answer",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
