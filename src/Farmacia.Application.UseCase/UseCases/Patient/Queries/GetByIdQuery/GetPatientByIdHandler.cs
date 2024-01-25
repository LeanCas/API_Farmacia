using AutoMapper;
using Farmacia.Application.Dtos.Patient.Response;
using Farmacia.Application.Interface.Interfaces;
using Farmacia.Application.UseCase.Commons.Bases;
using Farmacia.Utilities.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Application.UseCase.UseCases.Patient.Queries.GetByIdQuery
{
    public class GetPatientByIdHandler : IRequestHandler<GetPatientByIdQuery, BaseResponse<GetPatientByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPatientByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetPatientByIdResponseDto>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetPatientByIdResponseDto>();

            try
            {
                var patient = await _unitOfWork.Patient.GetByIdAsync(SP.uspPatientById, request);

                if(patient is null)
                {
                    response.IsSuccess = false;
                    response.Message = "No existen registros";
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetPatientByIdResponseDto>(patient);
                response.Message = "Consulta exitosa";

            }catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
