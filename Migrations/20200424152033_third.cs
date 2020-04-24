using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookshelf.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0ad87b2a-bf4e-4140-8944-3dd4ea2b55c6", "AQAAAAEAACcQAAAAECYUBfH0tCGdBnIJkm+fGsTQnVzgWwN0YXjHkTsYygFGW9IOgfADVnCSZ/TZB7skXg==" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Horror" },
                    { 2, "Mystery" },
                    { 3, "Romance" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5dcc0401-f078-48cc-acbb-01fd5c25f8ae", "AQAAAAEAACcQAAAAEMi5ng0rO1oLLMjlx1JZpiU75v2dflUkgxIguuTTR5yztwMjqD84UrqApKxCXR0JEQ==" });
        }
    }
}
