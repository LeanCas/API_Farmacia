using Farmacia.Application.Dtos.Medic.Response;
using Farmacia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Application.Interface.Interfaces
{
    public interface IMedicRepository : IGenericRepository<Medic>
    {
        Task<IEnumerable<GetAllMedicResponseDto>> GetAllMedics(string storedProcedure);
    }
}
