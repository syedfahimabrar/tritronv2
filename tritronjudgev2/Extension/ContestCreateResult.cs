using Models;

namespace Extension
{
    public class ContestCreateResult
    {
        public bool Succeeded { get; set; }
        public Contest Contest { get; set; }
        public string Error { get; set; }
    }
}
