using AutoMapper;
using Farmacia.Application.Dtos.Exam.Response;
using Farmacia.Application.Interface.Interfaces;
using Farmacia.Application.UseCase.Commons.Bases;
using Farmacia.Utilities.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Application.UseCase.UseCases.Exam.Queries.GetByIdQuery
{
    public class GetExamByIdHandler : IRequestHandler<GetExamByIdQuery, BaseResponse<GetExamByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public GetExamByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetExamByIdResponseDto>> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetExamByIdResponseDto>();

            try
            {

                var exams = await _unitOfWork.Exams.GetByIdAsync(SP.uspExamById, request);

                if(exams is null)
                {
                    response.IsSuccess = false;
                    response.Message = "No se encontraron coincidencias";
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetExamByIdResponseDto>(exams);
                response.Message = "Consulta exitosa";

                return response;

            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message =ex.Message;

            }

            return response;
        }
    }
}
