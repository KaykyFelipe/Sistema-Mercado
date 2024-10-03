using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPadaria.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Produtos",
                type: "VARCHAR(150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Produtos",
                type: "VARCHAR(150)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)",
                oldNullable: true);
        }
    }
}
