using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DebetCards.Migrations
{
    public partial class LowerCaseOnModelCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValidUntilYear",
                table: "cards",
                newName: "validuntilyear");

            migrationBuilder.RenameColumn(
                name: "ValidUntilMonth",
                table: "cards",
                newName: "validuntilmonth");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "cards",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CardNumber",
                table: "cards",
                newName: "cardnumber");

            migrationBuilder.RenameColumn(
                name: "CVC",
                table: "cards",
                newName: "cvc");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cards",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "validuntilyear",
                table: "cards",
                newName: "ValidUntilYear");

            migrationBuilder.RenameColumn(
                name: "validuntilmonth",
                table: "cards",
                newName: "ValidUntilMonth");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "cards",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "cvc",
                table: "cards",
                newName: "CVC");

            migrationBuilder.RenameColumn(
                name: "cardnumber",
                table: "cards",
                newName: "CardNumber");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "cards",
                newName: "Id");
        }
    }
}
