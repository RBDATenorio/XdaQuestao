using System.Collections.Generic;

namespace api.Domain
{
    public class Aluno : Usuario
    {
        public string Plano { get; set; }
        public List<Caderno> Cadernos { get; set; }
    }
}