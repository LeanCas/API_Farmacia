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

namespace Farmacia.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery
{
    public class GetAllAnalysisHandler : IRequestHandler<GetAllAnalysisQuery, BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>>
    {
        private readonly IAnalysisRepository _analysisRepository;

        private readonly IMapper _mapper;

        public GetAllAnalysisHandler(IAnalysisRepository analysisRepository, IMapper mapper)
        {
            _analysisRepository = analysisRepository;
            _mapper =  mapper;
        }

        public async Task<BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>> Handle(GetAllAnalysisQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>();

            try
            {
                var analysis = await _analysisRepository.ListAnalysis();

                if(analysis is not null) 
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<IEnumerable<GetAllAnalysisResponseDto>>(analysis);
                    response.Message = "Consulta Exitosa";
                }


            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
