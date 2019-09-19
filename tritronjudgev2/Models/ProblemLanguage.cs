namespace Models
{
    public class ProblemLanguage
    {
        public Problem Problem { get; set; }
        public Language Language { get; set; }
        public int ProblemId { get; set; }
        public int LanguageId { get; set; }
    }
}
