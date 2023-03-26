using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiancaProject.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Cases_CaseId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CaseId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CaseId1",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "CaseId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CaseId",
                table: "Comments",
                column: "CaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Cases_CaseId",
                table: "Comments",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "CaseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Cases_CaseId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CaseId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "CaseId",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CaseId1",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CaseId1",
                table: "Comments",
                column: "CaseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Cases_CaseId1",
                table: "Comments",
                column: "CaseId1",
                principalTable: "Cases",
                principalColumn: "CaseId");
        }
    }
}
