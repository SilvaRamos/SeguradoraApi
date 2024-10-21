using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculoDeSeguroDeVeiculos.Migrations
{
    /// <inheritdoc />
    public partial class CriBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seguros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeguradoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoValor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VeiculoMarca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VeiculoModelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorSeguro = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguros", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguros");
        }
    }
}
