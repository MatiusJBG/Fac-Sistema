using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Ced_Cli = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nom_Cli = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ape_Cli = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ruc_Cli = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dir_Cli = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cor_Cli = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tel_Cli = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Ced_Cli);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id_Pro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tip_Pro = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nom_Pro = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fec_Exp_Pro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Can_Pro = table.Column<int>(type: "int", nullable: false),
                    Pre_Uni = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id_Pro);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id_Fac = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fec_Fac = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Ced_Cli_Per = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tot_Fac = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id_Fac);
                    table.ForeignKey(
                        name: "FK_Facturas_Clientes_Ced_Cli_Per",
                        column: x => x.Ced_Cli_Per,
                        principalTable: "Clientes",
                        principalColumn: "Ced_Cli",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Actualizaciones",
                columns: table => new
                {
                    Id_Act_Pro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Pro_Per = table.Column<int>(type: "int", nullable: false),
                    Pre_Act_Pro = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fec_Act_Pro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actualizaciones", x => x.Id_Act_Pro);
                    table.ForeignKey(
                        name: "FK_Actualizaciones_Productos_Id_Pro_Per",
                        column: x => x.Id_Pro_Per,
                        principalTable: "Productos",
                        principalColumn: "Id_Pro",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    Id_Ent_Pro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Pro_Per = table.Column<int>(type: "int", nullable: false),
                    Fec_Ent_Pro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Can_Ent_Pro = table.Column<int>(type: "int", nullable: false),
                    Can_Dis = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => x.Id_Ent_Pro);
                    table.ForeignKey(
                        name: "FK_Entradas_Productos_Id_Pro_Per",
                        column: x => x.Id_Pro_Per,
                        principalTable: "Productos",
                        principalColumn: "Id_Pro",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetallesFactura",
                columns: table => new
                {
                    Id_Det_Fac = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Fac_Per = table.Column<int>(type: "int", nullable: false),
                    Id_Pro_Per = table.Column<int>(type: "int", nullable: false),
                    Can_Com = table.Column<int>(type: "int", nullable: false),
                    Id_Act_Pro_Per = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesFactura", x => x.Id_Det_Fac);
                    table.ForeignKey(
                        name: "FK_DetallesFactura_Actualizaciones_Id_Act_Pro_Per",
                        column: x => x.Id_Act_Pro_Per,
                        principalTable: "Actualizaciones",
                        principalColumn: "Id_Act_Pro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetallesFactura_Facturas_Id_Fac_Per",
                        column: x => x.Id_Fac_Per,
                        principalTable: "Facturas",
                        principalColumn: "Id_Fac",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesFactura_Productos_Id_Pro_Per",
                        column: x => x.Id_Pro_Per,
                        principalTable: "Productos",
                        principalColumn: "Id_Pro",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Actualizaciones_Id_Pro_Per",
                table: "Actualizaciones",
                column: "Id_Pro_Per");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFactura_Id_Act_Pro_Per",
                table: "DetallesFactura",
                column: "Id_Act_Pro_Per");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFactura_Id_Fac_Per",
                table: "DetallesFactura",
                column: "Id_Fac_Per");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFactura_Id_Pro_Per",
                table: "DetallesFactura",
                column: "Id_Pro_Per");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_Id_Pro_Per",
                table: "Entradas",
                column: "Id_Pro_Per");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_Ced_Cli_Per",
                table: "Facturas",
                column: "Ced_Cli_Per");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesFactura");

            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "Actualizaciones");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
