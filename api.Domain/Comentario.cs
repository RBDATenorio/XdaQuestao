using System;

namespace api.Domain
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public string Assunto { get; set; }
        public DateTime Data { get; set; }
        public int UsuarioId { get; set; }
        public Aluno Usuario { get; } 
        public int QuestaoId { get; set; }
        public Questao Questao { get; }
    }
}