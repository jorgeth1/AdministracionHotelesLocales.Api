namespace AdministracionHotelesLocales.Domain.Ports.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
