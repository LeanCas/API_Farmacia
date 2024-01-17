using Farmacia.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand
{
    public class UpdateAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set; }

        public string? Name { get; set; }
       
    }
}
