using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Havenly.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGenderInTenants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deposit",
                table: "Tenants",
                newName: "Gender");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Tenants",
                newName: "Deposit");
        }
    }
}
