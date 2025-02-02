﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteTecnicoWK.Data;

#nullable disable

namespace TesteTecnicoWK.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20250201232356_CriacaoBancoDados")]
    partial class CriacaoBancoDados
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TesteTecnicoWK.Models.ClienteModel", b =>
                {
                    b.Property<int>("Cod_Cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cod_Cliente"));

                    b.Property<string>("Des_Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Des_Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Des_NomeCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Des_UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cod_Cliente");

                    b.ToTable("Tab_Cliente");
                });

            modelBuilder.Entity("TesteTecnicoWK.Models.PedidoItemModel", b =>
                {
                    b.Property<int>("Cod_Pedido")
                        .HasColumnType("int");

                    b.Property<int>("Cod_Produto")
                        .HasColumnType("int");

                    b.Property<int>("Id_Pedido")
                        .HasColumnType("int");

                    b.Property<decimal>("Val_PrecoUnitario")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("Val_Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("Val_TotalItem")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Cod_Pedido", "Cod_Produto");

                    b.HasIndex("Cod_Produto");

                    b.ToTable("Tab_Pedido_Item");
                });

            modelBuilder.Entity("TesteTecnicoWK.Models.PedidoModel", b =>
                {
                    b.Property<int>("Cod_Pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cod_Pedido"));

                    b.Property<int>("ClienteCod_Cliente")
                        .HasColumnType("int");

                    b.Property<int>("Cod_Cliente")
                        .HasColumnType("int");

                    b.Property<DateTime>("Dta_pedido")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Val_Pedido")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Cod_Pedido");

                    b.HasIndex("ClienteCod_Cliente");

                    b.ToTable("Tab_Pedido");
                });

            modelBuilder.Entity("TesteTecnicoWK.Models.ProdutoModel", b =>
                {
                    b.Property<int>("Cod_Produto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cod_Produto"));

                    b.Property<string>("Des_Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Val_Preco")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Cod_Produto");

                    b.ToTable("Tab_Produto");
                });

            modelBuilder.Entity("TesteTecnicoWK.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Cod_Usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cod_Usuario"));

                    b.Property<int>("Cod_Perfil")
                        .HasColumnType("int");

                    b.Property<string>("Des_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Des_Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Des_NomeUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Des_Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Dta_Atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Dta_Cadastro")
                        .HasColumnType("datetime2");

                    b.HasKey("Cod_Usuario");

                    b.ToTable("Tab_Usuario");
                });

            modelBuilder.Entity("TesteTecnicoWK.Models.PedidoItemModel", b =>
                {
                    b.HasOne("TesteTecnicoWK.Models.PedidoModel", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("Cod_Pedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TesteTecnicoWK.Models.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("Cod_Produto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("TesteTecnicoWK.Models.PedidoModel", b =>
                {
                    b.HasOne("TesteTecnicoWK.Models.ClienteModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteCod_Cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("TesteTecnicoWK.Models.PedidoModel", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
