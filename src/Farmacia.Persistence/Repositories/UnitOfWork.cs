using Farmacia.Application.Interface.Interfaces;
using Farmacia.Domain.Entities;

namespace Farmacia.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IGenericRepository<Analysis> analysis)
        {
            Analysis = analysis;
        }

        public IGenericRepository<Analysis> Analysis { get; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
