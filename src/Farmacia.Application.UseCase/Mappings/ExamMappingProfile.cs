using AutoMapper;
using Farmacia.Application.Dtos.Exam.Response;
using Farmacia.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand;
using Farmacia.Application.UseCase.UseCases.Exam.Commands.CreateCommand;
using Farmacia.Application.UseCase.UseCases.Exam.Commands.DeleteCommand;
using Farmacia.Application.UseCase.UseCases.Exam.Commands.UpdateCommand;
using Farmacia.Domain.Entities;

namespace Farmacia.Application.UseCase.Mappings
{
    public class ExamMappingProfile : Profile
    {
        public ExamMappingProfile()
        {
            CreateMap<Exam, GetAllExamResponseDto>()
                .ForMember(X => X.StateExam, X => X.MapFrom(Y => Y.State == 1 ? "ACTIVO" : "INACTIVO"));

            CreateMap<Exam, GetExamByIdResponseDto>().ReverseMap();

            CreateMap<CreateExamCommand, Exam>().ReverseMap();

            CreateMap<UpdateExamCommand, Exam>().ReverseMap();

            CreateMap<DeleteExamCommand, Exam>().ReverseMap();

            CreateMap<ChangeStateAnalysisCommand, Exam>().ReverseMap();
        }
    }
}
