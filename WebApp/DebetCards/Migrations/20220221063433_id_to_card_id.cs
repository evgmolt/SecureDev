using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DebetCards.Migrations
{
    public partial class id_to_card_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "cards",
                newName: "card_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "card_id",
                table: "cards",
                newName: "id");
        }
    }
}
