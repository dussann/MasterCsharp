using Microsoft.EntityFrameworkCore.Migrations;

namespace StackOverflow.Migrations
{
    public partial class updateRelatioships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Answer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Question_UserID",
                table: "Question",
                column: "UserID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Question_User_UserID",
                table: "Question",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_User_UserID",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_User_UserID",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_UserID",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Answer_UserID",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Answer");
        }
    }
}
