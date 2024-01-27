using AutoMapper;
using Farmacia.Application.Dtos.Medic.Response;
using Farmacia.Application.UseCase.UseCases.Medic.Commands.CreateCommand;
using Farmacia.Application.UseCase.UseCases.Medic.Commands.UpdateCommand;
using Farmacia.Application.UseCase.UseCases.Patient.Commands.DeleteCommand;
using Farmacia.Domain.Entities;

namespace Farmacia.Application.UseCase.Mappings
{
    public class MedicMappingProfile : Profile
    {
        public MedicMappingProfile() 
        {
            CreateMap<Medic, GetMedicByIdResponseDto>().ReverseMap();

            CreateMap<CreateMedicCommand, Medic>();

            CreateMap<UpdateMedicCommand, Medic>();

            CreateMap<DeleteMedicCommand, Medic>();
        }
    }
}
