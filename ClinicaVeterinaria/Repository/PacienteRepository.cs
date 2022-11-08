﻿using ClinicaVeterinaria.Data;
using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Models.Dtos;
using ClinicaVeterinaria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Repository {
    public class PacienteRepository : IPacienteRepository {
        private readonly ClinicaContext _dbContext;

        public PacienteRepository(ClinicaContext dbContext) {
            _dbContext = dbContext;
        }
        public async Task<Paciente> Adicionar(PacienteDto pacienteAdicionarDto) {
            
            Paciente paciente = new Paciente();
            paciente.Nome = pacienteAdicionarDto.Nome;
            paciente.Especie = pacienteAdicionarDto.Especie;
            paciente.Raca = pacienteAdicionarDto.Raca;
            paciente.Idade = pacienteAdicionarDto.Idade;
            paciente.Peso = pacienteAdicionarDto.Peso;
            paciente.Cor = pacienteAdicionarDto.Cor;
            paciente.TutorId = pacienteAdicionarDto.TutorId;
            paciente.EResultadoTriagem = pacienteAdicionarDto.EResultadoTriagem;


            await _dbContext.Pacientes.AddAsync(paciente);
            await _dbContext.SaveChangesAsync();

            return paciente;
        }

        public async Task<Paciente> BuscarPorId(Guid id) {
            var paciente = await _dbContext.Pacientes
                .FirstOrDefaultAsync(y => y.Id == id);

            if (paciente == null) {
                throw new Exception($"Paciente com Id: ${id} não encontrado");

            }

            return paciente;
        }

        public async Task<bool> DeletarPaciente(Guid id) {
            var pacienteId = await _dbContext.Pacientes.FindAsync(id);

            if (pacienteId == null) {
                throw new Exception($"Tutor com Id: ${id} não encontrado");
            }

            _dbContext.Remove(pacienteId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Paciente> Editar(Guid id, Paciente paciente) {
            var pacienteId = await _dbContext.Pacientes.FindAsync(id);
            if (pacienteId == null) {
                throw new Exception($"Tutor com Id: ${id} não encontrado");
            }

            pacienteId.Nome = paciente.Nome;
            pacienteId.Especie = paciente.Especie;
            pacienteId.Raca = paciente.Raca;
            pacienteId.Idade = paciente.Idade;
            pacienteId.Peso = paciente.Peso;
            pacienteId.Cor = paciente.Cor;

            _dbContext.Pacientes.Update(pacienteId);
            await _dbContext.SaveChangesAsync();

            return pacienteId;
        }

        public async Task<List<Paciente>> RetornarTodosPacientes() {
            return await _dbContext.Pacientes
                .ToListAsync();
        }
    }
}
