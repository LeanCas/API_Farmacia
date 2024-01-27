using AutoMapper;
using Farmacia.Application.Dtos.Medic.Response;
using Farmacia.Application.Interface.Interfaces;
using Farmacia.Application.UseCase.Commons.Bases;
using Farmacia.Utilities.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Farmacia.Domain.Entities;

namespace Farmacia.Application.UseCase.UseCases.Medic.Queries.GetByIdQuery
{
    public class GetMedicByIdHandler : IRequestHandler<GetMedicByIdQuery, BaseResponse<GetMedicByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMedicByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetMedicByIdResponseDto>> Handle(GetMedicByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetMedicByIdResponseDto>();

            try
            {
                var Medic = await _unitOfWork.Medic.GetByIdAsync(SP.uspMedicById, request);

                if(Medic != null) 
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<GetMedicByIdResponseDto>(Medic);
                    response.Message = "Consulta exitosa";
                    return response;
                }

                response.IsSuccess = false;
                response.Message = "No se encontraron registros";
                return response;


            }catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
