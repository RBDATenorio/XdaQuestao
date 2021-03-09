using System.Collections.Generic;

namespace api.Dtos
{
    public class QuestaoDto
    {
        public int QuestaoId { get; set; }
        public string Banca { get; set; }
        public string Orgao { get; set; }
        public string Disciplina { get; set; }
        public string Assunto { get; set; }
        public string Ano { get; set; }
        public string Enunciado { get; set; }
        public string ComentarioProfessor { get; set; }
        public string AlternativaA { get; set; }
        public string AlternativaB { get; set; }
        public string AlternativaC { get; set; }
        public string AlternativaD { get; set; }
        public string AlternativaE { get; set; }
        public string Resposta { get; set; }
        public List<ComentarioDto> Comentarios { get; set; }
        public List<CadernoDto> Cadernos { get; set; }
    }
}