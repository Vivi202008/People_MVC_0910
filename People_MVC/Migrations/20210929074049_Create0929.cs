using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace People_MVC.Migrations
{
    public partial class Create0929 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0948bea6-fb82-49c9-8cd8-fec213fe8e8a",
                column: "ConcurrencyStamp",
                value: "c94dd077-1bf9-4622-931a-f40bcbf8ddc3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "438db5c8-0513-43a0-a84c-cd416c4e3a54",
                column: "ConcurrencyStamp",
                value: "db67c671-8c0c-4937-b772-e19fcd76fa8a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "Birthday" },
                values: new object[] { "e7ce3d76-b5fd-48ed-94b2-d9381fc566a7", "AQAAAAEAACcQAAAAEGc/7RIfB1NyRshWS4mdruE20MSwGX3SqhtguvYrcEObG15+dHqJgNa11bukTIJ+Ug==", "45d1b1f7-0d28-493e-b762-9fd5e69ab547", new DateTime(2021, 9, 29, 9, 40, 48, 565, DateTimeKind.Local).AddTicks(3858) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
