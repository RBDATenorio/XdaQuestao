using System.Collections.Generic;

namespace api.Dtos
{
    public class CadernoDto
    {
        public int CadernoId { get; set; }
        public int UsuarioId { get; set; }
        public AlunoDto Aluno { get; }
        public List<QuestaoDto> Questaos { get; set; }
    }
}