using Aula.AWS.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula.AWS.Lib.Data
{
    public class Aula.AWS.Context : DbContext
    {
        public ProjetoAWSContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().ToTable("usuarios_AWS");
            modelBuilder.Entity<Usuario>().HasKey(key => key.Id);
        }
        public DbSet<Usuario> Usuarios {get; set;}
    }
}