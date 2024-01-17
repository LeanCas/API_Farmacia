using AutoMapper;
using Farmacia.Application.Dtos.Analysis.Response;
using Farmacia.Application.Interface;
using Farmacia.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery
{
    public class AnalysisByIdHandler : IRequestHandler<GetAnalysisByIdQuery, BaseResponse<GetAnalysisByIdResponseDto>>
    {
        private readonly IAnalysisRepository _analysisRepository;

        private readonly IMapper _mapper;

        public AnalysisByIdHandler(IAnalysisRepository analysisRepository, IMapper mapper)
        {
            this._analysisRepository = analysisRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetAnalysisByIdResponseDto>> Handle(GetAnalysisByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetAnalysisByIdResponseDto>();

            try
            {
                var analysis = await _analysisRepository.AnalysisPorID(request.AnalysisId);

                if(analysis is null)
                {
                    response.IsSuccess = false;
                    response.Message = "No se encontaron registros";
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetAnalysisByIdResponseDto>(analysis); 
                response.Message = "Consulta exitosa";
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
