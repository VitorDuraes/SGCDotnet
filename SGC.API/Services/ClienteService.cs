using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SGC.API.DTOs;
using SGC.Domain.Entities;
using SGC.Infra.Data;

namespace SGC.API.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public ClienteService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> AtualizarAsync(int id, ClienteDTO clienteDTO)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return false;

            cliente.Nome = clienteDTO.Nome;
            cliente.Email = clienteDTO.Email;
            cliente.Telefone = clienteDTO.Telefone;

            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ClienteDTO?> BuscarPorIdAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return null;
            }
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<IEnumerable<ClienteDTO>> BuscarPorNomeAsync(string nome)
        {
            var clientes = await _context.Clientes
                .Where(c => c.Nome.Contains(nome))
                .ToListAsync();

            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
        }

        public async Task<IEnumerable<ClienteDTO>> GetAllClientesAsync()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
        }

        public async Task<Cliente> CadastrarAsync(int id, ClienteDTO clienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            cliente.Id = id; // Remova essa linha se o Id for auto-incremento

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return true;
        }

    }

}
