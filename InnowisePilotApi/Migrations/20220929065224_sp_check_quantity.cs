using Microsoft.EntityFrameworkCore.Migrations;

namespace InnowisePilotApi.Migrations
{
    public partial class sp_check_quantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_check_quantity
                    AS
                    BEGIN
	                    SELECT [Id],[ProductId],[FridgeID],[Quantity]
	                    FROM FridgeProducts
	                    WHERE FridgeProducts.Quantity = 0
                        END;";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
