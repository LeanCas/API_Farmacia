using Farmacia.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Application.UseCase.UseCases.Exam.Commands.DeleteCommand
{
    public class DeleteExamCommand : IRequest<BaseResponse<bool>>
    {
        public int ExamId { get; set; }
    }
}
