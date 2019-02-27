using Microsoft.EntityFrameworkCore;

namespace web_api.Models
{
    public class WebApiContext : DbContext 
    {
        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options)
        {
        }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Matricula> Matricula { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<Nota> Nota { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasKey(c => c.Cpf);
            modelBuilder.Entity<Avaliacao>().HasKey(c => c.CodigoAvaliacao);
            modelBuilder.Entity<Nota>().HasKey(c => c.CodigoNota);
            modelBuilder.Entity<Nota>().HasKey(k => k.CodigoAvaliacao);
            modelBuilder.Entity<Curso>().HasKey(h=>h.CodigoCurso);                       
            modelBuilder.Entity<Matricula>().HasKey(h=>h.CodigoMatricula);
        }
    }
}