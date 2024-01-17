using AutoMapper;
using Farmacia.Application.Dtos.Analysis.Response;
using Farmacia.Application.UseCase.UseCases.Analysis.Commands.CreateCommand;
using Farmacia.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand;
using Farmacia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Application.UseCase.Mappings
{
    public class AnalysisMappingProfile : Profile
    {
        public AnalysisMappingProfile()
        {
            CreateMap<Analysis, GetAllAnalysisResponseDto>()
                .ForMember(X => X.StateAnalysis, X => X.MapFrom(Y => Y.State == 1 ? "ACTIVO" : "INACTIVO"))
                .ReverseMap();

            CreateMap<Analysis, GetAnalysisByIdResponseDto>()
                .ReverseMap();

            CreateMap<CreateAnalysisCommand, Analysis>();

            CreateMap<UpdateAnalysisCommand, Analysis>();
        }
    }
}
