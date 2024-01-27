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

namespace Farmacia.Application.UseCase.UseCases.Exam.Commands.ChangeStateCommand
{
    public class ChangeStateExamHandler : IRequestHandler<ChangeStateExamCommand, BaseResponse<bool>>
    {

        private readonly IUnitOfWork _unitOfOfWork;
        private readonly IMapper _mapper;

        public ChangeStateExamHandler(IUnitOfWork unitOfOfWork, IMapper mapper)
        {
            _unitOfOfWork = unitOfOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(ChangeStateExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var exam = _mapper.Map<Entity.Exam>(request);
                var parameters = exam.GetPropertiesWithValues();
                response.Data = await _unitOfOfWork.Exams.ExecAsync(SP.uspExamChangeState, parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Modificacion exitosa";
                    return response;
                }

                response.IsSuccess = false;
                response.Message = "No se encontraron coincidencias";

            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
