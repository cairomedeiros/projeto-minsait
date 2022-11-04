﻿// <auto-generated />
using System;
using ClinicaVeterinaria.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClinicaVeterinaria.Migrations
{
    [DbContext(typeof(ClinicaContext))]
    partial class ClinicaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ClinicaVeterinaria.Models.MedicoResponsavel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PacienteId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("MedicosResponsaveis");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e894a7a1-36c9-4b7d-995a-b23de86f4c36"),
                            Nome = "Naruto",
                            PacienteId = new Guid("368a4087-3de7-4bc8-921e-aa6a5a9be54a")
                        },
                        new
                        {
                            Id = new Guid("b6d4b287-9e5e-4c36-8320-689a941d8074"),
                            Nome = "Jiraya",
                            PacienteId = new Guid("234eea2a-0348-45b5-99a1-44b20f010e03")
                        });
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Paciente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Especie")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Idade")
                        .HasColumnType("integer");

                    b.Property<Guid>("MedicoId")
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Peso")
                        .HasColumnType("real");

                    b.Property<string>("Raca")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TutorId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TutorId");

                    b.ToTable("Pacientes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("368a4087-3de7-4bc8-921e-aa6a5a9be54a"),
                            Cor = "Preta",
                            Especie = "Cachorro",
                            Idade = 4,
                            MedicoId = new Guid("e894a7a1-36c9-4b7d-995a-b23de86f4c36"),
                            Nome = "Nymeria",
                            Peso = 22f,
                            Raca = "Pastor Alemão",
                            TutorId = new Guid("ea249baa-c22a-495f-981b-ed6d7c9ea029")
                        },
                        new
                        {
                            Id = new Guid("234eea2a-0348-45b5-99a1-44b20f010e03"),
                            Cor = "Marrom",
                            Especie = "Cachorro",
                            Idade = 7,
                            MedicoId = new Guid("b6d4b287-9e5e-4c36-8320-689a941d8074"),
                            Nome = "Mel",
                            Peso = 10f,
                            Raca = "Shitzu",
                            TutorId = new Guid("40213770-be5a-4c20-9a3b-31e405378768")
                        });
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Tutor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DataNascimento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tutores");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ea249baa-c22a-495f-981b-ed6d7c9ea029"),
                            CPF = "12312332124",
                            DataNascimento = "05/07/2000",
                            Endereco = "Cabedelo",
                            Nome = "Cairo",
                            Telefone = "99999999"
                        },
                        new
                        {
                            Id = new Guid("40213770-be5a-4c20-9a3b-31e405378768"),
                            CPF = "12312332124",
                            DataNascimento = "02/05/2002",
                            Endereco = "JP",
                            Nome = "Rita",
                            Telefone = "99999999"
                        });
                });

            modelBuilder.Entity("MedicoResponsavelPaciente", b =>
                {
                    b.Property<Guid>("MedicoResponsavelListId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PacienteListId")
                        .HasColumnType("uuid");

                    b.HasKey("MedicoResponsavelListId", "PacienteListId");

                    b.HasIndex("PacienteListId");

                    b.ToTable("MedicoResponsavelPaciente");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Paciente", b =>
                {
                    b.HasOne("ClinicaVeterinaria.Models.Tutor", "Tutor")
                        .WithMany("PacienteList")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("MedicoResponsavelPaciente", b =>
                {
                    b.HasOne("ClinicaVeterinaria.Models.MedicoResponsavel", null)
                        .WithMany()
                        .HasForeignKey("MedicoResponsavelListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicaVeterinaria.Models.Paciente", null)
                        .WithMany()
                        .HasForeignKey("PacienteListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Tutor", b =>
                {
                    b.Navigation("PacienteList");
                });
#pragma warning restore 612, 618
        }
    }
}
