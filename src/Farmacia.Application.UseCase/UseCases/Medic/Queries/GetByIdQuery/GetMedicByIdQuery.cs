using Farmacia.Application.Dtos.Medic.Response;
using Farmacia.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Application.UseCase.UseCases.Medic.Queries.GetByIdQuery
{
    public class GetMedicByIdQuery : IRequest<BaseResponse<GetMedicByIdResponseDto>>
    {
        public int MedicId { get; set; }
    }
}
