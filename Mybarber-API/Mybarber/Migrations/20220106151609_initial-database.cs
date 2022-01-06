using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Mybarber.Migrations
{
    public partial class initialdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barbearias",
                columns: table => new
                {
                    IdBarbearia = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeBarbearia = table.Column<string>(nullable: false),
                    CNPJ = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbearias", x => x.IdBarbearia);
                });

            migrationBuilder.CreateTable(
                name: "Barbeiros",
                columns: table => new
                {
                    IdBarbeiro = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameBarbeiro = table.Column<string>(nullable: false),
                    BarbeariasForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbeiros", x => x.IdBarbeiro);
                    table.ForeignKey(
                        name: "FK_Barbeiros_Barbearias_BarbeariasForeignKey",
                        column: x => x.BarbeariasForeignKey,
                        principalTable: "Barbearias",
                        principalColumn: "IdBarbearia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    IdServico = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeServico = table.Column<string>(nullable: true),
                    TempoServico = table.Column<DateTime>(nullable: false),
                    PrecoServico = table.Column<float>(nullable: false),
                    BarbeariasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.IdServico);
                    table.ForeignKey(
                        name: "FK_Servicos_Barbearias_BarbeariasId",
                        column: x => x.BarbeariasId,
                        principalTable: "Barbearias",
                        principalColumn: "IdBarbearia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    IdAgendamento = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Contato = table.Column<string>(nullable: false),
                    Horario = table.Column<DateTime>(nullable: false),
                    ServicosId = table.Column<int>(nullable: false),
                    BarbeirosId = table.Column<int>(nullable: false),
                    BarbeariasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.IdAgendamento);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Barbearias_BarbeariasId",
                        column: x => x.BarbeariasId,
                        principalTable: "Barbearias",
                        principalColumn: "IdBarbearia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Barbeiros_BarbeirosId",
                        column: x => x.BarbeirosId,
                        principalTable: "Barbeiros",
                        principalColumn: "IdBarbeiro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Servicos_ServicosId",
                        column: x => x.ServicosId,
                        principalTable: "Servicos",
                        principalColumn: "IdServico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicosBarbeiros",
                columns: table => new
                {
                    ServicosId = table.Column<int>(nullable: false),
                    BarbeirosId = table.Column<int>(nullable: false),
                    BarbeariasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicosBarbeiros", x => new { x.ServicosId, x.BarbeirosId });
                    table.ForeignKey(
                        name: "FK_ServicosBarbeiros_Barbearias_BarbeariasId",
                        column: x => x.BarbeariasId,
                        principalTable: "Barbearias",
                        principalColumn: "IdBarbearia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicosBarbeiros_Barbeiros_BarbeirosId",
                        column: x => x.BarbeirosId,
                        principalTable: "Barbeiros",
                        principalColumn: "IdBarbeiro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicosBarbeiros_Servicos_ServicosId",
                        column: x => x.ServicosId,
                        principalTable: "Servicos",
                        principalColumn: "IdServico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_BarbeariasId",
                table: "Agendamentos",
                column: "BarbeariasId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_BarbeirosId",
                table: "Agendamentos",
                column: "BarbeirosId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ServicosId",
                table: "Agendamentos",
                column: "ServicosId");

            migrationBuilder.CreateIndex(
                name: "IX_Barbeiros_BarbeariasForeignKey",
                table: "Barbeiros",
                column: "BarbeariasForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_BarbeariasId",
                table: "Servicos",
                column: "BarbeariasId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosBarbeiros_BarbeariasId",
                table: "ServicosBarbeiros",
                column: "BarbeariasId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosBarbeiros_BarbeirosId",
                table: "ServicosBarbeiros",
                column: "BarbeirosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "ServicosBarbeiros");

            migrationBuilder.DropTable(
                name: "Barbeiros");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Barbearias");
        }
    }
}
