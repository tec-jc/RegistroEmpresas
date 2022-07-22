using Microsoft.EntityFrameworkCore;

namespace RegistroEmpresas.Models
{
    public class ContextoDeDatos : DbContext
    {
        public ContextoDeDatos(DbContextOptions<ContextoDeDatos> options) : base(options)
        {
        }

        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Empresa> Empresas { get; set; } 
    }
}
