﻿// <auto-generated />
using SAM.DDD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace SAM.DDD.Infra.Data.Migrations
{
    [DbContext(typeof(EFContext))]
    partial class EFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SAM.DDD.Domain.Entities.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("DescricaoNivel")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("SAM.DDD.Domain.Entities.Colaborador", b =>
                {
                    b.Property<int>("NumeroFuncional")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("IdUsuario");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("NumeroFuncional");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("NumeroFuncional")
                        .IsUnique();

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("SAM.DDD.Domain.Entities.Competencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Detalhe")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("IdUsuarioExclusao");

                    b.HasKey("Id");

                    b.ToTable("Competencia");
                });

            modelBuilder.Entity("SAM.DDD.Domain.Entities.CompetenciaColaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnoReferencia")
                        .HasColumnType("smallint");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("ExpectativaColaborador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FuncionalColaborador");

                    b.Property<int>("IdCompetencia");

                    b.Property<int?>("NotaAvaliacaoColaborador");

                    b.Property<int?>("NotaAvaliacaoGestor");

                    b.Property<int?>("NotaPrioridadeColaborador");

                    b.Property<int?>("NotaPrioridadeGestor");

                    b.Property<int>("NumeroVersao")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("AnoReferencia");

                    b.HasIndex("FuncionalColaborador");

                    b.HasIndex("IdCompetencia");

                    b.HasIndex("AnoReferencia", "FuncionalColaborador")
                        .IsUnique();

                    b.ToTable("CompetenciaColaborador");
                });

            modelBuilder.Entity("SAM.DDD.Domain.Entities.ConfiguracaoPeriodoPdi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime");

                    b.Property<int>("NumeroEtapa")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("ConfiguracaoPeriodoPdi");
                });

            modelBuilder.Entity("SAM.DDD.Domain.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnoReferencia")
                        .HasColumnType("smallint");

                    b.Property<string>("CodigoInternoArea")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("DescricaoAbreviada")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("FuncionalColaboradorResponsavel");

                    b.Property<int?>("IdDepartamentoSuperior");

                    b.HasKey("Id");

                    b.HasIndex("AnoReferencia");

                    b.HasIndex("FuncionalColaboradorResponsavel");

                    b.HasIndex("IdDepartamentoSuperior");

                    b.HasIndex("AnoReferencia", "CodigoInternoArea")
                        .IsUnique();

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("SAM.DDD.Domain.Entities.Eixo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnoReferencia")
                        .HasColumnType("smallint");

                    b.Property<int>("FuncionalColaborador");

                    b.Property<decimal?>("NotaEixoX");

                    b.Property<decimal?>("NotaEixoY");

                    b.HasKey("Id");

                    b.HasIndex("AnoReferencia");

                    b.HasIndex("FuncionalColaborador");

                    b.HasIndex("AnoReferencia", "FuncionalColaborador")
                        .IsUnique();

                    b.ToTable("Eixo");
                });

            modelBuilder.Entity("SAM.DDD.Domain.Entities.HierarquiaColaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnoReferencia")
                        .HasColumnType("smallint");

                    b.Property<int>("FuncionalColaborador");

                    b.Property<int?>("FuncionalSuperior");

                    b.Property<int>("IdCargo");

                    b.Property<int>("IdDepartamento");

                    b.HasKey("Id");

                    b.HasIndex("AnoReferencia");

                    b.HasIndex("FuncionalColaborador");

                    b.HasIndex("FuncionalSuperior");

                    b.HasIndex("IdCargo");

                    b.HasIndex("IdDepartamento");

                    b.ToTable("HierarquiaColaborador");
                });

            modelBuilder.Entity("SAM.DDD.Domain.Entities.OpcaoAcaoDesenvolvimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Detalhe")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("IdUsuarioExclusao");

                    b.Property<bool>("PossuiObservacao");

                    b.HasKey("Id");

                    b.ToTable("OpcaoAcaoDesenvolvimento");
                });

            modelBuilder.Entity("SAM.DDD.Domain.Entities.Pdi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnoReferencia")
                        .HasColumnType("smallint");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("DescricaoMovimentacaoLateralOutros")
                        .HasColumnType("text");

                    b.Property<string>("DescricaoPontoDesenvolver")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DescricaoPontoForte")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Expectativa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FuncionalColaborador");

                    b.Property<int>("IdStatus");

                    b.Property<int>("IdUsuarioCriacao");

                    b.Property<bool>("MovimentacaoLateral");

                    b.Property<bool>("MovimentacaoNacional");

                    b.Property<int>("NumeroVersao")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("AnoReferencia");

                    b.HasIndex("FuncionalColaborador");

                    b.HasIndex("IdStatus");

                    b.HasIndex("AnoReferencia", "FuncionalColaborador")
                        .IsUnique();

                    b.ToTable("Pdi");
                });

            modelBuilder.Entity("SAM.DDD.Domain.Entities.PdiMovimentacaoLateral", b =>
                {
                    b.Property<int>("IdPdi");

                    b.Property<int>("IdDepartamento");

                    b.HasKey("IdPdi", "IdDepartamento");

                    b.HasIndex("IdDepartamento");

                    b.ToTable("PdiMovimentacaoLateral");
                });

            modelBuilder.Entity("SAM.DDD.Domain.Entities.PdiOpcaoAcaoDesenvolvimento", b =>
                {
                    b.Property<int>("IdOpcaoAcaoDesenvolvimento");

                    b.Property<int>("IdPdi");

                    b.Property<string>("Observacao")
                        .HasColumnType("text");

                    b.HasKey("IdOpcaoAcaoDesenvolvimento", "IdPdi");

                    b.HasIndex("IdPdi");

                    b.ToTable("PdiOpcaoAcaoDesenvolvimento");
                });

            modelBuilder.Entity("SAM.DDD.Domain.Entities.PdiStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("PdiStatus");
                });

            modelBuilder.Entity("SAM.DDD.Domain.Entities.CompetenciaColaborador", b =>
                {
                    b.HasOne("SAM.DDD.Domain.Entities.Colaborador", "Colaborador")
                        .WithMany("Competencias")
                        .HasForeignKey("FuncionalColaborador")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SAM.DDD.Domain.Entities.Competencia", "Competencia")
                        .WithMany()
                        .HasForeignKey("IdCompetencia")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SAM.DDD.Domain.Entities.Departamento", b =>
                {
                    b.HasOne("SAM.DDD.Domain.Entities.Colaborador", "ColaboradorResponsavel")
                        .WithMany("ResponsavelDepartamentos")
                        .HasForeignKey("FuncionalColaboradorResponsavel")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SAM.DDD.Domain.Entities.Departamento", "DepartamentoSuperior")
                        .WithMany("Departamentos")
                        .HasForeignKey("IdDepartamentoSuperior");
                });

            modelBuilder.Entity("SAM.DDD.Domain.Entities.Eixo", b =>
                {
                    b.HasOne("SAM.DDD.Domain.Entities.Colaborador", "Colaborador")
                        .WithMany("Eixos")
                        .HasForeignKey("FuncionalColaborador")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SAM.DDD.Domain.Entities.HierarquiaColaborador", b =>
                {
                    b.HasOne("SAM.DDD.Domain.Entities.Colaborador", "Colaborador")
                        .WithMany("Hierarquia")
                        .HasForeignKey("FuncionalColaborador")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SAM.DDD.Domain.Entities.Colaborador", "Superior")
                        .WithMany()
                        .HasForeignKey("FuncionalSuperior");

                    b.HasOne("SAM.DDD.Domain.Entities.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("IdCargo")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SAM.DDD.Domain.Entities.Departamento", "Departamento")
                        .WithMany("HierarquiaColaborador")
                        .HasForeignKey("IdDepartamento")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SAM.DDD.Domain.Entities.Pdi", b =>
                {
                    b.HasOne("SAM.DDD.Domain.Entities.Colaborador", "Colaborador")
                        .WithMany("Pdis")
                        .HasForeignKey("FuncionalColaborador")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SAM.DDD.Domain.Entities.PdiStatus", "Status")
                        .WithMany()
                        .HasForeignKey("IdStatus")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SAM.DDD.Domain.Entities.PdiMovimentacaoLateral", b =>
                {
                    b.HasOne("SAM.DDD.Domain.Entities.Departamento", "Departamento")
                        .WithMany("PdiMovimentacoesLateral")
                        .HasForeignKey("IdDepartamento")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SAM.DDD.Domain.Entities.Pdi", "Pdi")
                        .WithMany("PdisMovimentacoesLateral")
                        .HasForeignKey("IdPdi")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SAM.DDD.Domain.Entities.PdiOpcaoAcaoDesenvolvimento", b =>
                {
                    b.HasOne("SAM.DDD.Domain.Entities.OpcaoAcaoDesenvolvimento", "OpcaoAcaoDesenvolvimento")
                        .WithMany("PdisOpcoesAcoesDesenvolvimento")
                        .HasForeignKey("IdOpcaoAcaoDesenvolvimento")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SAM.DDD.Domain.Entities.Pdi", "Pdi")
                        .WithMany("PdisOpcoesAcoesDesenvolvimento")
                        .HasForeignKey("IdPdi")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
