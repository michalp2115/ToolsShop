using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tools.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CompanyIn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreedAddress",
                table: "Companies",
                newName: "StreetAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "Companies",
                newName: "StreedAddress");
        }
    }
}
