using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Alura.Loja.Testes.ConsoleApp.Migrations
{
    public partial class Cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromocaoProduto_promocoes_PromocaoId",
                table: "PromocaoProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_promocoes",
                table: "promocoes");

            migrationBuilder.RenameTable(
                name: "promocoes",
                newName: "Promocoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promocoes",
                table: "Promocoes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Enderecos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PromocaoProduto_Promocoes_PromocaoId",
                table: "PromocaoProduto",
                column: "PromocaoId",
                principalTable: "Promocoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromocaoProduto_Promocoes_PromocaoId",
                table: "PromocaoProduto");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promocoes",
                table: "Promocoes");

            migrationBuilder.RenameTable(
                name: "Promocoes",
                newName: "promocoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_promocoes",
                table: "promocoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PromocaoProduto_promocoes_PromocaoId",
                table: "PromocaoProduto",
                column: "PromocaoId",
                principalTable: "promocoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
