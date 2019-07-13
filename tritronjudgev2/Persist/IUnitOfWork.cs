using System.Threading.Tasks;

namespace tritronAPI.Persist
{
    public interface IUnitOfWork
    {
        IProblemRepository ProblemRepository { get; }
        void Save();
        void Dispose();
    }
}