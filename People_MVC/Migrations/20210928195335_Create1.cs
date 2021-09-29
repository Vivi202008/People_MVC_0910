using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace People_MVC.Migrations
{
    public partial class Create1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PLanguageId",
                table: "PersonLanguages",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Name" },
                values: new object[,]
                {
                    { 1, "Other" },
                    { 2, "German" },
                    { 3, "Italian" },
                    { 4, "English" },
                    { 5, "Spanish" },
                    { 6, "Chinese" },
                    { 7, "Swedish" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "PersonLanguages",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "PLanguageId",
                table: "PersonLanguages");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0948bea6-fb82-49c9-8cd8-fec213fe8e8a",
                column: "ConcurrencyStamp",
                value: "144ef629-bc63-48ce-a398-9a95f3af3c7b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "438db5c8-0513-43a0-a84c-cd416c4e3a54",
                column: "ConcurrencyStamp",
                value: "b89e015c-e86b-4824-9d7c-77e719c0ae38");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "Birthday" },
                values: new object[] { "e6a017d0-1ea5-4635-84c6-823f238c775f", "AQAAAAEAACcQAAAAEKfVI0CQkOk0R+SkaDAyuWrOJGeZEnYv1wMHi1kFtM7m5zXFjSNyH9UAvTSTh36vbg==", "1b4dc4fb-67ac-4204-a3c4-b9ae2a602df5", new DateTime(2021, 9, 28, 21, 38, 36, 585, DateTimeKind.Local).AddTicks(3477) });

            migrationBuilder.InsertData(
                table: "PersonLanguages",
                columns: new[] { "PersonId", "LanguageId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 1 },
                    { 2, 6 },
                    { 2, 1 },
                    { 3, 7 },
                    { 7, 7 },
                    { 7, 5 },
                    { 6, 2 },
                    { 5, 4 },
                    { 4, 7 },
                    { 4, 5 },
                    { 4, 3 },
                    { 8, 7 }
                });
        }
    }
}
