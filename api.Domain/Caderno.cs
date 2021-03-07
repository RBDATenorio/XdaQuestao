using System.Collections.Generic;

namespace api.Domain
{
    public class Caderno
    {
        public int CadernoId { get; set; }
        public int UsuarioId { get; set; }
        public Aluno Aluno { get; set; }
        public List<CadernoQuestao> CadernosQuestaos { get; set; }
    }
}