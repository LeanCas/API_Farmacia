using Dapper;
using Farmacia.Application.Dtos.Patient.Response;
using Farmacia.Application.Interface.Interfaces;
using Farmacia.Domain.Entities;
using Farmacia.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Persistence.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly ApplicationDBContext _context;

        public PatientRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllPatientResponseDto>> GetAllPatients(string storedProcedure)
        {
            var connection = _context.CreateConnection;
            var patients = await connection
                .QueryAsync<GetAllPatientResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);
            return patients;

        }

    }
}
