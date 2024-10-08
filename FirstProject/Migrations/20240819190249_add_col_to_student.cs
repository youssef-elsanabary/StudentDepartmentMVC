using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstProject.Migrations
{
    /// <inheritdoc />
    public partial class add_col_to_student : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentEmail",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentEmail",
                table: "Students");
        }
    }
}
