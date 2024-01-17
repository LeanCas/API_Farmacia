using AutoMapper;
using Farmacia.Application.Interface;
using Farmacia.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Farmacia.Domain.Entities;

namespace Farmacia.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand
{
    public class UpdateAnalysisHandler : IRequestHandler<UpdateAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IAnalysisRepository _analysisRepository;

        private readonly IMapper _mapper;

        public UpdateAnalysisHandler(IAnalysisRepository analysisRepository, IMapper mapper)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);

                response.Data = await _analysisRepository.AnalysisEdit(analysis);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualizacion Exitosa";
                }


            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
