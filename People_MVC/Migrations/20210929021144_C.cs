using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace People_MVC.Migrations
{
    public partial class C : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0948bea6-fb82-49c9-8cd8-fec213fe8e8a",
                column: "ConcurrencyStamp",
                value: "fef20106-991f-4fa3-9390-4694af7dbfab");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "438db5c8-0513-43a0-a84c-cd416c4e3a54",
                column: "ConcurrencyStamp",
                value: "e02b8e1b-f6eb-4d3b-9645-e41d101744ce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "Birthday" },
                values: new object[] { "64e7b594-a4e9-4735-8388-c524f76c461f", "AQAAAAEAACcQAAAAEDbq7AXyWLJBKWBfoaljLqqFU1KogakJ5vy4KYPxG+UnqC+mvbiq6bbsys6E6I1uZQ==", "3816ee13-9693-430c-a6f5-e39b3130e49b", new DateTime(2021, 9, 29, 4, 11, 43, 991, DateTimeKind.Local).AddTicks(3776) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0948bea6-fb82-49c9-8cd8-fec213fe8e8a",
                column: "ConcurrencyStamp",
                value: "edb15fb7-c8fe-448c-9b66-b908f785712d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "438db5c8-0513-43a0-a84c-cd416c4e3a54",
                column: "ConcurrencyStamp",
                value: "e1bcfd26-3896-4e3e-b00e-9b887479ad57");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "Birthday" },
                values: new object[] { "43a33cf6-c8b2-4538-8c78-09b4a0e3a63b", "AQAAAAEAACcQAAAAEF6LhHLrcLaKHb70tmAJTmJI7j/wOcSYfCnMbDC3hmUawCIjto130odD4DYIhWVUeQ==", "c5157235-fc75-4942-ac49-f7e62aa36ed2", new DateTime(2021, 9, 28, 21, 53, 34, 589, DateTimeKind.Local).AddTicks(9382) });
        }
    }
}
