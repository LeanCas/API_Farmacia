using Farmacia.Application.Dtos.Patient.Response;
using Farmacia.Application.UseCase.Commons.Bases;
using MediatR;

namespace Farmacia.Application.UseCase.UseCases.Patient.Queries.GetByIdQuery
{
    public class GetPatientByIdQuery : IRequest<BaseResponse<GetPatientByIdResponseDto>>
    {
        public int PatientId { get; set; }
    }
}
