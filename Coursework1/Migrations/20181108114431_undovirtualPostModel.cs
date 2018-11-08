using Microsoft.EntityFrameworkCore.Migrations;

namespace Coursework1.Migrations
{
    public partial class undovirtualPostModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Post_PostIdId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostIdId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "PostIdId",
                table: "Comments",
                newName: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Comments",
                newName: "PostIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostIdId",
                table: "Comments",
                column: "PostIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Post_PostIdId",
                table: "Comments",
                column: "PostIdId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
