using Microsoft.EntityFrameworkCore.Migrations;

namespace SignalRSampleService.Migrations.Company
{
    public partial class CompanyEntitySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO company (name, address, city, state, postalcode) " +
                "VALUES ('Patrik Duch', 'Ostravská 1619/48', 'Český Těšín', 'ČR', '73701');");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
