namespace porTIEVserver.Domain.Repositories.Admin
{
    public interface IUnitOfWorkFirm
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
