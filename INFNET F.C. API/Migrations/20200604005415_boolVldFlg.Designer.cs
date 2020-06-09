﻿// <auto-generated />
using System;
using INFNET_F.C._API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace INFNET_F.C._API.Migrations
{
    [DbContext(typeof(InfnetDBContext))]
    [Migration("20200604005415_boolVldFlg")]
    partial class boolVldFlg
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("INFNET_F.C._API.Models.Assinatura", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<bool>("FLG_ATIVA")
                        .HasColumnType("bit");

                    b.Property<int>("IDPLANO_FK")
                        .HasColumnType("int");

                    b.Property<int>("IDSOCIO_FK")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IDPLANO_FK");

                    b.HasIndex("IDSOCIO_FK");

                    b.ToTable("Assinatura");
                });

            modelBuilder.Entity("INFNET_F.C._API.Models.Cobranca", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IDASSINATURA_FK")
                        .HasColumnType("int");

                    b.Property<int>("NumeroParcelas")
                        .HasColumnType("int");

                    b.Property<double>("ValorParcelas")
                        .HasColumnType("float");

                    b.Property<bool>("isRecorrente")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("IDASSINATURA_FK");

                    b.ToTable("Cobranca");
                });

            modelBuilder.Entity("INFNET_F.C._API.Models.Duvida", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Assunto")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("IDSOCIO_FK")
                        .HasColumnType("int");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(600)")
                        .HasMaxLength(600);

                    b.HasKey("ID");

                    b.HasIndex("IDSOCIO_FK");

                    b.ToTable("Duvida");
                });

            modelBuilder.Entity("INFNET_F.C._API.Models.Menu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ATIVO")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DT_CADASTRO")
                        .HasColumnType("datetime2");

                    b.Property<string>("ICONEMENU")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("NOME_MENU")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("ORDEM")
                        .HasColumnType("int");

                    b.Property<string>("ROTA_MENU")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("INFNET_F.C._API.Models.Plano", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(600)")
                        .HasMaxLength(600);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("QtdDisponivel")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Plano");
                });

            modelBuilder.Entity("INFNET_F.C._API.Models.Resposta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IDDUVIDA_FK")
                        .HasColumnType("int");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(600)")
                        .HasMaxLength(600);

                    b.HasKey("ID");

                    b.HasIndex("IDDUVIDA_FK");

                    b.ToTable("Resposta");
                });

            modelBuilder.Entity("INFNET_F.C._API.Models.Socio", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(350)")
                        .HasMaxLength(350);

                    b.Property<bool>("FLG_Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("ID");

                    b.ToTable("Socio");
                });

            modelBuilder.Entity("INFNET_F.C._API.Models.Assinatura", b =>
                {
                    b.HasOne("INFNET_F.C._API.Models.Plano", "PLANO_FK")
                        .WithMany("Assinaturas")
                        .HasForeignKey("IDPLANO_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("INFNET_F.C._API.Models.Socio", "SOCIO_FK")
                        .WithMany("Assinaturas")
                        .HasForeignKey("IDSOCIO_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("INFNET_F.C._API.Models.Cobranca", b =>
                {
                    b.HasOne("INFNET_F.C._API.Models.Assinatura", "ASSINATURA_FK")
                        .WithMany("Cobrancas")
                        .HasForeignKey("IDASSINATURA_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("INFNET_F.C._API.Models.Duvida", b =>
                {
                    b.HasOne("INFNET_F.C._API.Models.Socio", "SOCIO_FK")
                        .WithMany("Duvidas")
                        .HasForeignKey("IDSOCIO_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("INFNET_F.C._API.Models.Resposta", b =>
                {
                    b.HasOne("INFNET_F.C._API.Models.Duvida", "DUVIDA_FK")
                        .WithMany("Respostas")
                        .HasForeignKey("IDDUVIDA_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
