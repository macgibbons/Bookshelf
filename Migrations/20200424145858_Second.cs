using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookshelf.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Book",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5dcc0401-f078-48cc-acbb-01fd5c25f8ae", "AQAAAAEAACcQAAAAEMi5ng0rO1oLLMjlx1JZpiU75v2dflUkgxIguuTTR5yztwMjqD84UrqApKxCXR0JEQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Book_ApplicationUserId",
                table: "Book",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_AspNetUsers_ApplicationUserId",
                table: "Book",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_AspNetUsers_ApplicationUserId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_ApplicationUserId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Book");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d2946117-0e04-465c-8503-754194b34f3c", "AQAAAAEAACcQAAAAEElJJHvclSF4/j5XD76Ct5Xl+Z7s2SXh5a4o474hETjK5C+RS8FJXY26X3Qe/7SQig==" });
        }
    }
}
