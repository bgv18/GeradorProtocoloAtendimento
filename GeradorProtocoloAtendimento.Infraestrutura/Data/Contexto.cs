using GeradorProtocoloAtendimento.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GeradorProtocoloAtendimento.EF
{
    public class Contexto : DbContext
    {
        public DbSet<Protocolo> Protocolo { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Protocolo>()
                .HasKey(p => new {p.DataAtual, p.NumeroSequencial });
            modelBuilder.Entity<Protocolo>()
                .Property(p => p.EmpresaIdentificador)
                .HasMaxLength(6);

            base.OnModelCreating(modelBuilder);
        }
    }
}
