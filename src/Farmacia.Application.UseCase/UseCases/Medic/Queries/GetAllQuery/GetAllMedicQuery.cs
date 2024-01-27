using Farmacia.Application.Dtos.Medic.Response;
using Farmacia.Application.UseCase.Commons.Bases;
using MediatR;

namespace Farmacia.Application.UseCase.UseCases.Medic.Queries.GetAllQuery
{
    public class GetAllMedicQuery : IRequest<BaseResponse<IEnumerable<GetAllMedicResponseDto>>>
    {

    }
}
