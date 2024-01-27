using AutoMapper;
using Farmacia.Application.Dtos.Patient.Response;
using Farmacia.Application.UseCase.UseCases.Patient.Commands.ChangeStateCommand;
using Farmacia.Application.UseCase.UseCases.Patient.Commands.CreateCommand;
using Farmacia.Application.UseCase.UseCases.Patient.Commands.UpdateCommand;
using Farmacia.Domain.Entities;

namespace Farmacia.Application.UseCase.Mappings
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile() 
        {
            CreateMap<Patient, GetPatientByIdResponseDto>().ReverseMap();

            CreateMap<CreatePatientCommand, Patient>();

            CreateMap<UpdatePatientCommand, Patient>();

            CreateMap<ChangeStatePatientCommand, Patient>();
        }
    }
}
