using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SGC.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace SGC.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}