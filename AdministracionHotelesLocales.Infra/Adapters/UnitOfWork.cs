using AdministracionHotelesLocales.Domain.Ports.Repositories;
using AdministracionHotelesLocales.Infra.Contexts;

namespace AdministracionHotelesLocales.Infra.Adapters
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdministracionHotelesLocalesContext _administracionHotelesLocalesContext;
        public UnitOfWork(AdministracionHotelesLocalesContext administracionHotelesLocalesContext)
        {
            _administracionHotelesLocalesContext = administracionHotelesLocalesContext;
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _administracionHotelesLocalesContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _administracionHotelesLocalesContext.Dispose();
            }
        }
    }
}
