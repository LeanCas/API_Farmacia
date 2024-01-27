using Farmacia.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Application.UseCase.UseCases.Patient.Commands.ChangeStateCommand
{
    public class ChangeStatePatientCommand : IRequest<BaseResponse<bool>>
    {
        public int PatientId { get; set; }

        public int State { get; set; }
    }
}
