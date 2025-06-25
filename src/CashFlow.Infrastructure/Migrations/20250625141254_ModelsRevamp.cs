using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModelsRevamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Expenses_ExpenseId",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_ExpenseId",
                table: "Tag",
                newName: "IX_Tag_ExpenseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    CodigoCliente = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    CNPJ = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    CEP = table.Column<string>(type: "text", nullable: false),
                    Rua = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.CodigoCliente);
                });

            migrationBuilder.CreateTable(
                name: "Orcamento",
                columns: table => new
                {
                    CodigoOrcamento = table.Column<Guid>(type: "uuid", nullable: false),
                    Validade = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Emissao = table.Column<DateTime>(type: "timestamp", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Observacao = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CodigoAutor = table.Column<long>(type: "bigint", nullable: false),
                    CodigoCliente = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamento", x => x.CodigoOrcamento);
                });

            migrationBuilder.CreateTable(
                name: "peca",
                columns: table => new
                {
                    CodigoPeca = table.Column<Guid>(type: "uuid", nullable: false),
                    TamanhoPeca = table.Column<int>(type: "integer", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Porcentagem = table.Column<decimal>(type: "numeric", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_peca", x => x.CodigoPeca);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    CodigoProduto = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ValorBase = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.CodigoProduto);
                });

            migrationBuilder.CreateTable(
                name: "composicao_produto",
                columns: table => new
                {
                    CodigoComposicaoProduto = table.Column<int>(type: "integer", nullable: false),
                    CodigoProduto = table.Column<Guid>(type: "uuid", nullable: false),
                    CodigoPeca = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_composicao_produto", x => x.CodigoComposicaoProduto);
                    table.ForeignKey(
                        name: "FK_composicao_produto_peca_CodigoPeca",
                        column: x => x.CodigoPeca,
                        principalTable: "peca",
                        principalColumn: "CodigoPeca",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_composicao_produto_produto_CodigoProduto",
                        column: x => x.CodigoProduto,
                        principalTable: "produto",
                        principalColumn: "CodigoProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item_orcamento",
                columns: table => new
                {
                    CodigoItemOrcamento = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValue: 0m),
                    CodigoOrcamento = table.Column<Guid>(type: "uuid", nullable: false),
                    CodigoProduto = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_orcamento", x => x.CodigoItemOrcamento);
                    table.ForeignKey(
                        name: "FK_item_orcamento_Orcamento_CodigoOrcamento",
                        column: x => x.CodigoOrcamento,
                        principalTable: "Orcamento",
                        principalColumn: "CodigoOrcamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_item_orcamento_produto_CodigoProduto",
                        column: x => x.CodigoProduto,
                        principalTable: "produto",
                        principalColumn: "CodigoProduto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "item_orcamento_peca",
                columns: table => new
                {
                    CodigoPecaOrcamento = table.Column<int>(type: "integer", nullable: false),
                    CodigoItem = table.Column<Guid>(type: "uuid", nullable: false),
                    CodigoPeca = table.Column<Guid>(type: "uuid", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_orcamento_peca", x => x.CodigoPecaOrcamento);
                    table.ForeignKey(
                        name: "FK_item_orcamento_peca_item_orcamento_CodigoItem",
                        column: x => x.CodigoItem,
                        principalTable: "item_orcamento",
                        principalColumn: "CodigoItemOrcamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_item_orcamento_peca_peca_CodigoPeca",
                        column: x => x.CodigoPeca,
                        principalTable: "peca",
                        principalColumn: "CodigoPeca",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_composicao_produto_CodigoPeca",
                table: "composicao_produto",
                column: "CodigoPeca");

            migrationBuilder.CreateIndex(
                name: "IX_composicao_produto_CodigoProduto",
                table: "composicao_produto",
                column: "CodigoProduto");

            migrationBuilder.CreateIndex(
                name: "IX_item_orcamento_CodigoOrcamento",
                table: "item_orcamento",
                column: "CodigoOrcamento");

            migrationBuilder.CreateIndex(
                name: "IX_item_orcamento_CodigoProduto",
                table: "item_orcamento",
                column: "CodigoProduto");

            migrationBuilder.CreateIndex(
                name: "IX_item_orcamento_peca_CodigoItem",
                table: "item_orcamento_peca",
                column: "CodigoItem");

            migrationBuilder.CreateIndex(
                name: "IX_item_orcamento_peca_CodigoPeca",
                table: "item_orcamento_peca",
                column: "CodigoPeca");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Expenses_ExpenseId",
                table: "Tag",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Expenses_ExpenseId",
                table: "Tag");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "composicao_produto");

            migrationBuilder.DropTable(
                name: "item_orcamento_peca");

            migrationBuilder.DropTable(
                name: "item_orcamento");

            migrationBuilder.DropTable(
                name: "peca");

            migrationBuilder.DropTable(
                name: "Orcamento");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_ExpenseId",
                table: "Tags",
                newName: "IX_Tags_ExpenseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Expenses_ExpenseId",
                table: "Tags",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
