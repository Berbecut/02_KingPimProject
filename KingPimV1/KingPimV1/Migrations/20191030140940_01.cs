using Microsoft.EntityFrameworkCore.Migrations;

namespace KingPimV1.Migrations
{
    public partial class _01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "Products",
                newName: "CampaignStartDate");

            migrationBuilder.RenameColumn(
                name: "DateAdded",
                table: "Products",
                newName: "CampaignEndDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CampaignStartDate",
                table: "Products",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "CampaignEndDate",
                table: "Products",
                newName: "DateAdded");
        }
    }
}
