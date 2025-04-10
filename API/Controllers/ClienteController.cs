using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {


        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            var clientes = _context.Clientes.ToList();
            if (clientes == null || !clientes.Any())
            {
                return NotFound("Nenhum cliente encontrado.");
            }
            return Ok(clientes);

        }

        [HttpGet("{id}")]
        public IActionResult GetClienteById(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound($"Cliente com ID {id} não encontrado.");
            }

            return Ok(cliente);
        }
        [HttpPost]
        public IActionResult CreateCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Cliente inválido.");
            }
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetClienteById), new { id = cliente.Id }, cliente);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest("ID do cliente não corresponde ao ID fornecido.");
            }

            var existingCliente = _context.Clientes.Find(id);
            if (existingCliente == null)
            {
                return NotFound($"Cliente com ID {id} não encontrado.");
            }

            existingCliente.Nome = cliente.Nome;
            existingCliente.Email = cliente.Email;
            existingCliente.Telefone = cliente.Telefone;

            _context.Clientes.Update(existingCliente);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound($"Cliente com ID {id} não encontrado.");
            }

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpGet("search")]
        public IActionResult SearchClientes(string nome, string email, string telefone)
        {
            var query = _context.Clientes.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(c => c.Nome.Contains(nome));
            }

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(c => c.Email.Contains(email));
            }

            if (!string.IsNullOrEmpty(telefone))
            {
                query = query.Where(c => c.Telefone.Contains(telefone));
            }

            var clientes = query.ToList();

            if (clientes == null || !clientes.Any())
            {
                return NotFound("Nenhum cliente encontrado com os critérios fornecidos.");
            }

            return Ok(clientes);
        }
    }
}