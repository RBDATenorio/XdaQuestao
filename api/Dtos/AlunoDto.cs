using System.Collections.Generic;

namespace api.Dtos
{
    public class AlunoDto
    {
        public string Plano { get; set; }
        public List<CadernoDto> Cadernos { get; set; }
    }
}