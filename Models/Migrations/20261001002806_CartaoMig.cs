using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class CartaoMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categoria_estabelecimento_id_categoria_estabelecimento",
                table: "estabelecimentos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "categoria_sugerida_id_categoria",
                table: "estabelecimentos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "cartoes",
                columns: table => new
                {
                    id_cartao = table.Column<Guid>(type: "uuid", nullable: false),
                    nome_cartao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    numero_cartao = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    bandeira_cartao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    validade_cartao = table.Column<DateOnly>(type: "date", nullable: false),
                    limite_cartao = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    dono_cartao_id_usuario = table.Column<Guid>(type: "uuid", nullable: false),
                    observacoes = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cartoes", x => x.id_cartao);
                    table.ForeignKey(
                        name: "fk_cartoes_usuarios_dono_cartao_id_usuario",
                        column: x => x.dono_cartao_id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_estabelecimentos_categoria_estabelecimento_id_categoria_est",
                table: "estabelecimentos",
                column: "categoria_estabelecimento_id_categoria_estabelecimento");

            migrationBuilder.CreateIndex(
                name: "ix_estabelecimentos_categoria_sugerida_id_categoria",
                table: "estabelecimentos",
                column: "categoria_sugerida_id_categoria");

            migrationBuilder.CreateIndex(
                name: "ix_cartoes_dono_cartao_id_usuario",
                table: "cartoes",
                column: "dono_cartao_id_usuario");

            migrationBuilder.AddForeignKey(
                name: "fk_estabelecimentos_cat_estabelecimento_categoria_estabelecime",
                table: "estabelecimentos",
                column: "categoria_estabelecimento_id_categoria_estabelecimento",
                principalTable: "cat_estabelecimento",
                principalColumn: "id_categoria_estabelecimento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_estabelecimentos_categorias_categoria_sugerida_id_categoria",
                table: "estabelecimentos",
                column: "categoria_sugerida_id_categoria",
                principalTable: "categorias",
                principalColumn: "id_categoria",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_estabelecimentos_cat_estabelecimento_categoria_estabelecime",
                table: "estabelecimentos");

            migrationBuilder.DropForeignKey(
                name: "fk_estabelecimentos_categorias_categoria_sugerida_id_categoria",
                table: "estabelecimentos");

            migrationBuilder.DropTable(
                name: "cartoes");

            migrationBuilder.DropIndex(
                name: "ix_estabelecimentos_categoria_estabelecimento_id_categoria_est",
                table: "estabelecimentos");

            migrationBuilder.DropIndex(
                name: "ix_estabelecimentos_categoria_sugerida_id_categoria",
                table: "estabelecimentos");

            migrationBuilder.DropColumn(
                name: "categoria_estabelecimento_id_categoria_estabelecimento",
                table: "estabelecimentos");

            migrationBuilder.DropColumn(
                name: "categoria_sugerida_id_categoria",
                table: "estabelecimentos");
        }
    }
}
