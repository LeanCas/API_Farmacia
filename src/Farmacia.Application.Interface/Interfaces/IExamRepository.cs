using Farmacia.Application.Dtos.Exam.Response;
using Farmacia.Domain.Entities;

namespace Farmacia.Application.Interface.Interfaces
{
    public interface IExamRepository : IGenericRepository<Exam>
    {
        Task<IEnumerable<GetAllExamResponseDto>> GetAllExams(string storedProcedure);
    }
}
