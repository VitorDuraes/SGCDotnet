using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SGC.API.DTOs;
using SGC.Domain.Entities;

namespace SGC.API.Services
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