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

namespace Farmacia.Application.UseCase.UseCases.Exam.Commands.UpdateCommand
{
    public class UpdateExamHandler : IRequestHandler<UpdateExamCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var exams = _mapper.Map<Entity.Exam>(request);
                var parameters = exams.GetPropertiesWithValues();
                response.Data = await _unitOfWork.Exams.ExecAsync(SP.uspExamEdit, parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Edicion exitosa";
                    return response;
                }

                response.IsSuccess = false;
                response.Message = "No se pudo completar la edicion";

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "No se pudo completar la edicion";
            }

            return response;
        }
    }
}
