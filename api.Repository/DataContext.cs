using api.Domain;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Questao> Questaos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Caderno> Cadernos { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<CadernoQuestao> CadernosQuestaos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<CadernoQuestao>().HasKey( PE => new { PE.CadernoId, PE.QuestaoId });
        }
        }
}