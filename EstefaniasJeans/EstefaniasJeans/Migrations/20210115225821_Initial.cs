using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstefaniasJeans.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "Varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombres = table.Column<string>(type: "Varchar(70)", nullable: true),
                    Apellidos = table.Column<string>(type: "Varchar(70)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion1 = table.Column<string>(type: "NVarchar(250)", nullable: true),
                    Direccion2 = table.Column<string>(type: "NVarchar(250)", nullable: true),
                    Documento = table.Column<string>(type: "Varchar(12)", nullable: true),
                    Celular = table.Column<string>(type: "Varchar(12)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mercaderias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Categoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Persona = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Nombre = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Descripcion = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    StockRestante = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "Decimal(8,2)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercaderias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mercaderias_Categoria_Id_Categoria",
                        column: x => x.Id_Categoria,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mercaderias_Persona_Id_Persona",
                        column: x => x.Id_Persona,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Persona = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "Varchar(250)", nullable: true),
                    PrecioTotal = table.Column<decimal>(type: "Decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Persona_Id_Persona",
                        column: x => x.Id_Persona,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MercaderiaFotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Mercaderia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MercaderiaFotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MercaderiaFotos_Mercaderias_Id_Mercaderia",
                        column: x => x.Id_Mercaderia,
                        principalTable: "Mercaderias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoDetalles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Pedido = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Mercaderia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "Decimal(8,2)", nullable: false),
                    PrecioTotal = table.Column<decimal>(type: "Decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoDetalles_Mercaderias_Id_Mercaderia",
                        column: x => x.Id_Mercaderia,
                        principalTable: "Mercaderias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoDetalles_Pedidos_Id_Pedido",
                        column: x => x.Id_Pedido,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("8b2b3d2b-5eb4-460a-ac44-37f6c081bdd2"), "Pantalón" },
                    { new Guid("da623463-9123-4890-9193-350172843fb3"), "Jumpers" },
                    { new Guid("7f5ba8d6-6af3-438e-8c19-1e45215b756b"), "Shorts" },
                    { new Guid("10deaf97-b2ad-4a52-8ad2-511082d4049c"), "Faldas" },
                    { new Guid("fbe611c7-259d-4a2b-9b81-f0174a74b8ae"), "Toreros" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MercaderiaFotos_Id_Mercaderia",
                table: "MercaderiaFotos",
                column: "Id_Mercaderia");

            migrationBuilder.CreateIndex(
                name: "IX_Mercaderias_Id_Categoria",
                table: "Mercaderias",
                column: "Id_Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Mercaderias_Id_Persona",
                table: "Mercaderias",
                column: "Id_Persona");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalles_Id_Mercaderia",
                table: "PedidoDetalles",
                column: "Id_Mercaderia");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalles_Id_Pedido",
                table: "PedidoDetalles",
                column: "Id_Pedido");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Id_Persona",
                table: "Pedidos",
                column: "Id_Persona");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MercaderiaFotos");

            migrationBuilder.DropTable(
                name: "PedidoDetalles");

            migrationBuilder.DropTable(
                name: "Mercaderias");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
