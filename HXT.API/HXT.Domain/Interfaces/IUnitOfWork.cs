namespace HXT.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
