  
using System.Threading.Tasks;
using api.Domain;

namespace api.Repository
{
    public interface IApiRepository
    {
        // GERAL
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveChangesAsync();

         Task<Questao[]> GetAllQuestaoAsync();
         Task<Questao[]> GetAllQuestaoAsyncByBanca(string banca);
         //Task<Questao[]> GetAllQuestaoAsyncByDisciplina(string disciplina);
         Task<Questao[]> GetAllQuestaoAsyncByAno(string ano);
         Task<Questao> GetAllQuestaoAsyncById(int id);

    }
}