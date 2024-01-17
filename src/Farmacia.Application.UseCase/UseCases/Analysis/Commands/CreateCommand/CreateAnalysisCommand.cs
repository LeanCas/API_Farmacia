using Farmacia.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Application.UseCase.UseCases.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public string? Name { get; set; }
    }
}
