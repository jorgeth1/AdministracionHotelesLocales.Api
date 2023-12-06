using AdministracionHotelesLocales.Infra.Contexts;
using AdministracionHotelesLocales.Infra.Ports;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdministracionHotelesLocales.Infra.Adapters
{
    public class GenericRepository<TDomainEntity>
        : IGenericRepository<TDomainEntity> where TDomainEntity : Domain.Entities.Base.DomainEntity
    {
        private readonly AdministracionHotelesLocalesContext _fantasyEventRoomContext;
        protected DbSet<TDomainEntity> _dataSource;
        public GenericRepository(AdministracionHotelesLocalesContext fantasyEventRoomContext)
        {
            _fantasyEventRoomContext = fantasyEventRoomContext;
            _dataSource = _fantasyEventRoomContext.Set<TDomainEntity>();
        }

        public async Task<TDomainEntity> AddAsync(TDomainEntity entity)
        {
            await _dataSource.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(TDomainEntity entity)
        {
            _dataSource.Remove(entity);
            await Task.CompletedTask;
        }


        public async Task<IEnumerable<TDomainEntity>> GetAsync(Expression<Func<TDomainEntity, bool>> filter = null)
        {
            return filter is not null ?
                await _dataSource.Where(filter).ToListAsync()
                : await _dataSource.ToListAsync();
        }

        public async Task<TDomainEntity> GetByIdAsync(object id)
        {
            return await _dataSource.FindAsync(id);
        }

        public async Task UpdateAsync(TDomainEntity entity)
        {
            if (entity is not null)
            {
                _dataSource.Update(entity);
            }

            await Task.CompletedTask;
        }
    }
}
