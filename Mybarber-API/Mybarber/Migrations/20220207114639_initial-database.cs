using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Mybarber.Migrations
{
    public partial class initialdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "BarbeiroImagens",
                columns: table => new
                {
                    IdBarbeiroImagem = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarbeiroImagens", x => x.IdBarbeiroImagem);
                });

            migrationBuilder.CreateTable(
                name: "HTML",
                columns: table => new
                {
                    IdHTML = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HTMLContent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HTML", x => x.IdHTML);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<string>(nullable: true),
                    RoleStrength = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "ServicoImagens",
                columns: table => new
                {
                    IdImagemServico = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoImagens", x => x.IdImagemServico);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider,x.Email });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    BarbeariasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_Barbearias_BarbeariasId",
                        column: x => x.BarbeariasId,
                        principalTable: "Barbearias",
                        principalColumn: "IdBarbearia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Barbeiros",
                columns: table => new
                {
                    IdBarbeiro = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameBarbeiro = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    BarbeariasId = table.Column<int>(nullable: false),
                    BarbeiroImagemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbeiros", x => x.IdBarbeiro);
                    table.ForeignKey(
                        name: "FK_Barbeiros_Barbearias_BarbeariasId",
                        column: x => x.BarbeariasId,
                        principalTable: "Barbearias",
                        principalColumn: "IdBarbearia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Barbeiros_BarbeiroImagens_BarbeiroImagemId",
                        column: x => x.BarbeiroImagemId,
                        principalTable: "BarbeiroImagens",
                        principalColumn: "IdBarbeiroImagem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    IdServico = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeServico = table.Column<string>(nullable: false),
                    TempoServico = table.Column<DateTime>(nullable: false),
                    PrecoServico = table.Column<float>(nullable: false),
                    ServicoImagemId = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Servicos_ServicoImagens_ServicoImagemId",
                        column: x => x.ServicoImagemId,
                        principalTable: "ServicoImagens",
                        principalColumn: "IdImagemServico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    RolesIdRole = table.Column<int>(nullable: true),
                    UsersIdUser = table.Column<int>(nullable: true),
                    BarbeariasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UsersRoles_Barbearias_BarbeariasId",
                        column: x => x.BarbeariasId,
                        principalTable: "Barbearias",
                        principalColumn: "IdBarbearia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Roles_RolesIdRole",
                        column: x => x.RolesIdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Users_UsersIdUser",
                        column: x => x.UsersIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    IdAgendas = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Segunda = table.Column<List<float>>(nullable: true),
                    Terca = table.Column<List<float>>(nullable: true),
                    Quarta = table.Column<List<float>>(nullable: true),
                    Quinta = table.Column<List<float>>(nullable: true),
                    Sexta = table.Column<List<float>>(nullable: true),
                    Sabado = table.Column<List<float>>(nullable: true),
                    Domingo = table.Column<List<float>>(nullable: true),
                    BarbeirosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.IdAgendas);
                    table.ForeignKey(
                        name: "FK_Agendas_Barbeiros_BarbeirosId",
                        column: x => x.BarbeirosId,
                        principalTable: "Barbeiros",
                        principalColumn: "IdBarbeiro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    IdAgendamento = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
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
                name: "IX_Agendas_BarbeirosId",
                table: "Agendas",
                column: "BarbeirosId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Barbeiros_BarbeariasId",
                table: "Barbeiros",
                column: "BarbeariasId");

            migrationBuilder.CreateIndex(
                name: "IX_Barbeiros_BarbeiroImagemId",
                table: "Barbeiros",
                column: "BarbeiroImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_BarbeariasId",
                table: "Servicos",
                column: "BarbeariasId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_ServicoImagemId",
                table: "Servicos",
                column: "ServicoImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosBarbeiros_BarbeariasId",
                table: "ServicosBarbeiros",
                column: "BarbeariasId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicosBarbeiros_BarbeirosId",
                table: "ServicosBarbeiros",
                column: "BarbeirosId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BarbeariasId",
                table: "Users",
                column: "BarbeariasId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_BarbeariasId",
                table: "UsersRoles",
                column: "BarbeariasId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_RolesIdRole",
                table: "UsersRoles",
                column: "RolesIdRole");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_UsersIdUser",
                table: "UsersRoles",
                column: "UsersIdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "HTML");

            migrationBuilder.DropTable(
                name: "ServicosBarbeiros");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Barbeiros");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BarbeiroImagens");

            migrationBuilder.DropTable(
                name: "ServicoImagens");

            migrationBuilder.DropTable(
                name: "Barbearias");
        }
    }
}
