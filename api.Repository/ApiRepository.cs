using System.Linq;
using System.Threading.Tasks;
using api.Domain;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ApiRepository : IApiRepository
    {
        private readonly DataContext _context;

        public ApiRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        // QUESTOES
        public async Task<Questao[]> GetAllQuestaoAsync()
        {
            IQueryable<Questao> query = _context.Questaos
                                .Include( c => c.Comentarios );
                                //.ThenInclude( a => a.Aluno )
            return await query.ToArrayAsync();
        }

        public async Task<Questao[]> GetAllQuestaoAsyncByAno(string ano)
        {
            IQueryable<Questao> query = _context.Questaos
                    .Include( c => c.Comentarios );
                    //.ThenInclude( a => a.Aluno )
            query = query.Where( c => c.Ano.ToLower().Contains(ano.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Questao[]> GetAllQuestaoAsyncByBanca(string banca)
        {
            IQueryable<Questao> query = _context.Questaos
                    .Include( c => c.Comentarios );
                    //.ThenInclude( a => a.Aluno )
            query = query.Where( c => c.Banca.ToLower().Contains(banca.ToLower()));
            return await query.ToArrayAsync();
        }

/*         public async Task<Questao[]> GetAllQuestaoAsyncByDisciplina(string disciplina)
        {
            IQueryable<Questao> query = _context.Questaos
                    .Include( c => c.Comentarios );
                    //.ThenInclude( a => a.Aluno )
            query = query.Where( c => c.Disciplina.ToLower().Contains(disciplina.ToLower()));
            return await query.ToArrayAsync();
        } */

        public async Task<Questao> GetAllQuestaoAsyncById(int id)
        {
            IQueryable<Questao> query = _context.Questaos
                    .Include( c => c.Comentarios );
                    //.ThenInclude( a => a.Aluno )
            query = query.Where( c => c.QuestaoId == id );
            return await query.FirstOrDefaultAsync();
        }


    }
}