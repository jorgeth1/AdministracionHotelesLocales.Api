using System.Linq.Expressions;

namespace AdministracionHotelesLocales.Infra.Ports
{
    public interface IGenericRepository<TDomainEntity> where TDomainEntity
        : AdministracionHotelesLocales.Domain.Entities.Base.DomainEntity
    {
        Task<IEnumerable<TDomainEntity>> GetAsync(Expression<Func<TDomainEntity, bool>> filter = null);

        Task<TDomainEntity> GetByIdAsync(object id);
        Task<TDomainEntity> AddAsync(TDomainEntity entity);
        Task UpdateAsync(TDomainEntity entity);
        Task DeleteAsync(TDomainEntity entity);
    }
}
