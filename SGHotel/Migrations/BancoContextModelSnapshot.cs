﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGHotel.Models.Data;

namespace SGHotel.Migrations
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SGHotel.Models.AndarModel", b =>
                {
                    b.Property<int>("IdAndar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Num_Andar")
                        .HasColumnType("int");

                    b.HasKey("IdAndar");

                    b.ToTable("Andares");
                });

            modelBuilder.Entity("SGHotel.Models.ClienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SGHotel.Models.ContaModel", b =>
                {
                    b.Property<int>("IdConta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor_Conta")
                        .HasColumnType("float");

                    b.Property<DateTime>("dt_lancamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dt_vencimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("tp_conta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdConta");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("SGHotel.Models.QuartoModel", b =>
                {
                    b.Property<int>("Id_Quarto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<int>("Id_Andar")
                        .HasColumnType("int");

                    b.Property<bool>("Limpo")
                        .HasColumnType("bit");

                    b.Property<string>("Num_quarto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.HasKey("Id_Quarto");

                    b.ToTable("Quartos");
                });

            modelBuilder.Entity("SGHotel.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
