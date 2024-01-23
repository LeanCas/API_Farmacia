using AutoMapper;
using Farmacia.Application.Interface.Interfaces;
using Farmacia.Application.UseCase.Commons.Bases;
using Farmacia.Utilities.Constants;
using Farmacia.Utilities.HelperExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Farmacia.Domain.Entities;

namespace Farmacia.Application.UseCase.UseCases.Exam.Commands.CreateCommand
{
    public class CreateExamHandler : IRequestHandler<CreateExamCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfOfWork;
        private readonly IMapper _mapper;

        public CreateExamHandler(IUnitOfWork unitOfOfWork, IMapper mapper)
        {
            _unitOfOfWork = unitOfOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var exam = _mapper.Map<Entity.Exam>(request);
                var parameters = exam.GetPropertiesWithValues();
                response.Data = await _unitOfOfWork.Exams.ExecAsync(SP.uspExamRegister, parameters);

                if(response.Data == true)
                {
                    response.IsSuccess = true;
                    response.Message = "Se guardo con exito";
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
