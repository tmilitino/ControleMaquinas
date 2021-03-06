﻿// <auto-generated />
using Computador;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Computador.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190531211429_Rel_setor1")]
    partial class Rel_setor1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Computador.Models.Maquina", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Chave");

                    b.Property<string>("Marca");

                    b.Property<int>("SetorId");

                    b.HasKey("Id");

                    b.HasIndex("SetorId");

                    b.ToTable("Maquina");
                });

            modelBuilder.Entity("Computador.Models.Setor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Setor");
                });

            modelBuilder.Entity("Computador.Models.Maquina", b =>
                {
                    b.HasOne("Computador.Models.Setor", "Setor")
                        .WithMany("Maquinas")
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
