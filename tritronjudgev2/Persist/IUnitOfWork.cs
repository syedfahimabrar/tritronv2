namespace tritronAPI.Persist
{
    public interface IUnitOfWork
    {
        IProblemRepository ProblemRepository { get; }
        void Save();
        void Dispose();
    }
}