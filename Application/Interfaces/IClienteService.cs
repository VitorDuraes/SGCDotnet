using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> GetAllClientesAsync();
        Task<ClienteDTO?> BuscarPorIdAsync(int id);
        Task<IEnumerable<ClienteDTO>> BuscarPorNomeAsync(string nome);
        Task<Cliente> CadastrarAsync(int id, ClienteDTO clienteDTO);
        Task<bool> AtualizarAsync(int id, ClienteDTO clienteDTO);
        Task<bool> RemoverAsync(int id);
    }
}