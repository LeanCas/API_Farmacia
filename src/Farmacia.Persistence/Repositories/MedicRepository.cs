using Dapper;
using Farmacia.Application.Dtos.Medic.Response;
using Farmacia.Application.Interface.Interfaces;
using Farmacia.Domain.Entities;
using Farmacia.Persistence.Context;

namespace Farmacia.Persistence.Repositories
{
    public class MedicRepository : GenericRepository<Medic>, IMedicRepository
    {
        private readonly ApplicationDBContext _context;

        public MedicRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllMedicResponseDto>> GetAllMedics(string storedProcedure)
        {
            var connection = _context.CreateConnection;

            var medics = await connection.QueryAsync<GetAllMedicResponseDto>(storedProcedure, commandType: System.Data.CommandType.StoredProcedure);

            return medics;
        }
    }
}
