namespace tritronAPI.Persist
{
    public interface IUnitOfWork
    {
        void Save();
        void Dispose();
    }
}