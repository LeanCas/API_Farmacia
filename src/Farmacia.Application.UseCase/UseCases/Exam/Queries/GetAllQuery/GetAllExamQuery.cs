using Farmacia.Application.Dtos.Exam.Response;
using Farmacia.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Application.UseCase.UseCases.Exam.Queries.GetAllQuery
{
    public class GetAllExamQuery : IRequest<BaseResponse<IEnumerable<GetAllExamResponseDto>>>
    {
    }
}
