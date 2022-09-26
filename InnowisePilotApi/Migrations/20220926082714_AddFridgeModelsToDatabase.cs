using Microsoft.EntityFrameworkCore.Migrations;

namespace InnowisePilotApi.Migrations
{
    public partial class AddFridgeModelsToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FridgeModels",
                columns: table => new
                {
                    FridgeModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelCreationYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeModels", x => x.FridgeModelId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FridgeModels");
        }
    }
}
