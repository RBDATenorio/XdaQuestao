namespace api.Dtos
{
    public class ComentarioDto
    {
        public int ComentarioId { get; set; }
        public string Assunto { get; set; }
        public string Data { get; set; }
        public AlunoDto Usuario { get; } 
        public int QuestaoId { get; set; }
        
    }
}