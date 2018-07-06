using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SAM.DDD.Infra.Data.Migrations
{
    public partial class ModelagemInicialBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DescricaoNivel = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    NumeroFuncional = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    NomeCompleto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.NumeroFuncional);
                });

            migrationBuilder.CreateTable(
                name: "Competencia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Detalhe = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioExclusao = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracaoPeriodoPdi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataFim = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    NumeroEtapa = table.Column<int>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracaoPeriodoPdi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpcaoAcaoDesenvolvimento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Detalhe = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioExclusao = table.Column<int>(nullable: true),
                    PossuiObservacao = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcaoAcaoDesenvolvimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdiStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdiStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnoReferencia = table.Column<int>(type: "smallint", nullable: false),
                    CodigoInternoArea = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DescricaoAbreviada = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    FuncionalColaboradorResponsavel = table.Column<int>(nullable: false),
                    IdDepartamentoSuperior = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamento_Colaborador_FuncionalColaboradorResponsavel",
                        column: x => x.FuncionalColaboradorResponsavel,
                        principalTable: "Colaborador",
                        principalColumn: "NumeroFuncional",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departamento_Departamento_IdDepartamentoSuperior",
                        column: x => x.IdDepartamentoSuperior,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Eixo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnoReferencia = table.Column<int>(type: "smallint", nullable: false),
                    FuncionalColaborador = table.Column<int>(nullable: false),
                    NotaEixoX = table.Column<decimal>(nullable: true),
                    NotaEixoY = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eixo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eixo_Colaborador_FuncionalColaborador",
                        column: x => x.FuncionalColaborador,
                        principalTable: "Colaborador",
                        principalColumn: "NumeroFuncional",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompetenciaColaborador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnoReferencia = table.Column<int>(type: "smallint", nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    ExpectativaColaborador = table.Column<string>(type: "text", nullable: false),
                    FuncionalColaborador = table.Column<int>(nullable: false),
                    IdCompetencia = table.Column<int>(nullable: false),
                    NotaAvaliacaoColaborador = table.Column<int>(nullable: true),
                    NotaAvaliacaoGestor = table.Column<int>(nullable: true),
                    NotaPrioridadeColaborador = table.Column<int>(nullable: true),
                    NotaPrioridadeGestor = table.Column<int>(nullable: true),
                    NumeroVersao = table.Column<int>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenciaColaborador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetenciaColaborador_Colaborador_FuncionalColaborador",
                        column: x => x.FuncionalColaborador,
                        principalTable: "Colaborador",
                        principalColumn: "NumeroFuncional",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompetenciaColaborador_Competencia_IdCompetencia",
                        column: x => x.IdCompetencia,
                        principalTable: "Competencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pdi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnoReferencia = table.Column<int>(type: "smallint", nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    DescricaoMovimentacaoLateralOutros = table.Column<string>(type: "text", nullable: true),
                    DescricaoPontoDesenvolver = table.Column<string>(type: "text", nullable: false),
                    DescricaoPontoForte = table.Column<string>(type: "text", nullable: false),
                    Expectativa = table.Column<string>(type: "text", nullable: false),
                    FuncionalColaborador = table.Column<int>(nullable: false),
                    IdStatus = table.Column<int>(nullable: false),
                    IdUsuarioCriacao = table.Column<int>(nullable: false),
                    MovimentacaoLateral = table.Column<bool>(nullable: false),
                    MovimentacaoNacional = table.Column<bool>(nullable: false),
                    NumeroVersao = table.Column<int>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pdi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pdi_Colaborador_FuncionalColaborador",
                        column: x => x.FuncionalColaborador,
                        principalTable: "Colaborador",
                        principalColumn: "NumeroFuncional",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pdi_PdiStatus_IdStatus",
                        column: x => x.IdStatus,
                        principalTable: "PdiStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HierarquiaColaborador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnoReferencia = table.Column<int>(type: "smallint", nullable: false),
                    FuncionalColaborador = table.Column<int>(nullable: false),
                    FuncionalSuperior = table.Column<int>(nullable: true),
                    IdCargo = table.Column<int>(nullable: false),
                    IdDepartamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HierarquiaColaborador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HierarquiaColaborador_Colaborador_FuncionalColaborador",
                        column: x => x.FuncionalColaborador,
                        principalTable: "Colaborador",
                        principalColumn: "NumeroFuncional",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HierarquiaColaborador_Colaborador_FuncionalSuperior",
                        column: x => x.FuncionalSuperior,
                        principalTable: "Colaborador",
                        principalColumn: "NumeroFuncional",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HierarquiaColaborador_Cargo_IdCargo",
                        column: x => x.IdCargo,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HierarquiaColaborador_Departamento_IdDepartamento",
                        column: x => x.IdDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PdiMovimentacaoLateral",
                columns: table => new
                {
                    IdPdi = table.Column<int>(nullable: false),
                    IdDepartamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdiMovimentacaoLateral", x => new { x.IdPdi, x.IdDepartamento });
                    table.ForeignKey(
                        name: "FK_PdiMovimentacaoLateral_Departamento_IdDepartamento",
                        column: x => x.IdDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PdiMovimentacaoLateral_Pdi_IdPdi",
                        column: x => x.IdPdi,
                        principalTable: "Pdi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PdiOpcaoAcaoDesenvolvimento",
                columns: table => new
                {
                    IdOpcaoAcaoDesenvolvimento = table.Column<int>(nullable: false),
                    IdPdi = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdiOpcaoAcaoDesenvolvimento", x => new { x.IdOpcaoAcaoDesenvolvimento, x.IdPdi });
                    table.ForeignKey(
                        name: "FK_PdiOpcaoAcaoDesenvolvimento_OpcaoAcaoDesenvolvimento_IdOpcaoAcaoDesenvolvimento",
                        column: x => x.IdOpcaoAcaoDesenvolvimento,
                        principalTable: "OpcaoAcaoDesenvolvimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PdiOpcaoAcaoDesenvolvimento_Pdi_IdPdi",
                        column: x => x.IdPdi,
                        principalTable: "Pdi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_Email",
                table: "Colaborador",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_NumeroFuncional",
                table: "Colaborador",
                column: "NumeroFuncional",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompetenciaColaborador_AnoReferencia",
                table: "CompetenciaColaborador",
                column: "AnoReferencia");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenciaColaborador_FuncionalColaborador",
                table: "CompetenciaColaborador",
                column: "FuncionalColaborador");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenciaColaborador_IdCompetencia",
                table: "CompetenciaColaborador",
                column: "IdCompetencia");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenciaColaborador_AnoReferencia_FuncionalColaborador",
                table: "CompetenciaColaborador",
                columns: new[] { "AnoReferencia", "FuncionalColaborador" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_AnoReferencia",
                table: "Departamento",
                column: "AnoReferencia");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_FuncionalColaboradorResponsavel",
                table: "Departamento",
                column: "FuncionalColaboradorResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_IdDepartamentoSuperior",
                table: "Departamento",
                column: "IdDepartamentoSuperior");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_AnoReferencia_CodigoInternoArea",
                table: "Departamento",
                columns: new[] { "AnoReferencia", "CodigoInternoArea" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eixo_AnoReferencia",
                table: "Eixo",
                column: "AnoReferencia");

            migrationBuilder.CreateIndex(
                name: "IX_Eixo_FuncionalColaborador",
                table: "Eixo",
                column: "FuncionalColaborador");

            migrationBuilder.CreateIndex(
                name: "IX_Eixo_AnoReferencia_FuncionalColaborador",
                table: "Eixo",
                columns: new[] { "AnoReferencia", "FuncionalColaborador" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HierarquiaColaborador_AnoReferencia",
                table: "HierarquiaColaborador",
                column: "AnoReferencia");

            migrationBuilder.CreateIndex(
                name: "IX_HierarquiaColaborador_FuncionalColaborador",
                table: "HierarquiaColaborador",
                column: "FuncionalColaborador");

            migrationBuilder.CreateIndex(
                name: "IX_HierarquiaColaborador_FuncionalSuperior",
                table: "HierarquiaColaborador",
                column: "FuncionalSuperior");

            migrationBuilder.CreateIndex(
                name: "IX_HierarquiaColaborador_IdCargo",
                table: "HierarquiaColaborador",
                column: "IdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_HierarquiaColaborador_IdDepartamento",
                table: "HierarquiaColaborador",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Pdi_AnoReferencia",
                table: "Pdi",
                column: "AnoReferencia");

            migrationBuilder.CreateIndex(
                name: "IX_Pdi_FuncionalColaborador",
                table: "Pdi",
                column: "FuncionalColaborador");

            migrationBuilder.CreateIndex(
                name: "IX_Pdi_IdStatus",
                table: "Pdi",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Pdi_AnoReferencia_FuncionalColaborador",
                table: "Pdi",
                columns: new[] { "AnoReferencia", "FuncionalColaborador" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PdiMovimentacaoLateral_IdDepartamento",
                table: "PdiMovimentacaoLateral",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_PdiOpcaoAcaoDesenvolvimento_IdPdi",
                table: "PdiOpcaoAcaoDesenvolvimento",
                column: "IdPdi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetenciaColaborador");

            migrationBuilder.DropTable(
                name: "ConfiguracaoPeriodoPdi");

            migrationBuilder.DropTable(
                name: "Eixo");

            migrationBuilder.DropTable(
                name: "HierarquiaColaborador");

            migrationBuilder.DropTable(
                name: "PdiMovimentacaoLateral");

            migrationBuilder.DropTable(
                name: "PdiOpcaoAcaoDesenvolvimento");

            migrationBuilder.DropTable(
                name: "Competencia");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "OpcaoAcaoDesenvolvimento");

            migrationBuilder.DropTable(
                name: "Pdi");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "PdiStatus");
        }
    }
}
