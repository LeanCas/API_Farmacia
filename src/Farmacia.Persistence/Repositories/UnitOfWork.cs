using Farmacia.Application.Interface.Interfaces;
using Farmacia.Domain.Entities;
using Farmacia.Persistence.Context;

namespace Farmacia.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;

        public IGenericRepository<Analysis> Analysis { get; }

        public IExamRepository Exams { get; }

        public IPatientRepository Patient { get; }

        public IMedicRepository Medic { get; }

        public UnitOfWork(IGenericRepository<Analysis> analysis, ApplicationDBContext context)
        {
            _context = context;
            Analysis = analysis;
            Exams = new ExamRepository(_context);
            Patient = new PatientRepository(_context);
            Medic = new MedicRepository(_context);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
