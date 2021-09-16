using Microsoft.EntityFrameworkCore.Migrations;

namespace People_MVC.Migrations
{
    public partial class AddedinsuranceandrelationshipbetweenPersonandInsurancerightname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarInsurances_Insurances_InsuranceId",
                table: "CarInsurances");

            migrationBuilder.DropForeignKey(
                name: "FK_CarInsurances_Persons_PersonId",
                table: "CarInsurances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarInsurances",
                table: "CarInsurances");

            migrationBuilder.RenameTable(
                name: "CarInsurances",
                newName: "PersonInsurances");

            migrationBuilder.RenameIndex(
                name: "IX_CarInsurances_InsuranceId",
                table: "PersonInsurances",
                newName: "IX_PersonInsurances_InsuranceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInsurances",
                table: "PersonInsurances",
                columns: new[] { "PersonId", "InsuranceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInsurances_Insurances_InsuranceId",
                table: "PersonInsurances",
                column: "InsuranceId",
                principalTable: "Insurances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInsurances_Persons_PersonId",
                table: "PersonInsurances",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonInsurances_Insurances_InsuranceId",
                table: "PersonInsurances");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInsurances_Persons_PersonId",
                table: "PersonInsurances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInsurances",
                table: "PersonInsurances");

            migrationBuilder.RenameTable(
                name: "PersonInsurances",
                newName: "CarInsurances");

            migrationBuilder.RenameIndex(
                name: "IX_PersonInsurances_InsuranceId",
                table: "CarInsurances",
                newName: "IX_CarInsurances_InsuranceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarInsurances",
                table: "CarInsurances",
                columns: new[] { "PersonId", "InsuranceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarInsurances_Insurances_InsuranceId",
                table: "CarInsurances",
                column: "InsuranceId",
                principalTable: "Insurances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarInsurances_Persons_PersonId",
                table: "CarInsurances",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
