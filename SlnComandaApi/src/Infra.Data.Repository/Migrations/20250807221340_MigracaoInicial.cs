using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infra.Data.Repository.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "comandas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comandas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comandas_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComandaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_produtos_comandas_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "comandas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "Id", "Email", "Nome", "Senha", "Telefone" },
                values: new object[,]
                {
                    { 1, "joao.silva@email.com", "João Silva", "admin123", "47988887777" },
                    { 2, "maria.santos@email.com", "Maria Santos", "admin123", "47999998888" },
                    { 3, "pedro.oliveira@email.com", "Pedro Oliveira", "admin123", "47977776666" },
                    { 4, "ana.costa@email.com", "Ana Costa", "admin123", "47966665555" },
                    { 5, "carlos.mendes@email.com", "Carlos Mendes", "admin123", "47955554444" }
                });

            migrationBuilder.InsertData(
                table: "comandas",
                columns: new[] { "Id", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 1 },
                    { 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "produtos",
                columns: new[] { "Id", "ComandaId", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, 1, "X-Salada", 30.00m },
                    { 2, 1, "X-Bacon", 35.00m },
                    { 3, 2, "Pizza Margherita", 45.00m },
                    { 4, 3, "X-Tudo", 42.50m },
                    { 5, 3, "Batata Frita Grande", 25.00m },
                    { 6, 3, "Refrigerante 2L", 22.00m },
                    { 7, 4, "Hot Dog Especial", 18.50m },
                    { 8, 4, "Suco Natural", 14.00m },
                    { 9, 5, "Pizza Portuguesa", 48.00m },
                    { 10, 5, "Guaraná Lata", 8.00m },
                    { 11, 5, "Sobremesa Pudim", 22.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_comandas_UsuarioId",
                table: "comandas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_ComandaId",
                table: "produtos",
                column: "ComandaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "comandas");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
