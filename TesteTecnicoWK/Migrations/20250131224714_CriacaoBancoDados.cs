using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteTecnicoWK.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoBancoDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tab_Cliente",
                columns: table => new
                {
                    Cod_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Des_NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Des_Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Des_Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Des_UF = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tab_Cliente", x => x.Cod_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "Tab_Produto",
                columns: table => new
                {
                    Cod_Produto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Des_Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Val_Preco = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tab_Produto", x => x.Cod_Produto);
                });

            migrationBuilder.CreateTable(
                name: "Tab_Pedido",
                columns: table => new
                {
                    Cod_Pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dta_pedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cod_Cliente = table.Column<int>(type: "int", nullable: false),
                    ClienteCod_Cliente = table.Column<int>(type: "int", nullable: false),
                    Val_Pedido = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tab_Pedido", x => x.Cod_Pedido);
                    table.ForeignKey(
                        name: "FK_Tab_Pedido_Tab_Cliente_ClienteCod_Cliente",
                        column: x => x.ClienteCod_Cliente,
                        principalTable: "Tab_Cliente",
                        principalColumn: "Cod_Cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tab_Pedido_Item",
                columns: table => new
                {
                    Cod_Pedido = table.Column<int>(type: "int", nullable: false),
                    Cod_Produto = table.Column<int>(type: "int", nullable: false),
                    Id_Pedido = table.Column<int>(type: "int", nullable: false),
                    Val_Quantidade = table.Column<int>(type: "int", nullable: false),
                    Val_PrecoUnitario = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Val_TotalItem = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tab_Pedido_Item", x => new { x.Cod_Pedido, x.Cod_Produto });
                    table.ForeignKey(
                        name: "FK_Tab_Pedido_Item_Tab_Pedido_Cod_Pedido",
                        column: x => x.Cod_Pedido,
                        principalTable: "Tab_Pedido",
                        principalColumn: "Cod_Pedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tab_Pedido_Item_Tab_Produto_Cod_Produto",
                        column: x => x.Cod_Produto,
                        principalTable: "Tab_Produto",
                        principalColumn: "Cod_Produto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tab_Pedido_ClienteCod_Cliente",
                table: "Tab_Pedido",
                column: "ClienteCod_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Tab_Pedido_Item_Cod_Produto",
                table: "Tab_Pedido_Item",
                column: "Cod_Produto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tab_Pedido_Item");

            migrationBuilder.DropTable(
                name: "Tab_Pedido");

            migrationBuilder.DropTable(
                name: "Tab_Produto");

            migrationBuilder.DropTable(
                name: "Tab_Cliente");
        }
    }
}
