namespace TWA.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : Common.BaseEntity;
        Task<int> CommitAsync();
    }
}
