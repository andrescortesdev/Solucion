using Microsoft.EntityFrameworkCore;
using Solucion.Models;

namespace Solucion.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options){

        }

        // Registramos nuestros modelos
        public DbSet<User> Users { get; set; }
    }
}