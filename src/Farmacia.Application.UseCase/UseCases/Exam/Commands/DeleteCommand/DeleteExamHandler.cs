using AutoMapper;
using Farmacia.Application.Interface.Interfaces;
using Farmacia.Application.UseCase.Commons.Bases;
using Farmacia.Utilities.Constants;
using Farmacia.Utilities.HelperExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Entity = Farmacia.Domain.Entities;

namespace Farmacia.Application.UseCase.UseCases.Exam.Commands.DeleteCommand
{
    public class DeleteExamHandler : IRequestHandler<DeleteExamCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfOfWork;
        private readonly IMapper _mapper;

        public DeleteExamHandler(IUnitOfWork unitOfOfWork, IMapper mapper)
        {
            _unitOfOfWork = unitOfOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var exams = _mapper.Map<Entity.Exam>(request);
                var parameters = exams.GetPropertiesWithValues();
                response.Data = await _unitOfOfWork.Exams.ExecAsync(SP.uspExamDelete, parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminacion exitosa";
                    return response;
                }

                response.IsSuccess = false;
                response.Message = "No se encontraron coincidencias";

                
            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "No se pudo completar el eliminacion";
            }


            return response;
        }
    }
}
