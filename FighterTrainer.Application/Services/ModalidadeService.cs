using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FighterTrainer.Application.Interfaces;
using FighterTrainer.Domain.Entities;
using FighterTrainer.Domain.Interfaces;

namespace FighterTrainer.Application.Services
{
    public class ModalidadeService : IModalidadeService
    {
        private readonly IModalidadeRepository _repository;

        public ModalidadeService(IModalidadeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ModalidadeDto>> ListarTodasAsync()
        {
            var modalidades = await _repository.GetAllAsync();
            return modalidades.Select(m => new ModalidadeDto
            {
                Id = m.Id,
                Descricao = m.Descricao
            }).ToList();
        }

        public async Task<ModalidadeDto> CriarAsync(ModalidadeDto dto)
        {
            var modalidade = new Modalidade(dto.Descricao);
            await _repository.AddAsync(modalidade);

            return new ModalidadeDto
            {
                Id = modalidade.Id,
                Descricao = modalidade.Descricao
            };
        }
    }


}
