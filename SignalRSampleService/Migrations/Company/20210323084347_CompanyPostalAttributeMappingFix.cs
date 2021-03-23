using Microsoft.EntityFrameworkCore.Migrations;

namespace SignalRSampleService.Migrations.Company
{
    public partial class CompanyPostalAttributeMappingFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "postalcode",
                table: "company",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "postalcode",
                table: "company");
        }
    }
}
