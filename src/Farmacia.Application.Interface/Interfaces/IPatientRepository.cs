using Farmacia.Application.Dtos.Patient.Response;
using Farmacia.Domain.Entities;

namespace Farmacia.Application.Interface.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<IEnumerable<GetAllPatientResponseDto>> GetAllPatients(string storedProcedure);

    }
}
