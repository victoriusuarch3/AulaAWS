using Aula.AWS.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula.AWS.Lib.Data
{
    public class AulaAWSContext : DbContext
    {
        public AulaAWSContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().ToTable("usuarios_AWS");
            modelBuilder.Entity<Usuario>().HasKey(key => key.id);
        }
        public DbSet<Usuario> Usuarios {get; set;}
    }
}