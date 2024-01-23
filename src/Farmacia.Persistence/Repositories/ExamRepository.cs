using Dapper;
using Farmacia.Application.Dtos.Exam.Response;
using Farmacia.Application.Interface.Interfaces;
using Farmacia.Domain.Entities;
using Farmacia.Persistence.Context;
using System.Data;

namespace Farmacia.Persistence.Repositories
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        private readonly ApplicationDBContext _context;

        public ExamRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllExamResponseDto>> GetAllExams(string storedProcedure)
        {
            using var connection = _context.CreateConnection;

            var exams = await connection.QueryAsync<GetAllExamResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);

            return exams;
        }
    }
}
