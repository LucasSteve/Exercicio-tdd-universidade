// <auto-generated />
using System;
using Exercicio09.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Exercicio09.Infrastructure.Migrations
{
    [DbContext(typeof(Exercicio09Context))]
    [Migration("20221111155858_AddNovas")]
    partial class AddNovas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Exercicio09.Domain.Entities.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Duraçao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoCurso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Turno")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioAlteracao")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioInclusao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Exercicio09.Domain.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnderecoID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioAlteracao")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioInclusao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoID");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Exercicio09.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioAlteracao")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioInclusao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Exercicio09.Domain.Entities.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Permissao")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioAlteracao")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioInclusao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Perfis");
                });

            modelBuilder.Entity("Exercicio09.Domain.Entities.Curso", b =>
                {
                    b.HasOne("Exercicio09.Domain.Entities.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Exercicio09.Domain.Entities.Departamento", b =>
                {
                    b.HasOne("Exercicio09.Domain.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });
#pragma warning restore 612, 618
        }
    }
}
