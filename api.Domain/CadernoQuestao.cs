namespace api.Domain
{
    public class CadernoQuestao
    {
        public int CadernoId { get; set; }
        public Caderno Caderno { get; set; }
        public int QuestaoId { get; set; }
        public Questao Questao { get; set; }
    }
}